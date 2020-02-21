using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLSelect : AbstractSQLQuery
    {
        
        public SQLSelect(params string[] args)
        {            
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
            sb.Append(selecText + " ");

            components.ForEach(clause => sb.Append($"{clause} "));

            return sb.ToString();
        }
        /*
        public override AbstractSQLQuery Where((string, string) condition)
        {
            
        }
        */
    }
}
