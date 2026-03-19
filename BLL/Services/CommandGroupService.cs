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
    /// 指挥组服务类
    /// </summary>
    public class CommandGroupService
    {
        /// <summary>
        /// 根据ID获取指挥组
        /// </summary>
        public CommandGroup GetById(int id)
        {
            string sql = "SELECT * FROM CommandGroup WHERE Id = @Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            });

            if (dt.Rows.Count > 0)
            {
                return DataRowToCommandGroup(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 获取所有指挥组
        /// </summary>
        public List<CommandGroup> GetAll()
        {
            List<CommandGroup> groups = new List<CommandGroup>();
            string sql = "SELECT * FROM CommandGroup WHERE Status = 1 ORDER BY Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                groups.Add(DataRowToCommandGroup(row));
            }
            return groups;
        }

        /// <summary>
        /// 根据单位获取指挥组
        /// </summary>
        public List<CommandGroup> GetByUnit(int unitId)
        {
            List<CommandGroup> groups = new List<CommandGroup>();
            string sql = "SELECT * FROM CommandGroup WHERE UnitId = @UnitId AND Status = 1 ORDER BY Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UnitId", unitId)
            });

            foreach (DataRow row in dt.Rows)
            {
                groups.Add(DataRowToCommandGroup(row));
            }
            return groups;
        }

        /// <summary>
        /// 获取可抽取的指挥组
        /// </summary>
        public List<CommandGroup> GetAvailable()
        {
            List<CommandGroup> groups = new List<CommandGroup>();
            string sql = "SELECT * FROM CommandGroup WHERE Status = 1 AND CanDraw = 1 ORDER BY Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                groups.Add(DataRowToCommandGroup(row));
            }
            return groups;
        }

        /// <summary>
        /// 添加指挥组
        /// </summary>
        public int Add(CommandGroup group)
        {
            string sql = @"INSERT INTO CommandGroup (GroupName, UnitId, GroupNo, Status, CanDraw, Remark, CreateTime)
                           VALUES (@GroupName, @UnitId, @GroupNo, @Status, @CanDraw, @Remark, @CreateTime)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@GroupName", group.GroupName),
                SQLiteHelper.CreateParameter("@UnitId", group.UnitId),
                SQLiteHelper.CreateParameter("@GroupNo", group.GroupNo),
                SQLiteHelper.CreateParameter("@Status", group.Status),
                SQLiteHelper.CreateParameter("@CanDraw", group.CanDraw),
                SQLiteHelper.CreateParameter("@Remark", group.Remark),
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
        /// 更新指挥组
        /// </summary>
        public bool Update(CommandGroup group)
        {
            string sql = @"UPDATE CommandGroup SET 
                           GroupName = @GroupName,
                           UnitId = @UnitId,
                           GroupNo = @GroupNo,
                           Status = @Status,
                           CanDraw = @CanDraw,
                           Remark = @Remark
                           WHERE Id = @Id";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@GroupName", group.GroupName),
                SQLiteHelper.CreateParameter("@UnitId", group.UnitId),
                SQLiteHelper.CreateParameter("@GroupNo", group.GroupNo),
                SQLiteHelper.CreateParameter("@Status", group.Status),
                SQLiteHelper.CreateParameter("@CanDraw", group.CanDraw),
                SQLiteHelper.CreateParameter("@Remark", group.Remark),
                SQLiteHelper.CreateParameter("@Id", group.Id)
            };

            return SQLiteHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// 删除指挥组
        /// </summary>
        public bool Delete(int id)
        {
            // 先删除指挥组成员
            string deleteMembersSql = "DELETE FROM CommandGroupMember WHERE GroupId = @GroupId";
            SQLiteHelper.ExecuteNonQuery(deleteMembersSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@GroupId", id)
            });

            string sql = "DELETE FROM CommandGroup WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            }) > 0;
        }

        /// <summary>
        /// 复制指挥组
        /// </summary>
        public int Copy(int groupId)
        {
            // 获取原指挥组信息
            CommandGroup originalGroup = GetById(groupId);
            if (originalGroup == null)
                return 0;

            // 创建新指挥组
            CommandGroup newGroup = new CommandGroup
            {
                GroupName = originalGroup.GroupName + "_副本",
                UnitId = originalGroup.UnitId,
                GroupNo = originalGroup.GroupNo + "_COPY",
                Status = originalGroup.Status,
                CanDraw = originalGroup.CanDraw,
                Remark = originalGroup.Remark
            };

            int newGroupId = Add(newGroup);
            if (newGroupId > 0)
            {
                // 复制成员
                List<CommandGroupMember> members = GetMembers(groupId);
                foreach (var member in members)
                {
                    CommandGroupMember newMember = new CommandGroupMember
                    {
                        GroupId = newGroupId,
                        PersonId = member.PersonId,
                        MemberRole = member.MemberRole,
                        SortNo = member.SortNo,
                        Remark = member.Remark
                    };
                    AddMember(newMember);
                }
            }

            return newGroupId;
        }

        /// <summary>
        /// 获取指挥组成员
        /// </summary>
        public List<CommandGroupMember> GetMembers(int groupId)
        {
            List<CommandGroupMember> members = new List<CommandGroupMember>();
            string sql = "SELECT * FROM CommandGroupMember WHERE GroupId = @GroupId ORDER BY SortNo";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@GroupId", groupId)
            });

            foreach (DataRow row in dt.Rows)
            {
                members.Add(DataRowToCommandGroupMember(row));
            }
            return members;
        }

        /// <summary>
        /// 添加成员
        /// </summary>
        public int AddMember(CommandGroupMember member)
        {
            string sql = @"INSERT INTO CommandGroupMember (GroupId, PersonId, MemberRole, SortNo, Remark)
                           VALUES (@GroupId, @PersonId, @MemberRole, @SortNo, @Remark)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@GroupId", member.GroupId),
                SQLiteHelper.CreateParameter("@PersonId", member.PersonId),
                SQLiteHelper.CreateParameter("@MemberRole", member.MemberRole),
                SQLiteHelper.CreateParameter("@SortNo", member.SortNo),
                SQLiteHelper.CreateParameter("@Remark", member.Remark)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                return (int)SQLiteHelper.GetLastInsertId();
            }
            return 0;
        }

        /// <summary>
        /// 移除成员
        /// </summary>
        public bool RemoveMember(int memberId)
        {
            string sql = "DELETE FROM CommandGroupMember WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", memberId)
            }) > 0;
        }

        /// <summary>
        /// 从Excel导入指挥组
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
                        string groupName = worksheet.Cells[row, 1].Text?.Trim();
                        string unitName = worksheet.Cells[row, 2].Text?.Trim();
                        string groupNo = worksheet.Cells[row, 3].Text?.Trim();
                        string remark = worksheet.Cells[row, 4].Text?.Trim();

                        if (string.IsNullOrEmpty(groupName))
                            continue;

                        // 根据单位名称查找单位ID
                        int? unitId = GetUnitIdByName(unitName);

                        CommandGroup group = new CommandGroup
                        {
                            GroupName = groupName,
                            UnitId = unitId ?? 0,
                            GroupNo = groupNo,
                            Status = 1,
                            CanDraw = 1,
                            Remark = remark
                        };

                        if (Add(group) > 0)
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
        /// 根据单位名称获取单位ID
        /// </summary>
        private int? GetUnitIdByName(string unitName)
        {
            if (string.IsNullOrEmpty(unitName))
                return null;

            string sql = "SELECT Id FROM OrgUnit WHERE UnitName = @UnitName AND Status = 1";
            object result = SQLiteHelper.ExecuteScalar(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UnitName", unitName)
            });

            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return null;
        }

        /// <summary>
        /// DataRow转换为CommandGroup
        /// </summary>
        private CommandGroup DataRowToCommandGroup(DataRow row)
        {
            return new CommandGroup
            {
                Id = Convert.ToInt32(row["Id"]),
                GroupName = row["GroupName"].ToString(),
                UnitId = Convert.ToInt32(row["UnitId"]),
                GroupNo = row["GroupNo"] != DBNull.Value ? row["GroupNo"].ToString() : null,
                Status = Convert.ToInt32(row["Status"]),
                CanDraw = Convert.ToInt32(row["CanDraw"]),
                Remark = row["Remark"] != DBNull.Value ? row["Remark"].ToString() : null,
                CreateTime = Convert.ToDateTime(row["CreateTime"])
            };
        }

        /// <summary>
        /// DataRow转换为CommandGroupMember
        /// </summary>
        private CommandGroupMember DataRowToCommandGroupMember(DataRow row)
        {
            return new CommandGroupMember
            {
                Id = Convert.ToInt32(row["Id"]),
                GroupId = Convert.ToInt32(row["GroupId"]),
                PersonId = Convert.ToInt32(row["PersonId"]),
                MemberRole = row["MemberRole"] != DBNull.Value ? row["MemberRole"].ToString() : null,
                SortNo = Convert.ToInt32(row["SortNo"]),
                Remark = row["Remark"] != DBNull.Value ? row["Remark"].ToString() : null
            };
        }

        /// <summary>
        /// 根据单位获取指挥组（别名方法）
        /// </summary>
        public List<CommandGroup> GetByOrgUnit(int orgUnitId)
        {
            return GetByUnit(orgUnitId);
        }

        /// <summary>
        /// 保存指挥组成员（先删除再添加）
        /// </summary>
        public bool SaveMembers(int groupId, List<CommandGroupMember> members)
        {
            // 先删除现有成员
            string deleteSql = "DELETE FROM CommandGroupMember WHERE GroupId = @GroupId";
            SQLiteHelper.ExecuteNonQuery(deleteSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@GroupId", groupId)
            });

            // 添加新成员
            if (members != null && members.Count > 0)
            {
                foreach (var member in members)
                {
                    member.GroupId = groupId;
                    AddMember(member);
                }
            }

            return true;
        }

        /// <summary>
        /// 获取可抽取的指挥组（别名方法）
        /// </summary>
        public List<CommandGroup> GetDrawableGroups()
        {
            return GetAvailable();
        }
    }
}
