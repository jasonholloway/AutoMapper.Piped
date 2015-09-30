using Materialize.Reify.Rebasing2;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing
{
    //Quietly does all the upstream-delegation-via-the-parser

    abstract class QueryableMethodStrategy<TSource, TDest>
        : IParseStrategy
    {
        public QueryableMethodStrategy(IParseStrategy upstreamStrategy) 
        {
            SourceType = typeof(TSource);
            FetchType = typeof(TSource);
            DestType = typeof(TDest);
            UpstreamStrategy = upstreamStrategy;
        }

        public Type SourceType { get; private set; }        
        public Type FetchType { get; protected set; }
        public Type DestType { get; private set; }

        protected IParseStrategy UpstreamStrategy { get; private set; }
        
        public virtual bool FiltersFetchedSet {
            get { return UpstreamStrategy.FiltersFetchedSet; }
        }
        
                
        //as is, the expression is passed just so we can access variables - not for its form,
        //which should be felt out by the rule
        protected abstract IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject);
        
        IModifier IParseStrategy.Parse(Expression exSubject) {
            var exCall = (MethodCallExpression)exSubject;

            var upstreamMod = UpstreamStrategy.Parse(exCall.Arguments.First());

            return Parse(upstreamMod, exCall);
        }
        

        //by default, behaves as though nothing to rebase here - but this will often be right        
        public virtual IRebaseStrategy GetRebaseStrategy(RebaseSubject subject) 
        {
            Debug.Assert(
                subject.RootVectors.Single().OrigRoot.Type == DestType, 
                "Bad rebase attempted in parse layer!");

            return UpstreamStrategy.GetRebaseStrategy(subject);
        }
    }

}
