using System;

namespace InternalDSL
{
    class Program
    {
        static void Main(string[] args)
        {
            var xx = new SqlBuilderImpl().Build().
                Select("Name").
                From("students").
                WhereIs("age", "23").
                //AndWhereLike("major","Engineering").
                CreateQuery();

            Console.WriteLine(xx);

            SqlConnectionClass.CreateCommand(xx);
        }
    }
}
