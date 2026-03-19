using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace 单位抽考win7软件.DAL
{
    public class SQLiteHelper
    {
        private static string _connectionString;
        private static readonly object _lock = new object();

        static SQLiteHelper()
        {
            InitializeConnectionString();
        }

        private static void InitializeConnectionString()
        {
            string dbPath = Path.Combine(Application.StartupPath, "data", "exam.db");
            string dataDir = Path.Combine(Application.StartupPath, "data");
            
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }
            
            _connectionString = $"Data Source={dbPath};Version=3;Pooling=True;Max Pool Size=100;";
        }

        public static string ConnectionString
        {
            get { return _connectionString; }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            lock (_lock)
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] parameters)
        {
            lock (_lock)
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteScalar();
                    }
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql, params SQLiteParameter[] parameters)
        {
            lock (_lock)
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        
                        DataTable dt = new DataTable();
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
        }

        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] parameters)
        {
            SQLiteConnection conn = GetConnection();
            try
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static int ExecuteNonQueryWithTransaction(string sql, params SQLiteParameter[] parameters)
        {
            lock (_lock)
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SQLiteTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn, trans))
                            {
                                if (parameters != null && parameters.Length > 0)
                                {
                                    cmd.Parameters.AddRange(parameters);
                                }
                                int result = cmd.ExecuteNonQuery();
                                trans.Commit();
                                return result;
                            }
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        public static int ExecuteNonQueryWithTransaction(SQLiteConnection conn, SQLiteTransaction trans, string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn, trans))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalarWithTransaction(SQLiteConnection conn, SQLiteTransaction trans, string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn, trans))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }

        public static SQLiteTransaction BeginTransaction(out SQLiteConnection conn)
        {
            conn = GetConnection();
            conn.Open();
            return conn.BeginTransaction();
        }

        public static void CommitTransaction(SQLiteTransaction trans)
        {
            if (trans != null)
            {
                trans.Commit();
            }
        }

        public static void RollbackTransaction(SQLiteTransaction trans)
        {
            if (trans != null)
            {
                trans.Rollback();
            }
        }

        public static void CloseConnection(SQLiteConnection conn)
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static SQLiteParameter CreateParameter(string name, object value)
        {
            return new SQLiteParameter(name, value ?? DBNull.Value);
        }

        public static SQLiteParameter CreateParameter(string name, DbType dbType, object value)
        {
            return new SQLiteParameter(name, dbType) { Value = value ?? DBNull.Value };
        }

        public static int ExecuteBatchNonQuery(string[] sqls, SQLiteParameter[][] parametersArray)
        {
            lock (_lock)
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SQLiteTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            int totalAffected = 0;
                            for (int i = 0; i < sqls.Length; i++)
                            {
                                using (SQLiteCommand cmd = new SQLiteCommand(sqls[i], conn, trans))
                                {
                                    if (parametersArray != null && parametersArray.Length > i && parametersArray[i] != null)
                                    {
                                        cmd.Parameters.AddRange(parametersArray[i]);
                                    }
                                    totalAffected += cmd.ExecuteNonQuery();
                                }
                            }
                            trans.Commit();
                            return totalAffected;
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        public static long GetLastInsertId()
        {
            object result = ExecuteScalar("SELECT last_insert_rowid()");
            return result != null ? Convert.ToInt64(result) : 0;
        }
    }
}
