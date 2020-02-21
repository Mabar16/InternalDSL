using InternalDSL.Sql.SQLComponents;
using System;
using System.Linq;
using System.Text;

namespace InternalDSL.Sql
{
    public class SQLWhere : SQLClause
    {
        private string content;
        public string logic { get; private set; } = "AND";
        private SQLWhere nestedWhere;

        public SQLWhere((string, string) condition)
        {
            StringBuilder contentBuilder = new StringBuilder();

            if (condition.Item2.Contains('.'))
                contentBuilder.Append($"{condition.Item1} = {condition.Item2}");
            else
                contentBuilder.Append($"{condition.Item1} = '{condition.Item2}'");
            content = contentBuilder.ToString();
        }

        public SQLWhere NestWhere((string, string) condition, string logic)
        {
            nestedWhere = new SQLWhere((condition.Item1, condition.Item2));
            nestedWhere.logic = logic;
            return this;
        }

        private string PrintCondition()
        {
            if (nestedWhere != null)
                return nestedWhere.PrintCondition();
            return $"{logic} {content}";
        }

        public override string ToString()
        {
            if (nestedWhere != null)
                return $"WHERE {nestedWhere.PrintCondition()}";
            return $"WHERE {content.Remove(0, 3)}";
        }
    }
}
