using System;
using InternalDSL.Sql;

namespace InternalDSL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=(localdb)\MyInstance;Initial Catalog = Local;Integrated Security=true;";

            var builder = new SQLQueryBuilder();

            var selectQuery = builder.
                        Select("students.name", "course", "grade", "age").Distinct().
                        From("students", "grades").
                        Where(("students.name","grades.name")).
                        FinishQuery();

            SqlConnectionClass.ExecuteQuery(selectQuery, connectionString);
            Console.WriteLine();

            var updateQuery = builder.
                        Update("students").
                        Set(("age", "23")).
                        Where(("name","markus")).
                        FinishQuery();

            selectQuery = builder.
                        Select("students.name", "course", "grade", "age").Distinct().
                        From("students", "grades").
                        Where(("students.name", "grades.name")).
                        FinishQuery();

            SqlConnectionClass.ExecuteQuery(updateQuery, connectionString);
            Console.WriteLine();
            SqlConnectionClass.ExecuteQuery(selectQuery, connectionString);
        }
    }
}
