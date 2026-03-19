using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using 单位抽考win7软件.Common.Entities;
using 单位抽考win7软件.DAL;

namespace 单位抽考win7软件.BLL.Services
{
    /// <summary>
    /// 任务方案服务类
    /// </summary>
    public class TaskPlanService
    {
        /// <summary>
        /// 根据ID获取任务方案
        /// </summary>
        public TaskPlan GetById(int id)
        {
            string sql = "SELECT * FROM TaskPlan WHERE Id = @Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            });

            if (dt.Rows.Count > 0)
            {
                return DataRowToTaskPlan(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 获取所有任务方案
        /// </summary>
        public List<TaskPlan> GetAll()
        {
            List<TaskPlan> plans = new List<TaskPlan>();
            string sql = "SELECT * FROM TaskPlan WHERE Status = 1 ORDER BY Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                plans.Add(DataRowToTaskPlan(row));
            }
            return plans;
        }

        /// <summary>
        /// 获取可抽取的任务方案
        /// </summary>
        public List<TaskPlan> GetAvailable()
        {
            List<TaskPlan> plans = new List<TaskPlan>();
            string sql = "SELECT * FROM TaskPlan WHERE Status = 1 AND CanDraw = 1 ORDER BY Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                plans.Add(DataRowToTaskPlan(row));
            }
            return plans;
        }

        /// <summary>
        /// 添加任务方案
        /// </summary>
        public int Add(TaskPlan plan)
        {
            string sql = @"INSERT INTO TaskPlan (TaskName, ExamContent, TaskType, DifficultyLevel, Status, CanDraw, Remark)
                           VALUES (@TaskName, @ExamContent, @TaskType, @DifficultyLevel, @Status, @CanDraw, @Remark)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@TaskName", plan.TaskName),
                SQLiteHelper.CreateParameter("@ExamContent", plan.ExamContent),
                SQLiteHelper.CreateParameter("@TaskType", plan.TaskType),
                SQLiteHelper.CreateParameter("@DifficultyLevel", plan.DifficultyLevel),
                SQLiteHelper.CreateParameter("@Status", plan.Status),
                SQLiteHelper.CreateParameter("@CanDraw", plan.CanDraw),
                SQLiteHelper.CreateParameter("@Remark", plan.Remark)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                return (int)SQLiteHelper.GetLastInsertId();
            }
            return 0;
        }

        /// <summary>
        /// 更新任务方案
        /// </summary>
        public bool Update(TaskPlan plan)
        {
            string sql = @"UPDATE TaskPlan SET 
                           TaskName = @TaskName,
                           ExamContent = @ExamContent,
                           TaskType = @TaskType,
                           DifficultyLevel = @DifficultyLevel,
                           Status = @Status,
                           CanDraw = @CanDraw,
                           Remark = @Remark
                           WHERE Id = @Id";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@TaskName", plan.TaskName),
                SQLiteHelper.CreateParameter("@ExamContent", plan.ExamContent),
                SQLiteHelper.CreateParameter("@TaskType", plan.TaskType),
                SQLiteHelper.CreateParameter("@DifficultyLevel", plan.DifficultyLevel),
                SQLiteHelper.CreateParameter("@Status", plan.Status),
                SQLiteHelper.CreateParameter("@CanDraw", plan.CanDraw),
                SQLiteHelper.CreateParameter("@Remark", plan.Remark),
                SQLiteHelper.CreateParameter("@Id", plan.Id)
            };

            return SQLiteHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// 删除任务方案
        /// </summary>
        public bool Delete(int id)
        {
            // 先删除任务明细
            string deleteDetailsSql = "DELETE FROM TaskPlanDetail WHERE TaskPlanId = @TaskPlanId";
            SQLiteHelper.ExecuteNonQuery(deleteDetailsSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@TaskPlanId", id)
            });

            string sql = "DELETE FROM TaskPlan WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            }) > 0;
        }

        /// <summary>
        /// 获取任务明细
        /// </summary>
        public List<TaskPlanDetail> GetDetails(int planId)
        {
            List<TaskPlanDetail> details = new List<TaskPlanDetail>();
            string sql = "SELECT * FROM TaskPlanDetail WHERE TaskPlanId = @TaskPlanId ORDER BY SortNo";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@TaskPlanId", planId)
            });

            foreach (DataRow row in dt.Rows)
            {
                details.Add(DataRowToTaskPlanDetail(row));
            }
            return details;
        }

        /// <summary>
        /// 添加明细
        /// </summary>
        public int AddDetail(TaskPlanDetail detail)
        {
            string sql = @"INSERT INTO TaskPlanDetail (TaskPlanId, UnitName, TaskDesc, SortNo)
                           VALUES (@TaskPlanId, @UnitName, @TaskDesc, @SortNo)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@TaskPlanId", detail.TaskPlanId),
                SQLiteHelper.CreateParameter("@UnitName", detail.UnitName),
                SQLiteHelper.CreateParameter("@TaskDesc", detail.TaskDesc),
                SQLiteHelper.CreateParameter("@SortNo", detail.SortNo)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                return (int)SQLiteHelper.GetLastInsertId();
            }
            return 0;
        }

        /// <summary>
        /// 移除明细
        /// </summary>
        public bool RemoveDetail(int detailId)
        {
            string sql = "DELETE FROM TaskPlanDetail WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", detailId)
            }) > 0;
        }

        /// <summary>
        /// 从Excel导入任务方案
        /// </summary>
        public int ImportFromExcel(string filePath)
        {
            int importCount = 0;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("文件不存在", filePath);
            }

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                // 从第2行开始读取（假设第1行是表头）
                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        string taskName = worksheet.Cells[row, 1].Text?.Trim();
                        string examContent = worksheet.Cells[row, 2].Text?.Trim();
                        string taskType = worksheet.Cells[row, 3].Text?.Trim();
                        string difficultyLevel = worksheet.Cells[row, 4].Text?.Trim();
                        string remark = worksheet.Cells[row, 5].Text?.Trim();

                        if (string.IsNullOrEmpty(taskName))
                            continue;

                        TaskPlan plan = new TaskPlan
                        {
                            TaskName = taskName,
                            ExamContent = examContent,
                            TaskType = taskType,
                            DifficultyLevel = difficultyLevel,
                            Status = 1,
                            CanDraw = 1,
                            Remark = remark
                        };

                        if (Add(plan) > 0)
                        {
                            importCount++;
                        }
                    }
                    catch
                    {
                        // 继续处理下一行
                        continue;
                    }
                }
            }

            return importCount;
        }

        /// <summary>
        /// 保存任务明细（先删除再添加）
        /// </summary>
        public bool SaveDetails(int taskPlanId, List<TaskPlanDetail> details)
        {
            // 先删除现有明细
            string deleteSql = "DELETE FROM TaskPlanDetail WHERE TaskPlanId = @TaskPlanId";
            SQLiteHelper.ExecuteNonQuery(deleteSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@TaskPlanId", taskPlanId)
            });

            // 添加新明细
            if (details != null && details.Count > 0)
            {
                int sortNo = 1;
                foreach (var detail in details)
                {
                    detail.TaskPlanId = taskPlanId;
                    detail.SortNo = sortNo++;
                    AddDetail(detail);
                }
            }

            return true;
        }

        /// <summary>
        /// DataRow转换为TaskPlan
        /// </summary>
        private TaskPlan DataRowToTaskPlan(DataRow row)
        {
            return new TaskPlan
            {
                Id = Convert.ToInt32(row["Id"]),
                TaskName = row["TaskName"].ToString(),
                ExamContent = row["ExamContent"] != DBNull.Value ? row["ExamContent"].ToString() : null,
                TaskType = row["TaskType"] != DBNull.Value ? row["TaskType"].ToString() : null,
                DifficultyLevel = row["DifficultyLevel"] != DBNull.Value ? row["DifficultyLevel"].ToString() : null,
                Status = Convert.ToInt32(row["Status"]),
                CanDraw = Convert.ToInt32(row["CanDraw"]),
                Remark = row["Remark"] != DBNull.Value ? row["Remark"].ToString() : null
            };
        }

        /// <summary>
        /// DataRow转换为TaskPlanDetail
        /// </summary>
        private TaskPlanDetail DataRowToTaskPlanDetail(DataRow row)
        {
            return new TaskPlanDetail
            {
                Id = Convert.ToInt32(row["Id"]),
                TaskPlanId = Convert.ToInt32(row["TaskPlanId"]),
                UnitName = row["UnitName"] != DBNull.Value ? row["UnitName"].ToString() : null,
                TaskDesc = row["TaskDesc"] != DBNull.Value ? row["TaskDesc"].ToString() : null,
                SortNo = Convert.ToInt32(row["SortNo"])
            };
        }
    }
}
