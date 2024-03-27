using System.Data.SqlClient;
using System.Data;

namespace TeamBlackHatsAPI
{
    public static class NFLDBConnection
    {
        private static SqlConnection conn;
        private static bool connected = false;

        /// <summary>
        /// Creates a database connection from environment variables
        /// 
        /// May raise an exception if the database didn't connect
        /// </summary>
        public static void Connect()
        {
            if (connected) { return; }

            string? dbLocation = null;
            string? dbUsername = null;
            string? dbPassword = null;
            string? dbCatalog = null;

            dbLocation = Environment.GetEnvironmentVariable("DB_LOCATION");
            dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME");
            dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            dbCatalog = Environment.GetEnvironmentVariable("DB_CATALOG");

            if (dbLocation == null) { dbLocation = "localhost"; }
            if (dbUsername == null) { dbUsername = "username"; }
            if (dbPassword == null) { dbPassword = "password"; }
            if (dbCatalog == null) { dbCatalog = "my_db"; }

            var stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = dbLocation;
            stringBuilder.UserID = dbUsername;
            stringBuilder.Password = dbPassword;
            stringBuilder.InitialCatalog = dbCatalog;
            stringBuilder.TrustServerCertificate = true;

            conn = new SqlConnection(stringBuilder.ConnectionString);
            conn.Open();
            connected = true;
        }

        /// <summary>
        /// Disconnects from the database.
        /// </summary>
        public static void Disconnect()
        {
            if (!connected) { return; }
            conn.Dispose();
            connected = false;
        }

        /// <summary>
        /// Reads from the database with SQL
        /// </summary>
        /// <param name="query">The read-only SQL query</param>
        /// <returns>The results of executing the query</returns>
        public static DataTable ReadWithSql(string query)
        {
            SqlDataReader sqlDataReader;
            var dataTable = new DataTable();

            using (SqlCommand sqlCommnad = new SqlCommand(query, conn))
            {
                sqlDataReader = sqlCommnad.ExecuteReader();
                dataTable.Load(sqlDataReader);
            }

            return dataTable;
        }
    }
}
