using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using 单位抽考win7软件.Common.Entities;
using 单位抽考win7软件.DAL;

namespace 单位抽考win7软件.BLL.Services
{
    /// <summary>
    /// 单位服务类
    /// </summary>
    public class OrgUnitService
    {
        /// <summary>
        /// 根据ID获取单位
        /// </summary>
        public OrgUnit GetById(int id)
        {
            string sql = "SELECT * FROM OrgUnit WHERE Id = @Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            });

            if (dt.Rows.Count > 0)
            {
                return DataRowToOrgUnit(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 获取所有单位
        /// </summary>
        public List<OrgUnit> GetAll()
        {
            List<OrgUnit> units = new List<OrgUnit>();
            string sql = "SELECT * FROM OrgUnit WHERE Status = 1 ORDER BY UnitCode";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                units.Add(DataRowToOrgUnit(row));
            }
            return units;
        }

        /// <summary>
        /// 获取单位树形结构
        /// </summary>
        public List<OrgUnit> GetTree()
        {
            List<OrgUnit> allUnits = GetAll();
            return BuildTree(allUnits, null);
        }

        /// <summary>
        /// 构建树形结构
        /// </summary>
        private List<OrgUnit> BuildTree(List<OrgUnit> allUnits, int? parentId)
        {
            List<OrgUnit> result = new List<OrgUnit>();
            foreach (var unit in allUnits)
            {
                if (unit.ParentId == parentId)
                {
                    result.Add(unit);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取子单位
        /// </summary>
        public List<OrgUnit> GetChildren(int parentId)
        {
            List<OrgUnit> units = new List<OrgUnit>();
            string sql = "SELECT * FROM OrgUnit WHERE ParentId = @ParentId AND Status = 1 ORDER BY UnitCode";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ParentId", parentId)
            });

            foreach (DataRow row in dt.Rows)
            {
                units.Add(DataRowToOrgUnit(row));
            }
            return units;
        }

        /// <summary>
        /// 添加单位
        /// </summary>
        public int Add(OrgUnit unit)
        {
            string sql = @"INSERT INTO OrgUnit (UnitName, UnitShortName, UnitCode, ParentId, UnitType, Status, Remark, CreateTime)
                           VALUES (@UnitName, @UnitShortName, @UnitCode, @ParentId, @UnitType, @Status, @Remark, @CreateTime)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UnitName", unit.UnitName),
                SQLiteHelper.CreateParameter("@UnitShortName", unit.UnitShortName),
                SQLiteHelper.CreateParameter("@UnitCode", unit.UnitCode),
                SQLiteHelper.CreateParameter("@ParentId", unit.ParentId ?? (object)DBNull.Value),
                SQLiteHelper.CreateParameter("@UnitType", unit.UnitType),
                SQLiteHelper.CreateParameter("@Status", unit.Status),
                SQLiteHelper.CreateParameter("@Remark", unit.Remark),
                SQLiteHelper.CreateParameter("@CreateTime", DateTime.Now)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                return (int)SQLiteHelper.GetLastInsertId();
            }
            return 0;
        }

        /// <summary>
        /// 更新单位
        /// </summary>
        public bool Update(OrgUnit unit)
        {
            string sql = @"UPDATE OrgUnit SET 
                           UnitName = @UnitName,
                           UnitShortName = @UnitShortName,
                           UnitCode = @UnitCode,
                           ParentId = @ParentId,
                           UnitType = @UnitType,
                           Status = @Status,
                           Remark = @Remark
                           WHERE Id = @Id";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UnitName", unit.UnitName),
                SQLiteHelper.CreateParameter("@UnitShortName", unit.UnitShortName),
                SQLiteHelper.CreateParameter("@UnitCode", unit.UnitCode),
                SQLiteHelper.CreateParameter("@ParentId", unit.ParentId ?? (object)DBNull.Value),
                SQLiteHelper.CreateParameter("@UnitType", unit.UnitType),
                SQLiteHelper.CreateParameter("@Status", unit.Status),
                SQLiteHelper.CreateParameter("@Remark", unit.Remark),
                SQLiteHelper.CreateParameter("@Id", unit.Id)
            };

            return SQLiteHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// 删除单位（逻辑删除，级联删除所有子单位）
        /// </summary>
        public bool Delete(int id)
        {
            // 先递归删除所有子单位
            DeleteChildrenRecursive(id);

            // 逻辑删除当前单位
            string sql = "UPDATE OrgUnit SET Status = 0 WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            }) > 0;
        }

        /// <summary>
        /// 递归删除子单位
        /// </summary>
        private void DeleteChildrenRecursive(int parentId)
        {
            // 获取所有子单位
            string getChildrenSql = "SELECT Id FROM OrgUnit WHERE ParentId = @ParentId AND Status = 1";
            DataTable dt = SQLiteHelper.ExecuteDataTable(getChildrenSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@ParentId", parentId)
            });

            foreach (DataRow row in dt.Rows)
            {
                int childId = Convert.ToInt32(row["Id"]);
                // 递归删除子单位的子单位
                DeleteChildrenRecursive(childId);
                // 逻辑删除子单位
                string deleteSql = "UPDATE OrgUnit SET Status = 0 WHERE Id = @Id";
                SQLiteHelper.ExecuteNonQuery(deleteSql, new SQLiteParameter[]
                {
                    SQLiteHelper.CreateParameter("@Id", childId)
                });
            }
        }

        /// <summary>
        /// DataRow转换为OrgUnit
        /// </summary>
        private OrgUnit DataRowToOrgUnit(DataRow row)
        {
            return new OrgUnit
            {
                Id = Convert.ToInt32(row["Id"]),
                UnitName = row["UnitName"].ToString(),
                UnitShortName = row["UnitShortName"] != DBNull.Value ? row["UnitShortName"].ToString() : null,
                UnitCode = row["UnitCode"].ToString(),
                ParentId = row["ParentId"] != DBNull.Value ? (int?)Convert.ToInt32(row["ParentId"]) : null,
                UnitType = row["UnitType"] != DBNull.Value ? row["UnitType"].ToString() : null,
                Status = Convert.ToInt32(row["Status"]),
                Remark = row["Remark"] != DBNull.Value ? row["Remark"].ToString() : null,
                CreateTime = Convert.ToDateTime(row["CreateTime"])
            };
        }
    }
}
