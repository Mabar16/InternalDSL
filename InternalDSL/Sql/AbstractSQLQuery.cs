using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public abstract class AbstractSQLQuery :ISQLQuery
    {

        private List<string> columns;
        private bool distinct;
        private string groupBy;
        private string orderBy;
        private SQLFrom fromClause;
        private SQLWhere whereClause;

        /// <summary>
        /// Adds a WHERE clause to the current SQL query
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public AbstractSQLQuery Where(params (string, string)[] args)
        {
            if (fromClause == null)
                throw new Exception("FROM must be called before WHERE");

            whereClause = new SQLWhere(fromClause.MulipleTables, args);
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

        public string FinishQuery()
        {
            StringBuilder sb = new StringBuilder();

            string text = string.Join(",", columns);
            string selecText = distinct ? $"SELECT DISTINCT {text}" : $"SELECT {text}";

            sb.Append(selecText + " ");
            sb.Append(fromClause + " ");
            if (whereClause != null)
                sb.Append(whereClause + " ");
            if (groupBy != null)
                sb.Append(groupBy + " ");
            if (orderBy != null)
                sb.Append(orderBy + " ");

            return sb.ToString();
        }
    }
}
