using System;
using System.Threading.Tasks;
using InternalDSL.Sql;

namespace InternalDSL
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new SQLQueryBuilder();

            var selectQuery = builder.
                                Select("students.name", "age", "major", "course", "grade").
                                Distinct().
                                From("students").
                                InnerJoin("grades",("students.name","grades.name")).
                                Where("students.name", "grades.name").AND("students.name", "Markus").OR("students.name", "Joji").AND("age", "99").
                                OrderBy("students.name").
                                FinishQuery();

            Console.WriteLine(selectQuery+"\r\n");
            

            var updateQuery = builder.
                        Update("students").
                        Set(("age", "23")).
                        Where("name", "markus").
                        FinishQuery();

            var selectQuery2 = builder.
                        Select("students.name", "course", "grade", "age", "major").
                        Distinct().
                        From("students", "grades").
                        Where("students.name", "grades.name").
                        OrderBy("major").
                        FinishQuery();

            Console.WriteLine(updateQuery + "\r\n");            
            Console.WriteLine(selectQuery2 + "\r\n");


            //string connectionString = @"Server=(localdb)\MyInstance;Initial Catalog = Local;Integrated Security=true;";
            //bool usePostgress = false;
            //string connectionString = "Host=localhost;Port=5435;Username=postgres;Password=Mikoto;Database=postgres";
            //ExecuteQuery(usePostgress, connectionString, updateQuery);
            //ExecuteQuery(usePostgress, connectionString, selectQuery);
            //ExecuteQuery(usePostgress, connectionString, selectQuery2);
        }

        /// <summary>
        /// Requires appropriate database to be setup on host machine. 
        /// </summary>
        private static void ExecuteQuery(bool usePostgress, string connectionString, string query)
        {
            SqlConnectionClass.PerformQuery(usePostgress, connectionString, query);
        }


    }
}
