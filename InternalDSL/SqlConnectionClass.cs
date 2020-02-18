using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

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

        public static void PostgresCreateCommand(string queryString)
        {
            var connString = "Host=localhost;Port=5435;Username=postgres;Password=Mikoto;Database=postgres";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            // Retrieve all rows
            using (var cmd = new NpgsqlCommand(@"SELECT age, id, name, major FROM public.students;", conn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    string[] output = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        output[i] = reader.GetValue(i).ToString();
                    }
                    Console.WriteLine(string.Join(",", output));
                }
                    

            Task.WaitAll();
            Console.WriteLine("done");
        }

        public static string ExecuteQuery(string queryString, string connectionString)
        {
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
