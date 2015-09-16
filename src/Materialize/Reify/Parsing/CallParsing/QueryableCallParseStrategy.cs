using System;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.CallParsing
{
    //Quietly does all the upstream-delegation-via-the-parser

    abstract class QueryableCallParseStrategy
        : ICallParseStrategy
    {
        public virtual bool FiltersFetchedSet {
            get { return false; }
        }

        protected abstract IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject);
        




        CallParser ICallParseStrategy.CreateCallParser(Parser parser) {
            return (ex) => {
                var exUpstream = ex.Arguments.First();
                var upstreamMod = parser.Parse(exUpstream);

                return Parse(upstreamMod, ex);
            };            
        }

    }

}
