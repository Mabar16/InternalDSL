using InternalDSL.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL
{
    public interface SqlBuilderInterface
    {
        SqlBuilderInterface Select(params string[] args);
    }
}
