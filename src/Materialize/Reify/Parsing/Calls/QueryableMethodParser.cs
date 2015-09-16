using System;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.CallParsing
{
    abstract class QueryableMethodParser
        : ICallParser
    {
        Parser _parser;

        public QueryableMethodParser(Parser parser) {
            _parser = parser;
        }

        protected abstract IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject);

        IModifier ICallParser.Parse(MethodCallExpression exSubject) 
        {
            var exUpstream = exSubject.Arguments.First();
            var upstreamMod = _parser.Parse(exUpstream);
            
            return Parse(upstreamMod, exSubject);
        }

    }

}
