using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using 单位抽考win7软件.Common.Entities;
using 单位抽考win7软件.DAL;

namespace 单位抽考win7软件.BLL.Services
{
    /// <summary>
    /// 日志服务类
    /// </summary>
    public class LogService
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        public int Add(SysLog log)
        {
            string sql = @"INSERT INTO SysLog (UserId, ModuleName, OperationType, OperationContent, OperationTime)
                           VALUES (@UserId, @ModuleName, @OperationType, @OperationContent, @OperationTime)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UserId", log.UserId),
                SQLiteHelper.CreateParameter("@ModuleName", log.ModuleName),
                SQLiteHelper.CreateParameter("@OperationType", log.OperationType),
                SQLiteHelper.CreateParameter("@OperationContent", log.OperationContent),
                SQLiteHelper.CreateParameter("@OperationTime", log.OperationTime)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                return (int)SQLiteHelper.GetLastInsertId();
            }
            return 0;
        }

        /// <summary>
        /// 获取所有日志
        /// </summary>
        public List<SysLog> GetAll()
        {
            List<SysLog> logs = new List<SysLog>();
            string sql = "SELECT * FROM SysLog ORDER BY OperationTime DESC";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                logs.Add(DataRowToSysLog(row));
            }
            return logs;
        }

        /// <summary>
        /// 根据用户获取日志
        /// </summary>
        public List<SysLog> GetByUser(int userId)
        {
            List<SysLog> logs = new List<SysLog>();
            string sql = "SELECT * FROM SysLog WHERE UserId = @UserId ORDER BY OperationTime DESC";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UserId", userId)
            });

            foreach (DataRow row in dt.Rows)
            {
                logs.Add(DataRowToSysLog(row));
            }
            return logs;
        }

        /// <summary>
        /// 根据模块获取日志
        /// </summary>
        public List<SysLog> GetByModule(string moduleName)
        {
            List<SysLog> logs = new List<SysLog>();
            string sql = "SELECT * FROM SysLog WHERE ModuleName = @ModuleName ORDER BY OperationTime DESC";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ModuleName", moduleName)
            });

            foreach (DataRow row in dt.Rows)
            {
                logs.Add(DataRowToSysLog(row));
            }
            return logs;
        }

        /// <summary>
        /// 根据日期范围获取日志
        /// </summary>
        public List<SysLog> GetByDateRange(DateTime start, DateTime end)
        {
            List<SysLog> logs = new List<SysLog>();
            string sql = "SELECT * FROM SysLog WHERE OperationTime >= @Start AND OperationTime <= @End ORDER BY OperationTime DESC";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Start", start),
                SQLiteHelper.CreateParameter("@End", end)
            });

            foreach (DataRow row in dt.Rows)
            {
                logs.Add(DataRowToSysLog(row));
            }
            return logs;
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        public bool Clear()
        {
            string sql = "DELETE FROM SysLog";
            return SQLiteHelper.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 清空所有日志（别名方法）
        /// </summary>
        public bool ClearAll()
        {
            return Clear();
        }

        /// <summary>
        /// 查询日志（支持多条件筛选）
        /// </summary>
        public List<SysLog> QueryLogs(string moduleName, string operationType, string userName, DateTime? startTime, DateTime? endTime)
        {
            List<SysLog> logs = new List<SysLog>();
            List<string> conditions = new List<string>();
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();

            // 模块筛选
            if (!string.IsNullOrEmpty(moduleName))
            {
                conditions.Add("ModuleName = @ModuleName");
                parameters.Add(SQLiteHelper.CreateParameter("@ModuleName", moduleName));
            }

            // 操作类型筛选
            if (!string.IsNullOrEmpty(operationType))
            {
                conditions.Add("OperationType = @OperationType");
                parameters.Add(SQLiteHelper.CreateParameter("@OperationType", operationType));
            }

            // 用户筛选（通过用户名查找用户ID）
            if (!string.IsNullOrEmpty(userName))
            {
                conditions.Add("UserId IN (SELECT Id FROM SysUser WHERE UserName = @UserName)");
                parameters.Add(SQLiteHelper.CreateParameter("@UserName", userName));
            }

            // 时间范围筛选
            if (startTime.HasValue)
            {
                conditions.Add("OperationTime >= @StartTime");
                parameters.Add(SQLiteHelper.CreateParameter("@StartTime", startTime.Value));
            }

            if (endTime.HasValue)
            {
                conditions.Add("OperationTime <= @EndTime");
                parameters.Add(SQLiteHelper.CreateParameter("@EndTime", endTime.Value));
            }

            // 构建SQL（联表查询获取用户名）
            string sql = @"SELECT l.*, u.UserName 
                           FROM SysLog l 
                           LEFT JOIN SysUser u ON l.UserId = u.Id";
            if (conditions.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", conditions).Replace("UserId", "l.UserId").Replace("ModuleName", "l.ModuleName").Replace("OperationType", "l.OperationType").Replace("OperationTime", "l.OperationTime");
            }
            sql += " ORDER BY l.OperationTime DESC";

            DataTable dt;
            if (parameters.Count > 0)
            {
                dt = SQLiteHelper.ExecuteDataTable(sql, parameters.ToArray());
            }
            else
            {
                dt = SQLiteHelper.ExecuteDataTable(sql);
            }

            foreach (DataRow row in dt.Rows)
            {
                logs.Add(DataRowToSysLogWithUserName(row));
            }
            return logs;
        }

        /// <summary>
        /// 添加日志（静态便捷方法）
        /// </summary>
        public static void AddLog(string moduleName, string operationType, string operationContent)
        {
            var log = new SysLog
            {
                UserId = CurrentUser.CurrentUserId,
                ModuleName = moduleName,
                OperationType = operationType,
                OperationContent = operationContent,
                OperationTime = DateTime.Now
            };

            var service = new LogService();
            service.Add(log);
        }

        /// <summary>
        /// DataRow转换为SysLog
        /// </summary>
        private SysLog DataRowToSysLog(DataRow row)
        {
            return new SysLog
            {
                Id = Convert.ToInt32(row["Id"]),
                UserId = Convert.ToInt32(row["UserId"]),
                ModuleName = row["ModuleName"].ToString(),
                OperationType = row["OperationType"].ToString(),
                OperationContent = row["OperationContent"] != DBNull.Value ? row["OperationContent"].ToString() : null,
                OperationTime = Convert.ToDateTime(row["OperationTime"])
            };
        }

        /// <summary>
        /// DataRow转换为SysLog（包含用户名）
        /// </summary>
        private SysLog DataRowToSysLogWithUserName(DataRow row)
        {
            var log = DataRowToSysLog(row);
            // 添加用户名属性到扩展字段
            if (row.Table.Columns.Contains("UserName") && row["UserName"] != DBNull.Value)
            {
                log.UserName = row["UserName"].ToString();
            }
            else
            {
                log.UserName = $"用户({log.UserId})";
            }
            return log;
        }
    }
}
