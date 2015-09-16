using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.CallParsing
{
    interface ICallParseRule
    {
        ICallParseStrategy GetStrategy(CallParseContext ctx);
    }
}
