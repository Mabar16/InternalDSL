using System;
namespace InternalDSL.Sql
{
    public class SQLQueryBuilder :SqlBuilderInterface
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
