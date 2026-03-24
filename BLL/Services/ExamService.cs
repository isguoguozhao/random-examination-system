using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using Xceed.Words.NET;
using 单位抽考win7软件.Common.Entities;
using 单位抽考win7软件.DAL;

namespace 单位抽考win7软件.BLL.Services
{
    /// <summary>
    /// 抽考服务类（核心业务）
    /// </summary>
    public class ExamService
    {
        private readonly CommandGroupService _groupService;
        private readonly TaskPlanService _taskPlanService;
        private readonly MustHitRuleService _mustHitRuleService;
        private readonly LogService _logService;

        public ExamService()
        {
            _groupService = new CommandGroupService();
            _taskPlanService = new TaskPlanService();
            _mustHitRuleService = new MustHitRuleService();
            _logService = new LogService();
        }

        /// <summary>
        /// 根据ID获取抽考活动
        /// </summary>
        public ExamActivity GetById(int id)
        {
            string sql = "SELECT * FROM ExamActivity WHERE Id = @Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            });

            if (dt.Rows.Count > 0)
            {
                return DataRowToExamActivity(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 获取所有抽考活动
        /// </summary>
        public List<ExamActivity> GetAll()
        {
            List<ExamActivity> activities = new List<ExamActivity>();
            string sql = "SELECT * FROM ExamActivity ORDER BY CreatedTime DESC";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                activities.Add(DataRowToExamActivity(row));
            }
            return activities;
        }

        /// <summary>
        /// 添加抽考活动
        /// </summary>
        public int Add(ExamActivity activity)
        {
            string sql = @"INSERT INTO ExamActivity (ActivityName, BatchNo, DrawGroupCount, DrawTaskCount, AllowRepeat, Status, CreatedBy, CreatedTime)
                           VALUES (@ActivityName, @BatchNo, @DrawGroupCount, @DrawTaskCount, @AllowRepeat, @Status, @CreatedBy, @CreatedTime)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityName", activity.ActivityName),
                SQLiteHelper.CreateParameter("@BatchNo", activity.BatchNo),
                SQLiteHelper.CreateParameter("@DrawGroupCount", activity.DrawGroupCount),
                SQLiteHelper.CreateParameter("@DrawTaskCount", activity.DrawTaskCount),
                SQLiteHelper.CreateParameter("@AllowRepeat", activity.AllowRepeat),
                SQLiteHelper.CreateParameter("@Status", activity.Status),
                SQLiteHelper.CreateParameter("@CreatedBy", activity.CreatedBy),
                SQLiteHelper.CreateParameter("@CreatedTime", DateTime.Now)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                int newId = (int)SQLiteHelper.GetLastInsertId();
                // 记录日志
                _logService.Add(new SysLog
                {
                    UserId = CurrentUser.CurrentUserId,
                    ModuleName = "抽考管理",
                    OperationType = "新增",
                    OperationContent = $"创建抽考活动：{activity.ActivityName}",
                    OperationTime = DateTime.Now
                });
                return newId;
            }
            return 0;
        }

        /// <summary>
        /// 更新抽考活动
        /// </summary>
        public bool Update(ExamActivity activity)
        {
            string sql = @"UPDATE ExamActivity SET 
                           ActivityName = @ActivityName,
                           BatchNo = @BatchNo,
                           DrawGroupCount = @DrawGroupCount,
                           DrawTaskCount = @DrawTaskCount,
                           AllowRepeat = @AllowRepeat,
                           Status = @Status
                           WHERE Id = @Id";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityName", activity.ActivityName),
                SQLiteHelper.CreateParameter("@BatchNo", activity.BatchNo),
                SQLiteHelper.CreateParameter("@DrawGroupCount", activity.DrawGroupCount),
                SQLiteHelper.CreateParameter("@DrawTaskCount", activity.DrawTaskCount),
                SQLiteHelper.CreateParameter("@AllowRepeat", activity.AllowRepeat),
                SQLiteHelper.CreateParameter("@Status", activity.Status),
                SQLiteHelper.CreateParameter("@Id", activity.Id)
            };

            bool result = SQLiteHelper.ExecuteNonQuery(sql, parameters) > 0;
            if (result)
            {
                _logService.Add(new SysLog
                {
                    UserId = CurrentUser.CurrentUserId,
                    ModuleName = "抽考管理",
                    OperationType = "修改",
                    OperationContent = $"修改抽考活动：{activity.ActivityName}",
                    OperationTime = DateTime.Now
                });
            }
            return result;
        }

        /// <summary>
        /// 删除抽考活动
        /// </summary>
        public bool Delete(int id)
        {
            // 删除相关结果数据
            string deleteFinalResults = "DELETE FROM ExamActivityFinalResult WHERE ActivityId = @ActivityId";
            string deleteGroupResults = "DELETE FROM ExamActivityGroupResult WHERE ActivityId = @ActivityId";
            string deleteTaskResults = "DELETE FROM ExamActivityTaskResult WHERE ActivityId = @ActivityId";
            string deleteRules = "DELETE FROM ExamMustHitRule WHERE ActivityId = @ActivityId";

            SQLiteParameter[] param = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", id)
            };

            SQLiteHelper.ExecuteNonQuery(deleteFinalResults, param);
            SQLiteHelper.ExecuteNonQuery(deleteGroupResults, param);
            SQLiteHelper.ExecuteNonQuery(deleteTaskResults, param);
            SQLiteHelper.ExecuteNonQuery(deleteRules, param);

            string sql = "DELETE FROM ExamActivity WHERE Id = @Id";
            bool result = SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            }) > 0;

            if (result)
            {
                _logService.Add(new SysLog
                {
                    UserId = CurrentUser.CurrentUserId,
                    ModuleName = "抽考管理",
                    OperationType = "删除",
                    OperationContent = $"删除抽考活动ID：{id}",
                    OperationTime = DateTime.Now
                });
            }
            return result;
        }

        /// <summary>
        /// 获取候选指挥组
        /// </summary>
        public List<CommandGroup> GetAvailableGroups(int activityId)
        {
            var activity = GetById(activityId);
            if (activity == null)
                return new List<CommandGroup>();

            var allGroups = _groupService.GetAvailable();

            // 如果不允许重复抽取，需要排除已抽取的
            if (activity.AllowRepeat == 0)
            {
                var drawnGroups = GetGroupResults(activityId);
                var drawnGroupIds = drawnGroups.Select(g => g.GroupId).ToList();
                allGroups = allGroups.Where(g => !drawnGroupIds.Contains(g.Id)).ToList();
            }

            return allGroups;
        }

        /// <summary>
        /// 获取候选任务
        /// </summary>
        public List<TaskPlan> GetAvailableTasks(int activityId)
        {
            var activity = GetById(activityId);
            if (activity == null)
                return new List<TaskPlan>();

            var allTasks = _taskPlanService.GetAvailable();

            // 如果不允许重复抽取，需要排除已抽取的
            if (activity.AllowRepeat == 0)
            {
                var drawnTasks = GetTaskResults(activityId);
                var drawnTaskIds = drawnTasks.Select(t => t.TaskPlanId).ToList();
                allTasks = allTasks.Where(t => !drawnTaskIds.Contains(t.Id)).ToList();
            }

            return allTasks;
        }

        /// <summary>
        /// 抽取指挥组
        /// </summary>
        public List<ExamActivityGroupResult> DrawGroups(int activityId, int count)
        {
            var activity = GetById(activityId);
            if (activity == null)
                throw new Exception("抽考活动不存在");

            var availableGroups = GetAvailableGroups(activityId);
            if (availableGroups.Count < count)
                throw new Exception($"可抽取的指挥组数量不足，当前可用：{availableGroups.Count}，需要：{count}");

            var mustHitGroups = _mustHitRuleService.GetMustHitGroups(activityId);
            var results = new List<ExamActivityGroupResult>();
            var random = new Random();

            // 先处理必抽的指挥组
            int sortNo = 1;
            foreach (var mustHitGroup in mustHitGroups)
            {
                if (mustHitGroup.FixedPosition > 0)
                {
                    // 固定位置
                    results.Add(new ExamActivityGroupResult
                    {
                        ActivityId = activityId,
                        GroupId = mustHitGroup.TargetId,
                        SortNo = mustHitGroup.FixedPosition,
                        IsMustHit = 1,
                        DrawTime = DateTime.Now
                    });
                }
                else
                {
                    // 非固定位置，先记录
                    results.Add(new ExamActivityGroupResult
                    {
                        ActivityId = activityId,
                        GroupId = mustHitGroup.TargetId,
                        SortNo = 0, // 稍后分配
                        IsMustHit = 1,
                        DrawTime = DateTime.Now
                    });
                }
                // 从可用列表中移除
                availableGroups.RemoveAll(g => g.Id == mustHitGroup.TargetId);
            }

            // 随机抽取剩余的
            int remainingCount = count - results.Count;
            for (int i = 0; i < remainingCount && availableGroups.Count > 0; i++)
            {
                int index = random.Next(availableGroups.Count);
                var selectedGroup = availableGroups[index];

                results.Add(new ExamActivityGroupResult
                {
                    ActivityId = activityId,
                    GroupId = selectedGroup.Id,
                    SortNo = 0, // 稍后分配
                    IsMustHit = 0,
                    DrawTime = DateTime.Now
                });

                availableGroups.RemoveAt(index);
            }

            // 分配排序号（除了固定位置的）
            var nonFixedResults = results.Where(r => r.SortNo == 0).ToList();
            var fixedPositions = results.Where(r => r.SortNo > 0).Select(r => r.SortNo).ToList();

            foreach (var result in nonFixedResults)
            {
                while (fixedPositions.Contains(sortNo))
                {
                    sortNo++;
                }
                result.SortNo = sortNo++;
            }

            // 保存结果
            SaveGroupResults(activityId, results);

            // 记录日志
            _logService.Add(new SysLog
            {
                UserId = CurrentUser.CurrentUserId,
                ModuleName = "抽考管理",
                OperationType = "抽取",
                OperationContent = $"活动[{activity.ActivityName}]抽取指挥组，数量：{count}",
                OperationTime = DateTime.Now
            });

            return results.OrderBy(r => r.SortNo).ToList();
        }

        /// <summary>
        /// 抽取任务
        /// </summary>
        public List<ExamActivityTaskResult> DrawTasks(int activityId, int count)
        {
            var activity = GetById(activityId);
            if (activity == null)
                throw new Exception("抽考活动不存在");

            var availableTasks = GetAvailableTasks(activityId);
            if (availableTasks.Count < count)
                throw new Exception($"可抽取的任务数量不足，当前可用：{availableTasks.Count}，需要：{count}");

            var mustHitTasks = _mustHitRuleService.GetMustHitTasks(activityId);
            var results = new List<ExamActivityTaskResult>();
            var random = new Random();

            // 先处理必抽的任务
            int sortNo = 1;
            foreach (var mustHitTask in mustHitTasks)
            {
                if (mustHitTask.FixedPosition > 0)
                {
                    results.Add(new ExamActivityTaskResult
                    {
                        ActivityId = activityId,
                        TaskPlanId = mustHitTask.TargetId,
                        SortNo = mustHitTask.FixedPosition,
                        IsMustHit = 1,
                        DrawTime = DateTime.Now
                    });
                }
                else
                {
                    results.Add(new ExamActivityTaskResult
                    {
                        ActivityId = activityId,
                        TaskPlanId = mustHitTask.TargetId,
                        SortNo = 0,
                        IsMustHit = 1,
                        DrawTime = DateTime.Now
                    });
                }
                availableTasks.RemoveAll(t => t.Id == mustHitTask.TargetId);
            }

            // 随机抽取剩余的
            int remainingCount = count - results.Count;
            for (int i = 0; i < remainingCount && availableTasks.Count > 0; i++)
            {
                int index = random.Next(availableTasks.Count);
                var selectedTask = availableTasks[index];

                results.Add(new ExamActivityTaskResult
                {
                    ActivityId = activityId,
                    TaskPlanId = selectedTask.Id,
                    SortNo = 0,
                    IsMustHit = 0,
                    DrawTime = DateTime.Now
                });

                availableTasks.RemoveAt(index);
            }

            // 分配排序号
            var nonFixedResults = results.Where(r => r.SortNo == 0).ToList();
            var fixedPositions = results.Where(r => r.SortNo > 0).Select(r => r.SortNo).ToList();

            foreach (var result in nonFixedResults)
            {
                while (fixedPositions.Contains(sortNo))
                {
                    sortNo++;
                }
                result.SortNo = sortNo++;
            }

            // 保存结果
            SaveTaskResults(activityId, results);

            // 记录日志
            _logService.Add(new SysLog
            {
                UserId = CurrentUser.CurrentUserId,
                ModuleName = "抽考管理",
                OperationType = "抽取",
                OperationContent = $"活动[{activity.ActivityName}]抽取任务，数量：{count}",
                OperationTime = DateTime.Now
            });

            return results.OrderBy(r => r.SortNo).ToList();
        }

        /// <summary>
        /// 生成最终结果
        /// </summary>
        public List<ExamActivityFinalResult> GenerateFinalResult(int activityId)
        {
            var groupResults = GetGroupResults(activityId);
            var taskResults = GetTaskResults(activityId);

            if (groupResults.Count == 0 || taskResults.Count == 0)
                throw new Exception("请先完成指挥组和任务的抽取");

            if (groupResults.Count != taskResults.Count)
                throw new Exception("指挥组和任务数量不匹配");

            var finalResults = new List<ExamActivityFinalResult>();

            // 清除旧的结果
            string deleteSql = "DELETE FROM ExamActivityFinalResult WHERE ActivityId = @ActivityId";
            SQLiteHelper.ExecuteNonQuery(deleteSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId)
            });

            // 生成一对一映射
            var sortedGroups = groupResults.OrderBy(g => g.SortNo).ToList();
            var sortedTasks = taskResults.OrderBy(t => t.SortNo).ToList();

            for (int i = 0; i < sortedGroups.Count; i++)
            {
                var finalResult = new ExamActivityFinalResult
                {
                    ActivityId = activityId,
                    SortNo = i + 1,
                    GroupResultId = sortedGroups[i].Id,
                    TaskResultId = sortedTasks[i].Id,
                    CreateTime = DateTime.Now
                };

                string sql = @"INSERT INTO ExamActivityFinalResult (ActivityId, SortNo, GroupResultId, TaskResultId, CreateTime)
                               VALUES (@ActivityId, @SortNo, @GroupResultId, @TaskResultId, @CreateTime)";

                SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
                {
                    SQLiteHelper.CreateParameter("@ActivityId", finalResult.ActivityId),
                    SQLiteHelper.CreateParameter("@SortNo", finalResult.SortNo),
                    SQLiteHelper.CreateParameter("@GroupResultId", finalResult.GroupResultId),
                    SQLiteHelper.CreateParameter("@TaskResultId", finalResult.TaskResultId),
                    SQLiteHelper.CreateParameter("@CreateTime", finalResult.CreateTime)
                });

                finalResults.Add(finalResult);
            }

            // 更新活动状态为已完成
            string updateSql = "UPDATE ExamActivity SET Status = 2 WHERE Id = @Id";
            SQLiteHelper.ExecuteNonQuery(updateSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", activityId)
            });

            return finalResults;
        }

        /// <summary>
        /// 获取指挥组抽取结果
        /// </summary>
        public List<ExamActivityGroupResult> GetGroupResults(int activityId)
        {
            List<ExamActivityGroupResult> results = new List<ExamActivityGroupResult>();
            string sql = "SELECT * FROM ExamActivityGroupResult WHERE ActivityId = @ActivityId ORDER BY SortNo";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId)
            });

            foreach (DataRow row in dt.Rows)
            {
                results.Add(DataRowToGroupResult(row));
            }
            return results;
        }

        /// <summary>
        /// 获取任务抽取结果
        /// </summary>
        public List<ExamActivityTaskResult> GetTaskResults(int activityId)
        {
            List<ExamActivityTaskResult> results = new List<ExamActivityTaskResult>();
            string sql = "SELECT * FROM ExamActivityTaskResult WHERE ActivityId = @ActivityId ORDER BY SortNo";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId)
            });

            foreach (DataRow row in dt.Rows)
            {
                results.Add(DataRowToTaskResult(row));
            }
            return results;
        }

        /// <summary>
        /// 获取最终结果
        /// </summary>
        public List<ExamActivityFinalResult> GetFinalResults(int activityId)
        {
            List<ExamActivityFinalResult> results = new List<ExamActivityFinalResult>();
            string sql = "SELECT * FROM ExamActivityFinalResult WHERE ActivityId = @ActivityId ORDER BY SortNo";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId)
            });

            foreach (DataRow row in dt.Rows)
            {
                results.Add(DataRowToFinalResult(row));
            }
            return results;
        }

        /// <summary>
        /// 确认结果
        /// </summary>
        public bool ConfirmResult(int activityId)
        {
            string sql = "UPDATE ExamActivity SET Status = 2 WHERE Id = @Id";
            bool result = SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", activityId)
            }) > 0;

            if (result)
            {
                var activity = GetById(activityId);
                _logService.Add(new SysLog
                {
                    UserId = CurrentUser.CurrentUserId,
                    ModuleName = "抽考管理",
                    OperationType = "确认",
                    OperationContent = $"确认抽考活动结果：{activity?.ActivityName}",
                    OperationTime = DateTime.Now
                });
            }
            return result;
        }

        /// <summary>
        /// 保存指挥组抽取结果
        /// </summary>
        private void SaveGroupResults(int activityId, List<ExamActivityGroupResult> results)
        {
            // 清除旧的结果
            string deleteSql = "DELETE FROM ExamActivityGroupResult WHERE ActivityId = @ActivityId";
            SQLiteHelper.ExecuteNonQuery(deleteSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId)
            });

            // 插入新结果
            foreach (var result in results)
            {
                string sql = @"INSERT INTO ExamActivityGroupResult (ActivityId, GroupId, SortNo, IsMustHit, DrawTime)
                               VALUES (@ActivityId, @GroupId, @SortNo, @IsMustHit, @DrawTime)";

                SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
                {
                    SQLiteHelper.CreateParameter("@ActivityId", result.ActivityId),
                    SQLiteHelper.CreateParameter("@GroupId", result.GroupId),
                    SQLiteHelper.CreateParameter("@SortNo", result.SortNo),
                    SQLiteHelper.CreateParameter("@IsMustHit", result.IsMustHit),
                    SQLiteHelper.CreateParameter("@DrawTime", result.DrawTime)
                });
            }
        }

        /// <summary>
        /// 保存任务抽取结果
        /// </summary>
        private void SaveTaskResults(int activityId, List<ExamActivityTaskResult> results)
        {
            // 清除旧的结果
            string deleteSql = "DELETE FROM ExamActivityTaskResult WHERE ActivityId = @ActivityId";
            SQLiteHelper.ExecuteNonQuery(deleteSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId)
            });

            // 插入新结果
            foreach (var result in results)
            {
                string sql = @"INSERT INTO ExamActivityTaskResult (ActivityId, TaskPlanId, SortNo, IsMustHit, DrawTime)
                               VALUES (@ActivityId, @TaskPlanId, @SortNo, @IsMustHit, @DrawTime)";

                SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
                {
                    SQLiteHelper.CreateParameter("@ActivityId", result.ActivityId),
                    SQLiteHelper.CreateParameter("@TaskPlanId", result.TaskPlanId),
                    SQLiteHelper.CreateParameter("@SortNo", result.SortNo),
                    SQLiteHelper.CreateParameter("@IsMustHit", result.IsMustHit),
                    SQLiteHelper.CreateParameter("@DrawTime", result.DrawTime)
                });
            }
        }

        /// <summary>
        /// DataRow转换为ExamActivity
        /// </summary>
        private ExamActivity DataRowToExamActivity(DataRow row)
        {
            return new ExamActivity
            {
                Id = Convert.ToInt32(row["Id"]),
                ActivityName = row["ActivityName"].ToString(),
                BatchNo = row["BatchNo"] != DBNull.Value ? row["BatchNo"].ToString() : null,
                DrawGroupCount = Convert.ToInt32(row["DrawGroupCount"]),
                DrawTaskCount = Convert.ToInt32(row["DrawTaskCount"]),
                AllowRepeat = Convert.ToInt32(row["AllowRepeat"]),
                Status = Convert.ToInt32(row["Status"]),
                CreatedBy = row["CreatedBy"] != DBNull.Value ? row["CreatedBy"].ToString() : null,
                CreatedTime = Convert.ToDateTime(row["CreatedTime"])
            };
        }

        /// <summary>
        /// DataRow转换为ExamActivityGroupResult
        /// </summary>
        private ExamActivityGroupResult DataRowToGroupResult(DataRow row)
        {
            return new ExamActivityGroupResult
            {
                Id = Convert.ToInt32(row["Id"]),
                ActivityId = Convert.ToInt32(row["ActivityId"]),
                GroupId = Convert.ToInt32(row["GroupId"]),
                SortNo = Convert.ToInt32(row["SortNo"]),
                IsMustHit = Convert.ToInt32(row["IsMustHit"]),
                DrawTime = Convert.ToDateTime(row["DrawTime"])
            };
        }

        /// <summary>
        /// DataRow转换为ExamActivityTaskResult
        /// </summary>
        private ExamActivityTaskResult DataRowToTaskResult(DataRow row)
        {
            return new ExamActivityTaskResult
            {
                Id = Convert.ToInt32(row["Id"]),
                ActivityId = Convert.ToInt32(row["ActivityId"]),
                TaskPlanId = Convert.ToInt32(row["TaskPlanId"]),
                SortNo = Convert.ToInt32(row["SortNo"]),
                IsMustHit = Convert.ToInt32(row["IsMustHit"]),
                DrawTime = Convert.ToDateTime(row["DrawTime"])
            };
        }

        /// <summary>
        /// DataRow转换为ExamActivityFinalResult
        /// </summary>
        private ExamActivityFinalResult DataRowToFinalResult(DataRow row)
        {
            var result = new ExamActivityFinalResult
            {
                Id = Convert.ToInt32(row["Id"]),
                ActivityId = Convert.ToInt32(row["ActivityId"]),
                SortNo = Convert.ToInt32(row["SortNo"]),
                GroupResultId = Convert.ToInt32(row["GroupResultId"]),
                TaskResultId = Convert.ToInt32(row["TaskResultId"]),
                CreateTime = Convert.ToDateTime(row["CreateTime"])
            };

            if (row.Table.Columns.Contains("Content1TaskName") && row["Content1TaskName"] != DBNull.Value)
                result.Content1TaskName = Convert.ToString(row["Content1TaskName"]);
            if (row.Table.Columns.Contains("Content1CommanderName") && row["Content1CommanderName"] != DBNull.Value)
                result.Content1CommanderName = Convert.ToString(row["Content1CommanderName"]);
            if (row.Table.Columns.Contains("Content2TaskName") && row["Content2TaskName"] != DBNull.Value)
                result.Content2TaskName = Convert.ToString(row["Content2TaskName"]);
            if (row.Table.Columns.Contains("Content2CommanderName") && row["Content2CommanderName"] != DBNull.Value)
                result.Content2CommanderName = Convert.ToString(row["Content2CommanderName"]);
            if (row.Table.Columns.Contains("DrawTime") && row["DrawTime"] != DBNull.Value)
                result.DrawTime = Convert.ToDateTime(row["DrawTime"]);

            return result;
        }

        // 别名方法，用于兼容窗体代码
        public int AddActivity(ExamActivity activity) => Add(activity);
        public bool UpdateActivity(ExamActivity activity) => Update(activity);
        public List<ExamActivity> GetAllActivities() => GetAll();
        public bool DeleteActivity(int id) => Delete(id);
        public void SaveGroupResult(ExamActivityGroupResult result)
        {
            string sql = @"INSERT INTO ExamActivityGroupResult (ActivityId, GroupId, SortNo, IsMustHit, DrawTime)
                           VALUES (@ActivityId, @GroupId, @SortNo, @IsMustHit, @DrawTime)";
            SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", result.ActivityId),
                SQLiteHelper.CreateParameter("@GroupId", result.GroupId),
                SQLiteHelper.CreateParameter("@SortNo", result.SortNo),
                SQLiteHelper.CreateParameter("@IsMustHit", result.IsMustHit),
                SQLiteHelper.CreateParameter("@DrawTime", result.DrawTime)
            });
        }
        public void SaveTaskResult(ExamActivityTaskResult result)
        {
            string sql = @"INSERT INTO ExamActivityTaskResult (ActivityId, TaskPlanId, SortNo, IsMustHit, DrawTime)
                           VALUES (@ActivityId, @TaskPlanId, @SortNo, @IsMustHit, @DrawTime);
                           SELECT last_insert_rowid();";
            object resultId = SQLiteHelper.ExecuteScalar(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", result.ActivityId),
                SQLiteHelper.CreateParameter("@TaskPlanId", result.TaskPlanId),
                SQLiteHelper.CreateParameter("@SortNo", result.SortNo),
                SQLiteHelper.CreateParameter("@IsMustHit", result.IsMustHit),
                SQLiteHelper.CreateParameter("@DrawTime", result.DrawTime)
            });
            if (resultId != null && resultId != DBNull.Value)
            {
                result.Id = Convert.ToInt32(resultId);
            }
        }
        public void SaveFinalResult(ExamActivityFinalResult result)
        {
            string sql = @"INSERT INTO ExamActivityFinalResult (ActivityId, SortNo, GroupResultId, TaskResultId, Content1TaskName, Content1CommanderName, Content2TaskName, Content2CommanderName, DrawTime, CreateTime)
                           VALUES (@ActivityId, @SortNo, @GroupResultId, @TaskResultId, @Content1TaskName, @Content1CommanderName, @Content2TaskName, @Content2CommanderName, @DrawTime, @CreateTime)";
            SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", result.ActivityId),
                SQLiteHelper.CreateParameter("@SortNo", result.SortNo),
                SQLiteHelper.CreateParameter("@GroupResultId", result.GroupResultId),
                SQLiteHelper.CreateParameter("@TaskResultId", result.TaskResultId),
                SQLiteHelper.CreateParameter("@Content1TaskName", result.Content1TaskName),
                SQLiteHelper.CreateParameter("@Content1CommanderName", result.Content1CommanderName),
                SQLiteHelper.CreateParameter("@Content2TaskName", result.Content2TaskName),
                SQLiteHelper.CreateParameter("@Content2CommanderName", result.Content2CommanderName),
                SQLiteHelper.CreateParameter("@DrawTime", result.DrawTime),
                SQLiteHelper.CreateParameter("@CreateTime", result.CreateTime)
            });
        }
        public void ExportResultsToExcel(int activityId, string filePath)
        {
            // 设置 EPPlus 许可证上下文（非商业用途）
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var activity = GetById(activityId);
            var groupResults = GetGroupResults(activityId);
            var taskResults = GetTaskResults(activityId);
            var finalResults = GetFinalResults(activityId);

            using (var package = new ExcelPackage())
            {
                // 工作表1：指挥组抽取结果
                var ws1 = package.Workbook.Worksheets.Add("指挥组抽取结果");
                ws1.Cells[1, 1].Value = "序号";
                ws1.Cells[1, 2].Value = "指挥组名称";
                ws1.Cells[1, 3].Value = "是否必抽";
                ws1.Cells[1, 4].Value = "抽取时间";
                
                int row = 2;
                foreach (var result in groupResults)
                {
                    ws1.Cells[row, 1].Value = result.SortNo;
                    ws1.Cells[row, 2].Value = result.GroupName;
                    ws1.Cells[row, 3].Value = result.IsMustHit == 1 ? "是" : "否";
                    ws1.Cells[row, 4].Value = result.DrawTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }
                ws1.Cells[ws1.Dimension.Address].AutoFitColumns();

                // 工作表2：任务抽取结果
                var ws2 = package.Workbook.Worksheets.Add("任务抽取结果");
                ws2.Cells[1, 1].Value = "序号";
                ws2.Cells[1, 2].Value = "任务方案名称";
                ws2.Cells[1, 3].Value = "是否必抽";
                ws2.Cells[1, 4].Value = "抽取时间";
                
                row = 2;
                foreach (var result in taskResults)
                {
                    ws2.Cells[row, 1].Value = result.SortNo;
                    ws2.Cells[row, 2].Value = result.TaskPlanName;
                    ws2.Cells[row, 3].Value = result.IsMustHit == 1 ? "是" : "否";
                    ws2.Cells[row, 4].Value = result.DrawTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }
                ws2.Cells[ws2.Dimension.Address].AutoFitColumns();

                // 工作表3：最终结果映射
                var ws3 = package.Workbook.Worksheets.Add("最终结果映射");
                ws3.Cells[1, 1].Value = "序号";
                ws3.Cells[1, 2].Value = "指挥组";
                ws3.Cells[1, 3].Value = "任务方案";
                ws3.Cells[1, 4].Value = "生成时间";
                
                row = 2;
                foreach (var result in finalResults)
                {
                    ws3.Cells[row, 1].Value = result.SortNo;
                    ws3.Cells[row, 2].Value = result.GroupName;
                    ws3.Cells[row, 3].Value = result.TaskPlanName;
                    ws3.Cells[row, 4].Value = result.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }
                ws3.Cells[ws3.Dimension.Address].AutoFitColumns();

                package.SaveAs(new FileInfo(filePath));
            }
        }

        public void ExportResultsToWord(int activityId, string filePath)
        {
            var activity = GetById(activityId);
            var groupResults = GetGroupResults(activityId);
            var taskResults = GetTaskResults(activityId);
            var finalResults = GetFinalResults(activityId);

            using (var doc = Xceed.Words.NET.DocX.Create(filePath))
            {
                // 标题
                doc.InsertParagraph($"抽考活动结果 - {activity.ActivityName}").FontSize(20).Bold().Alignment = Xceed.Document.NET.Alignment.center;
                doc.InsertParagraph($"批次：{activity.BatchNo}").FontSize(12);
                doc.InsertParagraph($"生成时间：{DateTime.Now:yyyy-MM-dd HH:mm:ss}").FontSize(12);
                doc.InsertParagraph();

                // 指挥组抽取结果
                doc.InsertParagraph("一、指挥组抽取结果").FontSize(14).Bold();
                var table1 = doc.AddTable(groupResults.Count + 1, 4);
                table1.Rows[0].Cells[0].Paragraphs[0].Append("序号").Bold();
                table1.Rows[0].Cells[1].Paragraphs[0].Append("指挥组名称").Bold();
                table1.Rows[0].Cells[2].Paragraphs[0].Append("是否必抽").Bold();
                table1.Rows[0].Cells[3].Paragraphs[0].Append("抽取时间").Bold();
                
                int row = 1;
                foreach (var result in groupResults)
                {
                    table1.Rows[row].Cells[0].Paragraphs[0].Append(result.SortNo.ToString());
                    table1.Rows[row].Cells[1].Paragraphs[0].Append(result.GroupName);
                    table1.Rows[row].Cells[2].Paragraphs[0].Append(result.IsMustHit == 1 ? "是" : "否");
                    table1.Rows[row].Cells[3].Paragraphs[0].Append(result.DrawTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    row++;
                }
                doc.InsertTable(table1);
                doc.InsertParagraph();

                // 任务抽取结果
                doc.InsertParagraph("二、任务抽取结果").FontSize(14).Bold();
                var table2 = doc.AddTable(taskResults.Count + 1, 4);
                table2.Rows[0].Cells[0].Paragraphs[0].Append("序号").Bold();
                table2.Rows[0].Cells[1].Paragraphs[0].Append("任务方案名称").Bold();
                table2.Rows[0].Cells[2].Paragraphs[0].Append("是否必抽").Bold();
                table2.Rows[0].Cells[3].Paragraphs[0].Append("抽取时间").Bold();
                
                row = 1;
                foreach (var result in taskResults)
                {
                    table2.Rows[row].Cells[0].Paragraphs[0].Append(result.SortNo.ToString());
                    table2.Rows[row].Cells[1].Paragraphs[0].Append(result.TaskPlanName);
                    table2.Rows[row].Cells[2].Paragraphs[0].Append(result.IsMustHit == 1 ? "是" : "否");
                    table2.Rows[row].Cells[3].Paragraphs[0].Append(result.DrawTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    row++;
                }
                doc.InsertTable(table2);
                doc.InsertParagraph();

                // 最终结果映射
                doc.InsertParagraph("三、最终结果映射").FontSize(14).Bold();
                var table3 = doc.AddTable(finalResults.Count + 1, 4);
                table3.Rows[0].Cells[0].Paragraphs[0].Append("序号").Bold();
                table3.Rows[0].Cells[1].Paragraphs[0].Append("指挥组").Bold();
                table3.Rows[0].Cells[2].Paragraphs[0].Append("任务方案").Bold();
                table3.Rows[0].Cells[3].Paragraphs[0].Append("生成时间").Bold();
                
                row = 1;
                foreach (var result in finalResults)
                {
                    table3.Rows[row].Cells[0].Paragraphs[0].Append(result.SortNo.ToString());
                    table3.Rows[row].Cells[1].Paragraphs[0].Append(result.GroupName);
                    table3.Rows[row].Cells[2].Paragraphs[0].Append(result.TaskPlanName);
                    table3.Rows[row].Cells[3].Paragraphs[0].Append(result.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    row++;
                }
                doc.InsertTable(table3);

                doc.Save();
            }
        }

        public void PrintResults(int activityId)
        {
            var activity = GetById(activityId);
            var groupResults = GetGroupResults(activityId);
            var taskResults = GetTaskResults(activityId);
            var finalResults = GetFinalResults(activityId);

            // 创建打印文档
            var printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.DocumentName = $"抽考结果_{activity.ActivityName}";
            
            int currentPage = 0;
            printDoc.PrintPage += (sender, e) =>
            {
                currentPage++;
                var graphics = e.Graphics;
                var font = new System.Drawing.Font("宋体", 12);
                var fontBold = new System.Drawing.Font("宋体", 12, System.Drawing.FontStyle.Bold);
                var fontTitle = new System.Drawing.Font("宋体", 16, System.Drawing.FontStyle.Bold);
                float y = 50;
                float lineHeight = 25;
                
                // 标题
                graphics.DrawString($"抽考活动结果 - {activity.ActivityName}", fontTitle, System.Drawing.Brushes.Black, 50, y);
                y += lineHeight * 2;
                
                if (currentPage == 1)
                {
                    // 第一页：指挥组抽取结果
                    graphics.DrawString("一、指挥组抽取结果", fontBold, System.Drawing.Brushes.Black, 50, y);
                    y += lineHeight;
                    
                    graphics.DrawString("序号    指挥组名称                是否必抽    抽取时间", fontBold, System.Drawing.Brushes.Black, 50, y);
                    y += lineHeight;
                    
                    foreach (var result in groupResults)
                    {
                        graphics.DrawString($"{result.SortNo,-8}{result.GroupName,-25}{((result.IsMustHit == 1 ? "是" : "否"),-12)}{result.DrawTime:yyyy-MM-dd HH:mm:ss}", font, System.Drawing.Brushes.Black, 50, y);
                        y += lineHeight;
                    }
                    
                    y += lineHeight;
                    graphics.DrawString("二、任务抽取结果", fontBold, System.Drawing.Brushes.Black, 50, y);
                    y += lineHeight;
                    
                    graphics.DrawString("序号    任务方案名称              是否必抽    抽取时间", fontBold, System.Drawing.Brushes.Black, 50, y);
                    y += lineHeight;
                    
                    foreach (var result in taskResults)
                    {
                        graphics.DrawString($"{result.SortNo,-8}{result.TaskPlanName,-25}{((result.IsMustHit == 1 ? "是" : "否"),-12)}{result.DrawTime:yyyy-MM-dd HH:mm:ss}", font, System.Drawing.Brushes.Black, 50, y);
                        y += lineHeight;
                    }
                }
                
                // 页脚
                graphics.DrawString($"第 {currentPage} 页", font, System.Drawing.Brushes.Black, e.PageBounds.Width / 2 - 30, e.PageBounds.Height - 50);
            };
            
            // 显示打印预览对话框
            var printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            printPreviewDialog.Document = printDoc;
            printPreviewDialog.ShowDialog();
        }
    }
}
