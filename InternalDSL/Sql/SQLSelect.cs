using System;
using System.Collections.Generic;

namespace InternalDSL.Sql
{
    public class SQLSelect : ISQLQuery
    {
        private List<string> columns;
        private bool distinct;
        private SQLFrom fromClause;
        private SQLWhere whereClause;
        
        public SQLSelect(params string[] args)
        {
            columns = new List<string>();
            if (args.Length == 0)
                columns.Add("*");
            else 
                Array.ForEach(args, column => columns.Add(column));
        }

        public SQLSelect Distinct()
        {
            distinct = true;
            return this;
        }

        /// <summary>
        /// Adds a FROM clause to the current SQL query
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public SQLSelect From(params string[] args)
        {
            fromClause = new SQLFrom(args);
            return this;
        }

        /// <summary>
        /// Adds a WHERE clause to the current SQL query
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public SQLSelect Where(params (string, string)[] args)
        {
            if (fromClause == null)
                throw new Exception("FROM must be called before WHERE");

            whereClause = new SQLWhere(fromClause.MulipleTables, args);
            return this; 
        }

        public string FinishQuery()
        {
            string text = string.Join(",", columns);
            string selecText = distinct ? $"SELECT DISTINCT {text} " : $"SELECT {text} ";

            return $"{selecText} {fromClause} {whereClause}";
        }
    }
}
