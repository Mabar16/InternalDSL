using InternalDSL.Sql.SQLComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternalDSL.Sql
{
    public abstract class AbstractSQLQuery
    {

        protected List<string> columns;
        protected bool distinct;
        protected bool fromMultipleTables;
        protected List<SQLClause> components;
        protected SQLWhere where;

        protected AbstractSQLQuery()
        {
            components = new List<SQLClause>();
            columns = new List<string>();
        }

        /// <summary>
        /// Adds a WHERE clause to the current SQL query
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public AbstractSQLQuery Where((string, string) condition)
        {
            where = new SQLWhere(condition);
            components.Add(where);
            return this;
        }        

        public void AndWhere((string, string) condition)
        {
            where.NestWhere(condition, "AND");
        }

        public void OrWhere((string, string) condition)
        {
            where.NestWhere(condition, "OR");
        }

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
            components.Add(new SQLFrom(args));
            fromMultipleTables = ((SQLFrom)components.Last()).MultipleTables;
            return this;
        }

        public AbstractSQLQuery GroupBy(string column)
        {            
            components.Add(new SQLGroupBy(column));
            return this;
        }

        public AbstractSQLQuery OrderBy(string column)
        {
            components.Add(new SQLOrderBy(column));
            return this;
        }

        public AbstractSQLQuery Join(string table, (string, string) columnsToJoinOn, string joinType = null)
        {
            if(joinType == null)
                components.Add(new SQLJoin(table, columnsToJoinOn));
            else
                components.Add(new SQLJoin(table, columnsToJoinOn, joinType));
            return this;
        }

        public AbstractSQLQuery InnerJoin(string table, (string, string) columnsToJoinOn)
        {
            Join(table, columnsToJoinOn, "INNER");
            return this;
        }

        public AbstractSQLQuery OuterJoin(string table, (string, string) columnsToJoinOn)
        {
            Join(table, columnsToJoinOn, "OUTER");
            return this;
        }

        public abstract string FinishQuery();
    }
}
