using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public interface SqlQueryInterface
    {
        SqlBuilderInterface Where(string text);
    }
}
