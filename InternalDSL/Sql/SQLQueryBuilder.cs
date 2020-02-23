using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLQueryBuilder
    {
        public SQLQueryBuilder()
        {
            
        }

        private AbstractSQLQuery queryObject;

        private void MakeSelect(params string[] args)
        {
            queryObject = new SQLSelect(args);
        }
        public SQLQueryBuilder Distinct()
        {
            queryObject.Distinct();
            return this;
        }

        /// <summary>
        /// Adds a FROM clause to the current SQL query
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public SQLQueryBuilder From(params string[] args)
        {
            queryObject.From(args);
            return this;
        }

        /// <summary>
        /// Adds a WHERE clause to the current SQL query
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public SQLQueryBuilder Where(string val1, string val2)
        {
            queryObject.Where((val1, val2));
            return this;
        }

        /// <summary>
        /// Nests a where clause using the following pattern:
        /// Where1 AND (Where2 AND (Where3)) etc.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public SQLQueryBuilder AND(string val1, string val2)
        {
            queryObject.AndWhere((val1, val2));
            return this;
        }

        /// <summary>
        /// Nests a where clause using the following pattern:
        /// Where1 OR (Where2 OR (Where3)) etc.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public SQLQueryBuilder OR(string val1, string val2)
        {
            queryObject.OrWhere((val1, val2));
            return this;
        }

        public SQLQueryBuilder Join(string table, (string, string) columnsToJoinOn)
        {
            queryObject.Join(table, columnsToJoinOn);
            return this;
        }

        public SQLQueryBuilder InnerJoin(string table, (string, string) columnsToJoinOn)
        {
            queryObject.InnerJoin(table, columnsToJoinOn);
            return this;
        }

        public SQLQueryBuilder OuterJoin(string table, (string, string) columnsToJoinOn)
        {
            queryObject.OuterJoin(table, columnsToJoinOn);
            return this;
        }

        public SQLQueryBuilder GroupBy(string column)
        {
            queryObject.GroupBy(column);
            return this;
        }

        public SQLQueryBuilder OrderBy(string column)
        {
            queryObject.OrderBy(column);
            return this;
        }

        public string FinishQuery()
        {
            string query = queryObject.FinishQuery();
            Flush();
            return query;
        }

        private SQLQueryBuilder Flush()
        {
            queryObject = null;
            return this;
        }

        private SQLQueryBuilder MakeUpdate(string tableName)
        {
            queryObject = new SQLUpdate(tableName);
            return this;
        }

        public SQLQueryBuilder Set(params (string, string)[] args)
        {
            if (queryObject.GetType() == typeof(SQLUpdate))
                ((SQLUpdate)queryObject).Set(args);
            else
                throw new Exception("SET can only be called on UPDATE queries, not on " + queryObject.GetType().Name);
            return this;
        }

        /// <summary>
        /// Creates a new instance of SQLSelect, representing a SELECT query. 
        /// Prefix column names with their corresponding table name when selecting from multiple tables.
        /// </summary>
        /// <param name="args"></param> Columns to select
        /// <returns></returns>
        public SQLQueryBuilder Select(params string[] args)
        {
            MakeSelect(args);
            return this;
        }

        public SQLQueryBuilder Update(string tableName)
        {
            MakeUpdate(tableName);
            return this;
        }
    }
}
