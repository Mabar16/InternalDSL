using System;
namespace InternalDSL.Sql
{
    public class SQLSelect : ISQLQuery
    {
        private SQLFrom fromClause;
        private SQLWhere whereClause;

        public SQLSelect() 
        {
        }

        public SQLSelect Select(params string[] args)
        {
            string text = string.Join(",", args);
            string x = $"SELECT {text} ";
            //query.Append(x);
            return this;
        }

        public SQLSelect From(params string[] args)
        {
            fromClause = new SQLFrom(args);
            return this;
        }

        public SQLSelect Where(params (string, string)[] args)
        {
            return this; 
        }

        public string FinishQuery()
        {
            throw new NotImplementedException();
        }
    }
}
