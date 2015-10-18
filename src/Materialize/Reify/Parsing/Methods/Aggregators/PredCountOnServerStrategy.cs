using Materialize.Reify.Rebasing;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class PredCountOnServerStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, bool>
    {
        IRebaseStrategy _predRebaseStrategy;

        public PredCountOnServerStrategy(
            IParseStrategy upstreamStrategy, 
            IRebaseStrategy predRebaseStrategy)
            : base(upstreamStrategy) 
        {
            _predRebaseStrategy = predRebaseStrategy;
        }
                      

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exRebasedCall = (MethodCallExpression)_predRebaseStrategy.Rebase(exSubject);
            
            return new Modifier(upstreamMod, exRebasedCall);
        }
                       


        class Modifier : ParseModifier<IQueryable<TElem>, int>
        {
            MethodCallExpression _exRebasedCall;

            public Modifier(IModifier upstreamMod, MethodCallExpression exRebasedCall)
                : base(upstreamMod) 
            {
                _exRebasedCall = exRebasedCall;
            }
            

            protected override Expression Rewrite(Expression exQuery) 
            {                
                //as usual, no care about upstream changes to cardinality

                return _exRebasedCall.Replace(
                                        _exRebasedCall.Arguments[0], 
                                        exQuery);
            }


            protected override int Transform(object fetched) {
                return (int)fetched;
            }

        }

    }
}
