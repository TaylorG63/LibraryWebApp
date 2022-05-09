using System.Configuration;
using System.Data.SqlClient;

namespace LibraryDatabaseAccessLayer
{
    public abstract class ControllerDAL<T>
    {
        public string ConnectionString { get; set; }
        public ControllerDAL()
        {
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["LibraryConsoleConnString"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ControllerDAL(string _connectionString) { ConnectionString = _connectionString; }

        public abstract List<T> Get();
    }
}
