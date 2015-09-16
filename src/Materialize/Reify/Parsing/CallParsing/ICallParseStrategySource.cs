using Materialize.SourceRegimes;
using System;

namespace Materialize.Reify.Parsing.CallParsing
{
    internal interface ICallParseStrategySource
    {
        ICallParseStrategy GetStrategy(CallParseContext ctx);
    }
}
