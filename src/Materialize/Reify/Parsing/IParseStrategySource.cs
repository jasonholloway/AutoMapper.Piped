using Materialize.SourceRegimes;
using System;

namespace Materialize.Reify.Parsing
{
    internal interface IParseStrategySource
    {
        IParseStrategy GetStrategy(ParseContext ctx);
    }
}
