using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.CallParsing
{
    delegate ICallParser CallParserFactory(Parser parser);

    interface ICallParseRule
    {
        CallParserFactory GetParserFactory(CallParseContext ctx);
    }
}
