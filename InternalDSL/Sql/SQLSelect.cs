using System;
using System.Collections.Generic;

namespace InternalDSL.Sql
{
    public class SQLSelect : ISQLQuery
    {
        private List<string> columns;
        private SQLFrom fromClause;
        private SQLWhere whereClause;

        public SQLSelect() 
        {
            columns = new List<string>();
        }

        public SQLSelect Select(params string[] args)
        {
            if (args.Length == 0)
                columns.Add("*");
            else 
                Array.ForEach(args, column => columns.Add(column));

            return this;
        }

        public SQLSelect From(params string[] args)
        {
            fromClause = new SQLFrom(args);
            return this;
        }

        public SQLSelect Where(params (string, string)[] args)
        {
            whereClause = new SQLWhere(args);
            return this; 
        }

        public string FinishQuery()
        {
            string text = string.Join(",", columns);
            string selecText = $"SELECT {text} ";

            return $"{selecText} {fromClause} {whereClause}";
        }
    }
}
