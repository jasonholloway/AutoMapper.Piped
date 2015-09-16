using Materialize.SourceRegimes;
using System;

namespace Materialize.Reify.Parsing.CallParsing
{
    internal interface ICallParserProvider
    {
        ICallParser GetParser(Parser parser, CallParseContext ctx);
    }
}
