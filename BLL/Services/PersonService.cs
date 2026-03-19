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
    /// 人员服务类
    /// </summary>
    public class PersonService
    {
        /// <summary>
        /// 根据ID获取人员
        /// </summary>
        public Person GetById(int id)
        {
            string sql = "SELECT * FROM Person WHERE Id = @Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            });

            if (dt.Rows.Count > 0)
            {
                return DataRowToPerson(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 获取所有人员
        /// </summary>
        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            string sql = "SELECT * FROM Person WHERE Status = 1 ORDER BY Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                persons.Add(DataRowToPerson(row));
            }
            return persons;
        }

        /// <summary>
        /// 根据单位获取人员
        /// </summary>
        public List<Person> GetByUnit(int unitId)
        {
            List<Person> persons = new List<Person>();
            string sql = "SELECT * FROM Person WHERE UnitId = @UnitId AND Status = 1 ORDER BY Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UnitId", unitId)
            });

            foreach (DataRow row in dt.Rows)
            {
                persons.Add(DataRowToPerson(row));
            }
            return persons;
        }

        /// <summary>
        /// 根据单位获取人员（别名方法）
        /// </summary>
        public List<Person> GetByOrgUnit(int unitId)
        {
            return GetByUnit(unitId);
        }

        /// <summary>
        /// 添加人员
        /// </summary>
        public int Add(Person person)
        {
            string sql = @"INSERT INTO Person (Name, Gender, UnitId, PostName, RoleType, Phone, Status, Remark)
                           VALUES (@Name, @Gender, @UnitId, @PostName, @RoleType, @Phone, @Status, @Remark)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Name", person.Name),
                SQLiteHelper.CreateParameter("@Gender", person.Gender),
                SQLiteHelper.CreateParameter("@UnitId", person.UnitId),
                SQLiteHelper.CreateParameter("@PostName", person.PostName),
                SQLiteHelper.CreateParameter("@RoleType", person.RoleType),
                SQLiteHelper.CreateParameter("@Phone", person.Phone),
                SQLiteHelper.CreateParameter("@Status", person.Status),
                SQLiteHelper.CreateParameter("@Remark", person.Remark)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                return (int)SQLiteHelper.GetLastInsertId();
            }
            return 0;
        }

        /// <summary>
        /// 更新人员
        /// </summary>
        public bool Update(Person person)
        {
            string sql = @"UPDATE Person SET 
                           Name = @Name,
                           Gender = @Gender,
                           UnitId = @UnitId,
                           PostName = @PostName,
                           RoleType = @RoleType,
                           Phone = @Phone,
                           Status = @Status,
                           Remark = @Remark
                           WHERE Id = @Id";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Name", person.Name),
                SQLiteHelper.CreateParameter("@Gender", person.Gender),
                SQLiteHelper.CreateParameter("@UnitId", person.UnitId),
                SQLiteHelper.CreateParameter("@PostName", person.PostName),
                SQLiteHelper.CreateParameter("@RoleType", person.RoleType),
                SQLiteHelper.CreateParameter("@Phone", person.Phone),
                SQLiteHelper.CreateParameter("@Status", person.Status),
                SQLiteHelper.CreateParameter("@Remark", person.Remark),
                SQLiteHelper.CreateParameter("@Id", person.Id)
            };

            return SQLiteHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        public bool Delete(int id)
        {
            string sql = "DELETE FROM Person WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            }) > 0;
        }

        /// <summary>
        /// 从Excel导入人员
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
                        string name = worksheet.Cells[row, 1].Text?.Trim();
                        string gender = worksheet.Cells[row, 2].Text?.Trim();
                        string unitName = worksheet.Cells[row, 3].Text?.Trim();
                        string postName = worksheet.Cells[row, 4].Text?.Trim();
                        string roleType = worksheet.Cells[row, 5].Text?.Trim();
                        string phone = worksheet.Cells[row, 6].Text?.Trim();
                        string remark = worksheet.Cells[row, 7].Text?.Trim();

                        if (string.IsNullOrEmpty(name))
                            continue;

                        // 根据单位名称查找单位ID
                        int? unitId = GetUnitIdByName(unitName);

                        Person person = new Person
                        {
                            Name = name,
                            Gender = gender,
                            UnitId = unitId ?? 0,
                            PostName = postName,
                            RoleType = roleType,
                            Phone = phone,
                            Status = 1,
                            Remark = remark
                        };

                        if (Add(person) > 0)
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
        /// DataRow转换为Person
        /// </summary>
        private Person DataRowToPerson(DataRow row)
        {
            return new Person
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"].ToString(),
                Gender = row["Gender"] != DBNull.Value ? row["Gender"].ToString() : null,
                UnitId = Convert.ToInt32(row["UnitId"]),
                PostName = row["PostName"] != DBNull.Value ? row["PostName"].ToString() : null,
                RoleType = row["RoleType"] != DBNull.Value ? row["RoleType"].ToString() : null,
                Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : null,
                Status = Convert.ToInt32(row["Status"]),
                Remark = row["Remark"] != DBNull.Value ? row["Remark"].ToString() : null
            };
        }
    }
}
