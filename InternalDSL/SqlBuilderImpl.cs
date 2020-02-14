using InternalDSL.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL
{
    public class SqlBuilderImpl
    {
        private StringBuilder query;
        public SqlBuilderImpl Build()
        {
            query = new StringBuilder();
            return this;
        }

        public SqlBuilderImpl Select(string text)
        {
            string x = $"SELECT {text} ";
            query.Append(x);
            return this;
        }

        public SqlBuilderImpl From(string text)
        {
            string x = $"FROM {text} ";
            query.Append(x);
            return this;
        }

        public SqlBuilderImpl Where(string text, string text2)
        {
            string x = $"WHERE {text} = {text2} ";
            query.Append(x);
            return this;
        }

        public string CreateQuery()
        {
            return query.ToString();
        }
    }
}
