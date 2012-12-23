using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace AIM.Workflows
{
    public class Utilities
    {
        public static void DeleteOldLogEntries()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Logging"].ToString();
            using(SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(String.Format("delete from Log where Timestamp < '{0}'", System.DateTime.Now.AddDays(-10))))
            {
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
