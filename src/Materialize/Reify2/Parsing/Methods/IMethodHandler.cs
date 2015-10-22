using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing.Methods
{
    interface IMethodHandler
    {
        ParseContext Context { set; }
        ParseStrategySource ParseStrategySource { set; }

        IParseStrategy Strategize();
    }
}
