using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLSelect : AbstractSQLQuery
    {
        
        public SQLSelect(params string[] args)
        {
            columns = new List<string>();
            if (args.Length == 0)
                columns.Add("*");
            else 
                Array.ForEach(args, column => columns.Add(column));
        }
        
        public override string FinishQuery()
        {
            StringBuilder sb = new StringBuilder();

            string text = string.Join(",", columns);
            string selecText = distinct ? $"SELECT DISTINCT {text}" : $"SELECT {text}";

            sb.Append(selecText+" ");
            sb.Append(fromClause + " ");
            if (whereClause != null)
                sb.Append(whereClause + " ");
            if (groupBy != null)
                sb.Append(groupBy + " ");
            if (orderBy != null)
                sb.Append(orderBy + " ");

            return sb.ToString();
        }

        public override AbstractSQLQuery Where(params (string, string)[] args)
        {
            if (fromClause == null)
                throw new Exception("FROM must be called before WHERE");

            whereClause = new SQLWhere(fromClause.MulipleTables, args);
            return this;
        }
    }
}
