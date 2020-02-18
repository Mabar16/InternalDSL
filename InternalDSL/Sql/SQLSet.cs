using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLSet
    {
        private Dictionary<string, string> updatekvpairs;
        public SQLSet(params (string, string)[] args)
        {
            if (args.Length == 0)
                throw new Exception("You must include at least 1 column and value to perform updates");

            updatekvpairs = new Dictionary<string, string>();

            Array.ForEach(args, pair => updatekvpairs.Add(pair.Item1, $"{pair.Item1} = '{pair.Item2}'"));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("SET ");
            sb.Append(string.Join(", ",updatekvpairs.Values));
            return sb.ToString();
        }
    }
}
