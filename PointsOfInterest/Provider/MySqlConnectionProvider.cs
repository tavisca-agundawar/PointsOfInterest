using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PointsOfInterest.Provider
{
    public class MySqlConnectionProvider
    {
        private readonly MySqlConnection _connection;
        public MySqlConnectionProvider()
        {
            string sqlUsername = ConfigurationManager.AppSettings["SqlUsername"];
            string sqlPassword = Environment.GetEnvironmentVariable("sql_password");
            string dbName = ConfigurationManager.AppSettings["DatabaseName"];
            string serverUrl = ConfigurationManager.AppSettings["Server"];
            string port = ConfigurationManager.AppSettings["SqlPort"];
            string connectionString = $"server={serverUrl};port={port};Database={dbName}; " +
                               $"uid={ sqlUsername };pwd= { sqlPassword }; convert zero datetime=True;";
            _connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
