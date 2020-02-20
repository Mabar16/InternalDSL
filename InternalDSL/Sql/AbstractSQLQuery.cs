using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public abstract class AbstractSQLQuery
    {

        protected List<string> columns;
        protected bool distinct;
        protected string groupBy;
        protected string orderBy;
        protected SQLFrom fromClause;
        protected SQLWhere whereClause;

        /// <summary>
        /// Adds a WHERE clause to the current SQL query
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract AbstractSQLQuery Where(params (string, string)[] args);

        public AbstractSQLQuery Distinct()
        {
            distinct = true;
            return this;
        }
        
        /// <summary>
        /// Adds a FROM clause to the current SQL query
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public AbstractSQLQuery From(params string[] args)
        {
            fromClause = new SQLFrom(args);
            return this;
        }

        public AbstractSQLQuery GroupBy(string column)
        {
            groupBy = $"GROUP BY {column}";
            return this;
        }

        public AbstractSQLQuery OrderBy(string column)
        {
            orderBy = $"ORDER BY {column}";
            return this;
        }

        public abstract string FinishQuery();
    }
}
