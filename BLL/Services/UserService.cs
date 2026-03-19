using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using 单位抽考win7软件.Common.Entities;
using 单位抽考win7软件.DAL;

namespace 单位抽考win7软件.BLL.Services
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// SHA256加密密码
        /// </summary>
        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        public SysUser Login(string username, string password)
        {
            string encryptedPassword = EncryptPassword(password);
            string sql = "SELECT * FROM SysUser WHERE UserName = @UserName AND Password = @Password AND Status = 1";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UserName", username),
                SQLiteHelper.CreateParameter("@Password", encryptedPassword)
            };

            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                SysUser user = DataRowToUser(dt.Rows[0]);
                // 更新最后登录时间
                string updateSql = "UPDATE SysUser SET LastLoginTime = @LastLoginTime WHERE Id = @Id";
                SQLiteHelper.ExecuteNonQuery(updateSql, new SQLiteParameter[]
                {
                    SQLiteHelper.CreateParameter("@LastLoginTime", DateTime.Now),
                    SQLiteHelper.CreateParameter("@Id", user.Id)
                });
                return user;
            }
            return null;
        }

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        public SysUser GetById(int id)
        {
            string sql = "SELECT * FROM SysUser WHERE Id = @Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            });

            if (dt.Rows.Count > 0)
            {
                return DataRowToUser(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public List<SysUser> GetAll()
        {
            List<SysUser> users = new List<SysUser>();
            string sql = "SELECT * FROM SysUser ORDER BY Id";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                users.Add(DataRowToUser(row));
            }
            return users;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        public int Add(SysUser user)
        {
            string sql = @"INSERT INTO SysUser (UserName, Password, RealName, Phone, Email, Status, CreateTime, LastLoginTime)
                           VALUES (@UserName, @Password, @RealName, @Phone, @Email, @Status, @CreateTime, @LastLoginTime)";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UserName", user.UserName),
                SQLiteHelper.CreateParameter("@Password", EncryptPassword(user.Password)),
                SQLiteHelper.CreateParameter("@RealName", user.RealName),
                SQLiteHelper.CreateParameter("@Phone", user.Phone),
                SQLiteHelper.CreateParameter("@Email", user.Email),
                SQLiteHelper.CreateParameter("@Status", user.Status),
                SQLiteHelper.CreateParameter("@CreateTime", DateTime.Now),
                SQLiteHelper.CreateParameter("@LastLoginTime", DBNull.Value)
            };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);
            if (result > 0)
            {
                return (int)SQLiteHelper.GetLastInsertId();
            }
            return 0;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        public bool Update(SysUser user)
        {
            string sql = @"UPDATE SysUser SET 
                           UserName = @UserName,
                           RealName = @RealName,
                           Phone = @Phone,
                           Email = @Email,
                           Status = @Status
                           WHERE Id = @Id";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UserName", user.UserName),
                SQLiteHelper.CreateParameter("@RealName", user.RealName),
                SQLiteHelper.CreateParameter("@Phone", user.Phone),
                SQLiteHelper.CreateParameter("@Email", user.Email),
                SQLiteHelper.CreateParameter("@Status", user.Status),
                SQLiteHelper.CreateParameter("@Id", user.Id)
            };

            return SQLiteHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public bool Delete(int id)
        {
            // 先删除用户角色关系
            string deleteRolesSql = "DELETE FROM SysUserRole WHERE UserId = @UserId";
            SQLiteHelper.ExecuteNonQuery(deleteRolesSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UserId", id)
            });

            string sql = "DELETE FROM SysUser WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", id)
            }) > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            // 验证旧密码
            string encryptedOldPassword = EncryptPassword(oldPassword);
            string checkSql = "SELECT COUNT(*) FROM SysUser WHERE Id = @Id AND Password = @Password";
            object result = SQLiteHelper.ExecuteScalar(checkSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Id", userId),
                SQLiteHelper.CreateParameter("@Password", encryptedOldPassword)
            });

            if (Convert.ToInt32(result) == 0)
            {
                return false; // 旧密码不正确
            }

            // 更新新密码
            string encryptedNewPassword = EncryptPassword(newPassword);
            string updateSql = "UPDATE SysUser SET Password = @Password WHERE Id = @Id";
            return SQLiteHelper.ExecuteNonQuery(updateSql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@Password", encryptedNewPassword),
                SQLiteHelper.CreateParameter("@Id", userId)
            }) > 0;
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        public List<string> GetUserRoles(int userId)
        {
            List<string> roles = new List<string>();
            string sql = @"SELECT r.RoleCode FROM SysRole r
                           INNER JOIN SysUserRole ur ON r.Id = ur.RoleId
                           WHERE ur.UserId = @UserId AND r.Status = 1";

            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, new SQLiteParameter[]
            {
                SQLiteHelper.CreateParameter("@UserId", userId)
            });

            foreach (DataRow row in dt.Rows)
            {
                roles.Add(row["RoleCode"].ToString());
            }
            return roles;
        }

        /// <summary>
        /// DataRow转换为SysUser
        /// </summary>
        private SysUser DataRowToUser(DataRow row)
        {
            return new SysUser
            {
                Id = Convert.ToInt32(row["Id"]),
                UserName = row["UserName"].ToString(),
                Password = row["Password"].ToString(),
                RealName = row["RealName"].ToString(),
                Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : null,
                Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null,
                Status = Convert.ToInt32(row["Status"]),
                CreateTime = Convert.ToDateTime(row["CreateTime"]),
                LastLoginTime = row["LastLoginTime"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["LastLoginTime"]) : null
            };
        }
    }
}
