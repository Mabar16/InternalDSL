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

        public async static void PostgresCreateCommand(string queryString)
        {
            var connString = "Host=localhost;Port=5435;Username=postgres;Password=Mikoto;Database=postgres";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("INSERT INTO students (id, name, age, major) VALUES (@id, @n, @a, @m)", conn))
            {
                cmd.Parameters.AddWithValue("id", "5");
                cmd.Parameters.AddWithValue("n", "Jonas");
                cmd.Parameters.AddWithValue("a", "83");
                cmd.Parameters.AddWithValue("m", "Pokemon Masters");
                await cmd.ExecuteNonQueryAsync();
            }

            // Retrieve all rows
            await using (var cmd = new NpgsqlCommand("SELECT name FROM students;", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    Console.WriteLine("hi " +reader.GetString(0));

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
