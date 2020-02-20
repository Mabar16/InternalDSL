using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql.SQLComponents
{
    public class SQLGroupBy : SQLClause
    {
        private string column;
        public SQLGroupBy(string column)
        {
            this.column = column;
        }

        public override string ToString()
        {
            return $"GROUP BY {column}";
        }
    }
}
