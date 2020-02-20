using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLUpdate : AbstractSQLQuery
    {
        private SQLSet setClause;
        private string tableToUpdate;
        public SQLUpdate(string tableName)
        {
            tableToUpdate = tableName;
        }

        public SQLUpdate Set(params (string, string)[] args)
        {
            setClause = new SQLSet(args);
            return this;
        }

        public override AbstractSQLQuery Where(params (string, string)[] args)
        {
            if (setClause == null)
                throw new Exception("SET must be called before WHERE");

            whereClause = new SQLWhere(false, args);
            return this;
        }

        public override string FinishQuery()
        {
            return $"UPDATE {tableToUpdate} {setClause.ToString()} {whereClause.ToString()}";
        }
    }
}
