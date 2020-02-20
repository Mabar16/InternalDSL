using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql.SQLComponents
{
    public class SQLOrderBy : SQLClause
    {
        private string column;
        public SQLOrderBy(string column)
        {
            this.column = column;
        }

        public override string ToString()
        {
            return $"ORDER BY {column}";
        }
    }
}
