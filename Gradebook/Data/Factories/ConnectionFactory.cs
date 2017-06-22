using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Gradebook.Data.Factories
{
    public class ConnectionFactory
    {
        public static class AppKeys {
            public static String DatabaseConnection = "database_connection";
            public static String PasswordSalt = "password_salt";
        }

        public static DbConnection GetOpenConnection()
        {
            var connection = new SQLiteConnection(ConfigurationManager.AppSettings[AppKeys.DatabaseConnection].ToString());
            connection.Open();

            return connection;
        }
    }
}
