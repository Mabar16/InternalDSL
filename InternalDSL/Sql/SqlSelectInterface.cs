using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL.Sql
{
    public interface SqlSelectInterface
    {
        SqlBuilderInterface Where(string text);
    }
}
