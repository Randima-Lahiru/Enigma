using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace connect
{
    public class connectionProvider
    {
        public static string connectionString = "Data Source=DESKTOP-3SOIUD0\\SQLEXPRESS;Initial Catalog=Eclinic;Integrated Security=True";
        //  public static string connectionString = ConfigurationManager.ConnectionStrings["amalEntities"].ConnectionString.ToString();
        public static int CreateSomething(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                try
                {

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.CommandTimeout = 0;
                        command.ExecuteNonQuery();
                        return 1;

                    }
                }
                catch (Exception e) { throw e; }
        }

        public static DataTable LoadSomething(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                try
                {

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.CommandTimeout = 0;
                        DataTable values = new DataTable();
                        var DataReader = command.ExecuteReader();
                        values.Load(DataReader);
                        return values;

                    }
                }
                catch (Exception e) { throw e; }
        }
    }
}