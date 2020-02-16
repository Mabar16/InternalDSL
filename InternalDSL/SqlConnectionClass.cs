using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace InternalDSL
{
    public class SqlConnectionClass
    {
        

        public static string CreateQuery(string select, string from, (string, string) where)
        {
            return  $"SELECT {select}" +
                    $" FROM {from} " +
                    $"WHERE {where.Item1} = {where.Item2};";
        }

        public static string CreateCommand(string queryString)
        {
            string connectionString = @"Server=(localdb)\MyInstance;Initial Catalog = Local;Integrated Security=true;";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                var result = command.ExecuteNonQuery();
                var r2 = command.ExecuteReader();                
                
                while (r2.Read())
                {
                    string[] output = new string[r2.FieldCount];
                    for (int i = 0; i < r2.FieldCount; i++)
                    {
                        output[i]= r2.GetValue(i).ToString();
                    }
                        Console.WriteLine(string.Join(",",output));
                }
            }
            return "Error";
        }
    }
}
