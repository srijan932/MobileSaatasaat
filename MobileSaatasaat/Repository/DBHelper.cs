using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MobileSaatasaat.Repository
{
    public class DBHelper
    {
        public static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["mobilesaatasaat"].ToString();
        public static IDbConnection _db = new SqlConnection(connStr);

        public static SqlConnection GetDbConnection()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mobilesaatasaat"].ToString();
            var connection = new SqlConnection(connectionString.ToString());
            connection.Open();
            return connection;
        }
    }
}