using System;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing
{
    //Quietly does all the upstream-delegation-via-the-parser

    abstract class QueryableMethodStrategy
        : IParseStrategy
    {
        IParseStrategy _upstreamStrategy;

        public QueryableMethodStrategy(IParseStrategy upstreamStrategy) {
            _upstreamStrategy = upstreamStrategy;
        }


        public virtual bool FiltersFetchedSet {
            get { return false; }
        }
        
        //as is, the expression is passed just so we can access variables - not for its form,
        //which should be felt out by the rule
        protected abstract IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject);
        
        IModifier IParseStrategy.Parse(Expression exSubject) {
            var exCall = (MethodCallExpression)exSubject;

            var upstreamMod = _upstreamStrategy.Parse(exCall.Arguments.First());

            return Parse(upstreamMod, exCall);
        }
        

    }

}
