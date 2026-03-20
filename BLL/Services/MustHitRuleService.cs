using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using 单位抽考win7软件.Common.Entities;
using 单位抽考win7软件.DAL;

namespace 单位抽考win7软件.BLL.Services
{
    /// <summary>
    /// 必抽规则服务类
    /// </summary>
    public class MustHitRuleService
    {
        /// <summary>
        /// 获取所有规则
        /// </summary>
        public List<ExamMustHitRule> GetAllRules()
        {
            List<ExamMustHitRule> rules = new List<ExamMustHitRule>();
            string sql = "SELECT * FROM ExamMustHitRule ORDER BY Id DESC";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                rules.Add(DataRowToMustHitRule(row));
            }
            return rules;
        }

        /// <summary>
        /// 根据ID获取规则
        /// </summary>
        public ExamMustHitRule GetById(int id)
        {
            string sql = "SELECT * FROM ExamMustHitRule WHERE Id = @Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            });

            if (dt.Rows.Count > 0)
            {
                return DataRowToMustHitRule(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 根据活动获取规则
        /// </summary>
        public List<ExamMustHitRule> GetByActivity(int activityId)
        {
            List<ExamMustHitRule> rules = new List<ExamMustHitRule>();
            string sql = "SELECT * FROM ExamMustHitRule WHERE ActivityId = @ActivityId AND Status = 1 ORDER BY MustHitLevel, FixedPosition";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId)
            });

            foreach (DataRow row in dt.Rows)
            {
                rules.Add(DataRowToMustHitRule(row));
            }
            return rules;
        }

        /// <summary>
        /// 添加规则
        /// </summary>
        public int Add(ExamMustHitRule rule)
        {
            string sql = @"INSERT INTO ExamMustHitRule (ActivityId, TargetType, TargetId, MustHitLevel, FixedPosition, StartTime, EndTime, Status)
                           VALUES (@ActivityId, @TargetType, @TargetId, @MustHitLevel, @FixedPosition, @StartTime, @EndTime, @Status)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", rule.ActivityId),
                SQLiteHelper.CreateParameter("@TargetType", rule.TargetType),
                SQLiteHelper.CreateParameter("@TargetId", rule.TargetId),
                SQLiteHelper.CreateParameter("@MustHitLevel", rule.MustHitLevel),
                SQLiteHelper.CreateParameter("@FixedPosition", rule.FixedPosition),
                SQLiteHelper.CreateParameter("@StartTime", rule.StartTime ?? (object)DBNull.Value),
                SQLiteHelper.CreateParameter("@EndTime", rule.EndTime ?? (object)DBNull.Value),
                SQLiteHelper.CreateParameter("@Status", rule.Status)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                return (int)SQLiteHelper.GetLastInsertId();
            }
            return 0;
        }

        /// <summary>
        /// 更新规则
        /// </summary>
        public bool Update(ExamMustHitRule rule)
        {
            string sql = @"UPDATE ExamMustHitRule SET 
                           ActivityId = @ActivityId,
                           TargetType = @TargetType,
                           TargetId = @TargetId,
                           MustHitLevel = @MustHitLevel,
                           FixedPosition = @FixedPosition,
                           StartTime = @StartTime,
                           EndTime = @EndTime,
                           Status = @Status
                           WHERE Id = @Id";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", rule.ActivityId),
                SQLiteHelper.CreateParameter("@TargetType", rule.TargetType),
                SQLiteHelper.CreateParameter("@TargetId", rule.TargetId),
                SQLiteHelper.CreateParameter("@MustHitLevel", rule.MustHitLevel),
                SQLiteHelper.CreateParameter("@FixedPosition", rule.FixedPosition),
                SQLiteHelper.CreateParameter("@StartTime", rule.StartTime ?? (object)DBNull.Value),
                SQLiteHelper.CreateParameter("@EndTime", rule.EndTime ?? (object)DBNull.Value),
                SQLiteHelper.CreateParameter("@Status", rule.Status),
                SQLiteHelper.CreateParameter("@Id", rule.Id)
            };

            return SQLiteHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// 删除规则
        /// </summary>
        public bool Delete(int id)
        {
            string sql = "DELETE FROM ExamMustHitRule WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            }) > 0;
        }

        /// <summary>
        /// 获取必抽指挥组规则
        /// </summary>
        public List<ExamMustHitRule> GetMustHitGroups(int activityId)
        {
            List<ExamMustHitRule> rules = new List<ExamMustHitRule>();
            string sql = @"SELECT * FROM ExamMustHitRule 
                           WHERE ActivityId = @ActivityId 
                           AND TargetType = 'Group' 
                           AND Status = 1
                           AND (StartTime IS NULL OR StartTime <= @Now)
                           AND (EndTime IS NULL OR EndTime >= @Now)
                           ORDER BY MustHitLevel, FixedPosition";

            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId),
                SQLiteHelper.CreateParameter("@Now", DateTime.Now)
            });

            foreach (DataRow row in dt.Rows)
            {
                rules.Add(DataRowToMustHitRule(row));
            }
            return rules;
        }

        /// <summary>
        /// 获取必抽任务规则
        /// </summary>
        public List<ExamMustHitRule> GetMustHitTasks(int activityId)
        {
            List<ExamMustHitRule> rules = new List<ExamMustHitRule>();
            string sql = @"SELECT * FROM ExamMustHitRule 
                           WHERE ActivityId = @ActivityId 
                           AND TargetType = 'Task' 
                           AND Status = 1
                           AND (StartTime IS NULL OR StartTime <= @Now)
                           AND (EndTime IS NULL OR EndTime >= @Now)
                           ORDER BY MustHitLevel, FixedPosition";

            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ActivityId", activityId),
                SQLiteHelper.CreateParameter("@Now", DateTime.Now)
            });

            foreach (DataRow row in dt.Rows)
            {
                rules.Add(DataRowToMustHitRule(row));
            }
            return rules;
        }

        /// <summary>
        /// DataRow转换为ExamMustHitRule
        /// </summary>
        private ExamMustHitRule DataRowToMustHitRule(DataRow row)
        {
            return new ExamMustHitRule
            {
                Id = Convert.ToInt32(row["Id"]),
                ActivityId = Convert.ToInt32(row["ActivityId"]),
                TargetType = row["TargetType"].ToString(),
                TargetId = Convert.ToInt32(row["TargetId"]),
                MustHitLevel = Convert.ToInt32(row["MustHitLevel"]),
                FixedPosition = Convert.ToInt32(row["FixedPosition"]),
                StartTime = row["StartTime"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["StartTime"]) : null,
                EndTime = row["EndTime"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["EndTime"]) : null,
                Status = Convert.ToInt32(row["Status"])
            };
        }
    }
}
