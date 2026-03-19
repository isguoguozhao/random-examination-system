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
    }
}
