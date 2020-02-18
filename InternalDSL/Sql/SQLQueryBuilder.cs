using System;
namespace InternalDSL.Sql
{
    public class SQLQueryBuilder
    {
        public SQLQueryBuilder()
        {
            
        }

        public SQLSelect MakeSelect()
        {
            return new SQLSelect();
        }
    }
}
