using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLUpdate : ISQLQuery
    {
        private SQLWhere whereClause;
        private SQLSet setClause;
        private string tableToUpdate;
        public SQLUpdate(string tableName)
        {
            tableToUpdate = tableName;
        }

        public SQLUpdate Where(params (string, string)[] args)
        {
            whereClause = new SQLWhere(false, args);
            return this;
        }

        public SQLUpdate Set(params (string, string)[] args)
        {
            setClause = new SQLSet(args);
            return this;
        }

        public string FinishQuery()
        {
            return $"UPDATE {tableToUpdate} {setClause.ToString()} {whereClause.ToString()}";
        }
    }
}
