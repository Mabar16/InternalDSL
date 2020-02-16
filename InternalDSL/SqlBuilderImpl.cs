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

        public SqlBuilderImpl Select(params string[] args)
        {
            string text = string.Join(",",args);
            string x = $"SELECT {text} ";
            query.Append(x);
            return this;
        }

        public SqlBuilderImpl From(string text)
        {
            string x = $"FROM dbo.{text} ";
            query.Append(x);
            return this;
        }

        public SqlBuilderImpl WhereIs(string text, string text2)
        {
            string x = $"WHERE {text} = {text2} ";
            query.Append(x);
            return this;
        }

        public SqlBuilderImpl WhereLike(string text, string text2)
        {
            string x = $"WHERE {text} like '{text2}' ";
            query.Append(x);
            return this;
        }

        public SqlBuilderImpl WhereContains(string text, string text2)
        {
            string x = $"WHERE {text} like '%s{text2}%s' ";
            query.Append(x);
            return this;
        }

        public SqlBuilderImpl AndWhereIs(string text, string text2)
        {
            string queryText = "AND ";
            query.Append(queryText);
            this.WhereIs(text, text2);
            return this;
        }

        public SqlBuilderImpl AndWWhereContains(string text, string text2)
        {
            string queryText = "AND ";
            query.Append(queryText);
            this.WhereContains(text, text2);
            return this;
        }

        public SqlBuilderImpl AndWhereLike(string text, string text2)
        {
            string queryText = "AND ";
            query.Append(queryText);
            this.WhereLike(text, text2);
            return this;
        }

        public string CreateQuery()
        {
            return query.Append(";").ToString();
        }
    }
}
