using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace LibraryDatabaseAccessLayer
{
    public abstract class SQL_DAL
    {
        static List<string> BannedKeyWords = new List<string>() {"drop", "table" };
        #region
        #if DEBUG
        #warning Connection String Hardcoded for Temp work
        #elif RELEASE
        #error Connection String Hardcoded for Temp work Do not deploy
        #endif
        #endregion
        public static string GetConnectionString(string connectionName = "LibraryWebAppDB")
        {
            //return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            return "Data Source=DESKTOP-P4DM9AE;Initial Catalog=LibraryWebApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static List<T> LoadData<T>(string sql)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    return cnn.Query<T>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging(ex);
                return new List<T>();
            }
        }

        public static int CreateData<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    return cnn.Execute(sql, data);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging(ex);
                return 0;
            }
        }

        public static bool DeleteData<T>(string sql)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    cnn.Execute(sql);
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLogging(ex);
                return false;
            }
        }

        public static bool BlackList(string input)
        {
            for (int i = 0; i < BannedKeyWords.Count; i++)
            {
                if (input.Contains(BannedKeyWords[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static void ExceptionLogging(Exception ex)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                DateTime _logDate = new DateTime();
                _logDate = DateTime.Now;
                string log = $"INSERT INTO [dbo].[ExceptionLogging] (StackTrace, Message, Source, LogDate)" +
                      $@"VALUES (@StackTrace, '{ex.Message.Replace("'", "\"")}', @Source, '{_logDate.ToString("yyyy-MM-dd HH:mm:ss")}')";
                cnn.Execute(log, ex);
            }
        }
    }
}
