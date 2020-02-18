using System;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace InternalDSL.Sql
{
    public class SQLFrom
    {
        private List<string> tables;
        private List<string> aliases;

        public SQLFrom(params string[] args)
        {
            tables = new List<string>();

            Array.ForEach(args, tableName => tables.Add(tableName));

            string text = string.Join(",", args);
            string x = $"FROM {text} ";
            //query.Append(x);
            //return this;
        }

        public override string ToString()
        {
            return $"FROM {string.Join(",", tables)}";
        }

        public void As(params string[] args)
        {
            aliases = new List<string>();
            Array.ForEach(args, alias => tables.Add(alias));
            //TODO
        }
    }
}
