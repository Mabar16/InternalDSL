using System;
namespace InternalDSL.Sql
{
    public class SQLQueryBuilder :SqlBuilderInterface
    {
        public SQLQueryBuilder()
        {
            
        }
        /// <summary>
        /// Creates a new instance of SQLSelect, representing a SELECT query
        /// </summary>
        /// <param name="args"></param> Columns to select
        /// <returns></returns>
        public SQLSelect Select(params string[] args)
        {
            return new SQLSelect(args);
        }

        public SQLUpdate Update(string tableName)
        {
            return new SQLUpdate(tableName);
        }
    }
}
