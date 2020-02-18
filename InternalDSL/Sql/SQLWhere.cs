using System;
using System.Linq;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLWhere
    {
        private string content;

        public SQLWhere(bool fromMany = false, params(string, string)[] args)
        {
            StringBuilder contentBuilder = new StringBuilder();

            if (!fromMany)
            {
                if (args.Length == 0)
                    contentBuilder.Append(string.Empty);

                else if (args.Length == 1)
                    contentBuilder.Append($"WHERE {args[0].Item1} = '{args[0].Item2}' ");

                else
                {
                    contentBuilder.Append("WHERE ");
                    foreach (var pair in args)
                    {
                        string statment = $"{pair.Item1} = '{pair.Item2}' AND ";
                        contentBuilder.Append(statment);
                    }
                    //remove trailing "AND "
                    contentBuilder.Remove(contentBuilder.Length - 5, 4);
                }
            }
            else
            {
                if (args.Length == 0)
                    contentBuilder.Append(string.Empty);

                else if (args.Length == 1 && args[0].Item2.Contains('.'))
                    contentBuilder.Append($"WHERE {args[0].Item1} = {args[0].Item2} ");

                else if (args.Length == 1)
                    contentBuilder.Append($"WHERE {args[0].Item1} = '{args[0].Item2}' ");

                else
                {
                    contentBuilder.Append("WHERE ");
                    string statement;
                    foreach (var pair in args)
                    {
                        
                        if (args[0].Item2.Contains('.'))
                        {
                            statement = $"{pair.Item1} = {pair.Item2} AND ";
                        } else
                        {
                            statement = $"{pair.Item1} = '{pair.Item2}' AND ";
                        }
                        contentBuilder.Append(statement);
                    }
                    //remove trailing "AND "
                    contentBuilder.Remove(contentBuilder.Length - 5, 4);
                }
            }

            content = contentBuilder.ToString();
        }

        public override string ToString()
        {
            return content;
        }
    }
}
