using InternalDSL.Sql.SQLComponents;

namespace InternalDSL.Sql
{
    public class SQLJoin : SQLClause
    {
        private string table;
        private string firstColumn;
        private string secondColumn;
        private string joinType;

        public SQLJoin(string table, (string, string) columnsToJoinOn)
        {
            this.table = table;
            firstColumn = columnsToJoinOn.Item1;
            secondColumn = columnsToJoinOn.Item2;
            joinType = string.Empty;
        }

        public SQLJoin(string table, (string, string) columnsToJoinOn, string type): this(table, columnsToJoinOn)
        {
            joinType = type;
        }

        public void SetJoinType(string type)
        {
            joinType = type;
        }

        public override string ToString()
        {
            return $"{joinType} JOIN {table} ON ({firstColumn} = {secondColumn})";
        }
    }
}