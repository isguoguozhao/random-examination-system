using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace 单位抽考win7软件.DAL
{
    public class DatabaseInitializer
    {
        private static string GetDatabasePath()
        {
            return Path.Combine(Application.StartupPath, "data", "exam.db");
        }

        public static bool DatabaseExists()
        {
            string dbPath = GetDatabasePath();
            return File.Exists(dbPath);
        }

        public static void Initialize()
        {
            try
            {
                string dbPath = GetDatabasePath();
                string dataDir = Path.Combine(Application.StartupPath, "data");

                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                if (!File.Exists(dbPath))
                {
                    SQLiteConnection.CreateFile(dbPath);
                }

                CreateTables();
                InsertDefaultData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据库初始化失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static void CreateTables()
        {
            string[] createTableSqls = new string[]
            {
                // 1. 角色表 SysRole
                @"CREATE TABLE IF NOT EXISTS SysRole (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoleName VARCHAR(100) NOT NULL,
                    RoleCode VARCHAR(50) NOT NULL UNIQUE,
                    Description VARCHAR(500),
                    Status INTEGER DEFAULT 1,
                    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP
                )",

                // 2. 用户表 SysUser
                @"CREATE TABLE IF NOT EXISTS SysUser (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName VARCHAR(100) NOT NULL UNIQUE,
                    Password VARCHAR(255) NOT NULL,
                    RealName VARCHAR(100),
                    Phone VARCHAR(50),
                    Email VARCHAR(100),
                    Status INTEGER DEFAULT 1,
                    LastLoginTime DATETIME,
                    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP
                )",

                // 3. 用户角色关系表 SysUserRole
                @"CREATE TABLE IF NOT EXISTS SysUserRole (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    RoleId INTEGER NOT NULL,
                    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (UserId) REFERENCES SysUser(Id),
                    FOREIGN KEY (RoleId) REFERENCES SysRole(Id)
                )",

                // 4. 单位表 OrgUnit
                @"CREATE TABLE IF NOT EXISTS OrgUnit (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UnitName VARCHAR(200) NOT NULL,
                    UnitShortName VARCHAR(100),
                    UnitCode VARCHAR(50),
                    ParentId INTEGER DEFAULT 0,
                    UnitType VARCHAR(50),
                    Status INTEGER DEFAULT 1,
                    Remark VARCHAR(500),
                    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP
                )",

                // 5. 人员表 Person
                @"CREATE TABLE IF NOT EXISTS Person (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name VARCHAR(100) NOT NULL,
                    Gender VARCHAR(10),
                    UnitId INTEGER,
                    PostName VARCHAR(100),
                    RoleType VARCHAR(50),
                    Phone VARCHAR(50),
                    Status INTEGER DEFAULT 1,
                    Remark VARCHAR(500),
                    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (UnitId) REFERENCES OrgUnit(Id)
                )",

                // 6. 指挥组表 CommandGroup
                @"CREATE TABLE IF NOT EXISTS CommandGroup (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    GroupName VARCHAR(200) NOT NULL,
                    UnitId INTEGER,
                    GroupNo VARCHAR(50),
                    Status INTEGER DEFAULT 1,
                    CanDraw INTEGER DEFAULT 1,
                    Remark VARCHAR(500),
                    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (UnitId) REFERENCES OrgUnit(Id)
                )",

                // 7. 指挥组成员表 CommandGroupMember
                @"CREATE TABLE IF NOT EXISTS CommandGroupMember (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    GroupId INTEGER NOT NULL,
                    PersonId INTEGER NOT NULL,
                    MemberRole VARCHAR(50),
                    SortNo INTEGER DEFAULT 0,
                    Remark VARCHAR(500),
                    FOREIGN KEY (GroupId) REFERENCES CommandGroup(Id),
                    FOREIGN KEY (PersonId) REFERENCES Person(Id)
                )",

                // 8. 任务方案表 TaskPlan
                @"CREATE TABLE IF NOT EXISTS TaskPlan (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TaskName VARCHAR(200) NOT NULL,
                    ExamContent VARCHAR(500),
                    TaskType VARCHAR(100),
                    DifficultyLevel VARCHAR(50),
                    Status INTEGER DEFAULT 1,
                    CanDraw INTEGER DEFAULT 1,
                    Remark VARCHAR(500),
                    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP
                )",

                // 9. 任务方案明细表 TaskPlanDetail
                @"CREATE TABLE IF NOT EXISTS TaskPlanDetail (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TaskPlanId INTEGER NOT NULL,
                    UnitName VARCHAR(200),
                    TaskDesc VARCHAR(500),
                    SortNo INTEGER DEFAULT 0,
                    FOREIGN KEY (TaskPlanId) REFERENCES TaskPlan(Id)
                )",

                // 10. 抽考活动表 ExamActivity
                @"CREATE TABLE IF NOT EXISTS ExamActivity (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ActivityName VARCHAR(200) NOT NULL,
                    BatchNo VARCHAR(100),
                    DrawGroupCount INTEGER DEFAULT 0,
                    DrawTaskCount INTEGER DEFAULT 0,
                    AllowRepeat INTEGER DEFAULT 0,
                    Status INTEGER DEFAULT 0,
                    CreatedBy INTEGER,
                    CreatedTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (CreatedBy) REFERENCES SysUser(Id)
                )",

                // 11. 指挥组抽取结果表 ExamActivityGroupResult
                @"CREATE TABLE IF NOT EXISTS ExamActivityGroupResult (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ActivityId INTEGER NOT NULL,
                    GroupId INTEGER NOT NULL,
                    SortNo INTEGER DEFAULT 0,
                    IsMustHit INTEGER DEFAULT 0,
                    DrawTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (ActivityId) REFERENCES ExamActivity(Id),
                    FOREIGN KEY (GroupId) REFERENCES CommandGroup(Id)
                )",

                // 12. 任务抽取结果表 ExamActivityTaskResult
                @"CREATE TABLE IF NOT EXISTS ExamActivityTaskResult (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ActivityId INTEGER NOT NULL,
                    TaskPlanId INTEGER NOT NULL,
                    SortNo INTEGER DEFAULT 0,
                    IsMustHit INTEGER DEFAULT 0,
                    DrawTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (ActivityId) REFERENCES ExamActivity(Id),
                    FOREIGN KEY (TaskPlanId) REFERENCES TaskPlan(Id)
                )",

                // 13. 最终结果映射表 ExamActivityFinalResult
                @"CREATE TABLE IF NOT EXISTS ExamActivityFinalResult (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ActivityId INTEGER NOT NULL,
                    SortNo INTEGER DEFAULT 0,
                    GroupResultId INTEGER NOT NULL,
                    TaskResultId INTEGER NOT NULL,
                    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (ActivityId) REFERENCES ExamActivity(Id),
                    FOREIGN KEY (GroupResultId) REFERENCES ExamActivityGroupResult(Id),
                    FOREIGN KEY (TaskResultId) REFERENCES ExamActivityTaskResult(Id)
                )",

                // 14. 必抽规则表 ExamMustHitRule
                @"CREATE TABLE IF NOT EXISTS ExamMustHitRule (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ActivityId INTEGER,
                    TargetType VARCHAR(50) NOT NULL,
                    TargetId INTEGER NOT NULL,
                    MustHitLevel INTEGER DEFAULT 1,
                    FixedPosition INTEGER,
                    StartTime DATETIME,
                    EndTime DATETIME,
                    Status INTEGER DEFAULT 1,
                    FOREIGN KEY (ActivityId) REFERENCES ExamActivity(Id)
                )",

                // 15. 操作日志表 SysLog
                @"CREATE TABLE IF NOT EXISTS SysLog (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER,
                    ModuleName VARCHAR(100),
                    OperationType VARCHAR(50),
                    OperationContent VARCHAR(1000),
                    OperationTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (UserId) REFERENCES SysUser(Id)
                )",

                // 16. 系统配置表 SysConfig
                @"CREATE TABLE IF NOT EXISTS SysConfig (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ConfigKey VARCHAR(100) NOT NULL UNIQUE,
                    ConfigValue VARCHAR(500),
                    Description VARCHAR(500),
                    UpdateTime DATETIME DEFAULT CURRENT_TIMESTAMP
                )"
            };

            foreach (string sql in createTableSqls)
            {
                SQLiteHelper.ExecuteNonQuery(sql);
            }

            // 创建索引
            CreateIndexes();
        }

        private static void CreateIndexes()
        {
            string[] createIndexSqls = new string[]
            {
                "CREATE INDEX IF NOT EXISTS idx_SysUser_UserName ON SysUser(UserName)",
                "CREATE INDEX IF NOT EXISTS idx_SysUserRole_UserId ON SysUserRole(UserId)",
                "CREATE INDEX IF NOT EXISTS idx_SysUserRole_RoleId ON SysUserRole(RoleId)",
                "CREATE INDEX IF NOT EXISTS idx_OrgUnit_ParentId ON OrgUnit(ParentId)",
                "CREATE INDEX IF NOT EXISTS idx_Person_UnitId ON Person(UnitId)",
                "CREATE INDEX IF NOT EXISTS idx_CommandGroup_UnitId ON CommandGroup(UnitId)",
                "CREATE INDEX IF NOT EXISTS idx_CommandGroupMember_GroupId ON CommandGroupMember(GroupId)",
                "CREATE INDEX IF NOT EXISTS idx_CommandGroupMember_PersonId ON CommandGroupMember(PersonId)",
                "CREATE INDEX IF NOT EXISTS idx_TaskPlanDetail_TaskPlanId ON TaskPlanDetail(TaskPlanId)",
                "CREATE INDEX IF NOT EXISTS idx_ExamActivityGroupResult_ActivityId ON ExamActivityGroupResult(ActivityId)",
                "CREATE INDEX IF NOT EXISTS idx_ExamActivityTaskResult_ActivityId ON ExamActivityTaskResult(ActivityId)",
                "CREATE INDEX IF NOT EXISTS idx_ExamActivityFinalResult_ActivityId ON ExamActivityFinalResult(ActivityId)",
                "CREATE INDEX IF NOT EXISTS idx_ExamMustHitRule_ActivityId ON ExamMustHitRule(ActivityId)",
                "CREATE INDEX IF NOT EXISTS idx_SysLog_UserId ON SysLog(UserId)",
                "CREATE INDEX IF NOT EXISTS idx_SysLog_OperationTime ON SysLog(OperationTime)"
            };

            foreach (string sql in createIndexSqls)
            {
                try
                {
                    SQLiteHelper.ExecuteNonQuery(sql);
                }
                catch
                {
                }
            }
        }

        private static void InsertDefaultData()
        {
            // 检查是否已有数据
            object roleCount = SQLiteHelper.ExecuteScalar("SELECT COUNT(*) FROM SysRole");
            if (roleCount != null && Convert.ToInt32(roleCount) > 0)
            {
                return;
            }

            using (SQLiteConnection conn = SQLiteHelper.GetConnection())
            {
                conn.Open();
                using (SQLiteTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 插入角色数据
                        string[] roleSqls = new string[]
                        {
                            "INSERT INTO SysRole (RoleName, RoleCode, Description) VALUES ('系统管理员', 'admin', '拥有系统所有权限')",
                            "INSERT INTO SysRole (RoleName, RoleCode, Description) VALUES ('业务管理员', 'business_admin', '负责基础数据维护，可发起抽考')",
                            "INSERT INTO SysRole (RoleName, RoleCode, Description) VALUES ('抽考操作员', 'exam_operator', '仅能执行抽考操作')",
                            "INSERT INTO SysRole (RoleName, RoleCode, Description) VALUES ('查看用户', 'viewer', '仅可查看和导出结果')"
                        };

                        foreach (string sql in roleSqls)
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn, trans))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 插入默认管理员账号 admin/admin
                        string hashedPassword = HashPassword("admin");
                        string insertUserSql = "INSERT INTO SysUser (UserName, Password, RealName, Status) VALUES ('admin', @password, '系统管理员', 1)";
                        using (SQLiteCommand cmd = new SQLiteCommand(insertUserSql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@password", hashedPassword);
                            cmd.ExecuteNonQuery();
                        }

                        // 获取用户ID和角色ID
                        long userId;
                        using (SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid()", conn, trans))
                        {
                            userId = (long)cmd.ExecuteScalar();
                        }

                        long adminRoleId;
                        using (SQLiteCommand cmd = new SQLiteCommand("SELECT Id FROM SysRole WHERE RoleCode = 'admin'", conn, trans))
                        {
                            adminRoleId = (long)cmd.ExecuteScalar();
                        }

                        // 插入用户角色关系
                        string insertUserRoleSql = "INSERT INTO SysUserRole (UserId, RoleId) VALUES (@userId, @roleId)";
                        using (SQLiteCommand cmd = new SQLiteCommand(insertUserRoleSql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@roleId", adminRoleId);
                            cmd.ExecuteNonQuery();
                        }

                        // 插入系统配置默认值
                        string[] configSqls = new string[]
                        {
                            "INSERT INTO SysConfig (ConfigKey, ConfigValue, Description) VALUES ('system_name', '指挥训练抽考系统', '系统名称')",
                            "INSERT INTO SysConfig (ConfigKey, ConfigValue, Description) VALUES ('system_version', '1.0.0', '系统版本')",
                            "INSERT INTO SysConfig (ConfigKey, ConfigValue, Description) VALUES ('default_draw_count', '3', '默认抽取数量')",
                            "INSERT INTO SysConfig (ConfigKey, ConfigValue, Description) VALUES ('enable_must_hit', '1', '是否启用必抽功能')"
                        };

                        foreach (string sql in configSqls)
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn, trans))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        private static string HashPassword(string password)
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

        public static void ResetDatabase()
        {
            string dbPath = GetDatabasePath();
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }
            Initialize();
        }
    }
}
