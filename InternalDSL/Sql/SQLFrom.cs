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
        public bool MulipleTables { get; private set; }

        public SQLFrom(params string[] args)
        {
            if (args.Length < 1)
                throw new Exception("FROM requires at least one table");

            tables = new List<string>();

            Array.ForEach(args, tableName => tables.Add(tableName));

            MulipleTables = tables.Count > 1 ? true : false;
        }

        public override string ToString()
        {
            if (!MulipleTables)
                return $"FROM {tables.First()}";
            else
            {
                return $"FROM {string.Join(",", tables)}";
            }
        }

        public void As(params string[] args)
        {
            aliases = new List<string>();
            Array.ForEach(args, alias => tables.Add(alias));
            //TODO
        }
    }
}
