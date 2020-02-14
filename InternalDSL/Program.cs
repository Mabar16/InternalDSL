using System;

namespace InternalDSL
{
    class Program
    {
        static void Main(string[] args)
        {
            var xx = new SqlBuilderImpl().Build().Select("Name").From("students").Where("age", "25").CreateQuery();

            var query = SqlConnectionClass.CreateQuery("Name", "Students", ("age","25"));

            Console.WriteLine(xx);
        }
    }
}
