using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLUpdate : AbstractSQLQuery
    {
        public SQLUpdate(string tableName)
        {
            columns.Add( tableName);
        }

        public SQLUpdate Set(params (string, string)[] args)
        {
            components.Add(new SQLSet(args));
            return this;
        }
        /*
        public override AbstractSQLQuery Where((string, string) condition)
        {
            where = new SQLWhere(condition);
            components.Add(where);
            return this;
        }
        */
        public override string FinishQuery()
        {
            return $"UPDATE {columns.First()} {string.Join(" ", components)}";
        }
    }
}
