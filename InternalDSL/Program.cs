using System;
using System.Threading.Tasks;
using InternalDSL.Sql;

namespace InternalDSL
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = @"Server=(localdb)\MyInstance;Initial Catalog = Local;Integrated Security=true;";
            bool usePostgress = false;
            //string connectionString = "Host=localhost;Port=5435;Username=postgres;Password=Mikoto;Database=postgres";

            var builder = new SQLQueryBuilder();

             var selectQuery = builder.
                         Select("students.name", "course", "grade", "age", "major").
                         Distinct().
                         From("students", "grades").
                         Where(("students.name","grades.name")).
                         OrderBy("students.name").
                         FinishQuery();

            SqlConnectionClass.PerformQuery(usePostgress, connectionString, selectQuery); 
            Console.WriteLine("\r\n^Before, After ->\r\n");

            var updateQuery = builder.
                        Update("students").
                        Set(("age", "99")).
                        Where(("name","markus")).
                        FinishQuery();

            var selectQuery2 = builder.
                        Select("students.name", "course", "grade", "age", "major").
                        Distinct().
                        From("students", "grades").
                        Where(("students.name", "grades.name")).
                        OrderBy("major").
                        FinishQuery();

            SqlConnectionClass.PerformQuery(usePostgress, connectionString, updateQuery);
            SqlConnectionClass.PerformQuery(usePostgress, connectionString, selectQuery2);

            //Console.WriteLine("Press any key to exit");
            //Console.ReadKey();
        }
    }
}
