using MySql.Data.MySqlClient;

namespace EmpleadosApp.Data
{
    public class Connection
    {
        // singleton connection
        private static string server = "localhost";
        private static string bd = "empleadosdb";
        private static string user = "root";
        private static string password = "Maisicual123";
        private static string connectionString = "Database=" + bd + "; Data Source=" + server + "; User Id= " + user + "; Password=" + password + "";
        private static MySqlConnection instance = new(connectionString);
        public static MySqlConnection Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
