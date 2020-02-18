using System;
namespace InternalDSL.Sql
{
    public class SQLFrom
    {
        public SQLFrom(params string[] args)
        {
            string text = string.Join(",", args);
            string x = $"FROM {text} ";
            //query.Append(x);
            //return this;
        }
    }
}
