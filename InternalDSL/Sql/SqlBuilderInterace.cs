using InternalDSL.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDSL
{
    public interface SqlBuilderInterface
    {
        SQLSelect Select(params string[] args);
    }
}
