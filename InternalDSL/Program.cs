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

            var query = builder.MakeSelect().
                        Select("name","major").
                        From("students").
                        Where(("age","23")).
                        FinishQuery(); 

            SqlConnectionClass.CreateCommand(query, connectionString);
        }
    }
}
