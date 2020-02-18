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
                        Select("students.name", "course", "grade", "age", "major").
                        //Distinct().
                        From("students", "grades").
                        Where(("students.name","grades.name")).
                        OrderBy("students.name").
                        FinishQuery();

            SqlConnectionClass.ExecuteQuery(selectQuery, connectionString);
            Console.WriteLine("\r\n^Before, After ->\r\n");

            var updateQuery = builder.
                        Update("students").
                        Set(("age", "23")).
                        Where(("name","markus")).
                        FinishQuery();

            selectQuery = builder.
                        Select("students.name", "course", "grade", "age", "major").
                        //Distinct().
                        From("students", "grades").
                        Where(("students.name", "grades.name")).
                        OrderBy("major").
                        FinishQuery();

            SqlConnectionClass.ExecuteQuery(updateQuery, connectionString);
            SqlConnectionClass.ExecuteQuery(selectQuery, connectionString);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
