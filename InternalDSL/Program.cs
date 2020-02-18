using System;
using InternalDSL.Sql;

namespace InternalDSL
{
    class Program
    {
        static void Main(string[] args)
        {
            /* query = new SQLQueryBuilder().MakeSelect().
                        Select("name").
                        From("students").
                        Where(("age","23")).
                        FinishQuery();
                        */

            var xx = new SqlBuilderImpl().Build().
                Select("Name").
                From("students as A", "Teachers as B").
                WhereIs("age", "23").
                //AndWhereLike("major","Engineering").
                CreateQuery();

            Console.WriteLine("hi");
            SqlConnectionClass.PostgresCreateCommand("");
            //SqlConnectionClass.CreateCommand(xx);*/
        }
    }
}
