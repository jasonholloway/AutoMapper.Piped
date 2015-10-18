using Materialize.Reify.Rebasing;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Quantifiers
{
    class PredQuantifierOnServerStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, bool>
    {
        IRebaseStrategy _predRebaseStrategy;

        public PredQuantifierOnServerStrategy(
            IParseStrategy upstreamStrategy, 
            IRebaseStrategy predRebaseStrategy)
            : base(upstreamStrategy) 
        {
            _predRebaseStrategy = predRebaseStrategy;
        }
        


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exRebasedQuantifier = _predRebaseStrategy.Rebase(exSubject);
            
            return new Modifier(upstreamMod, (MethodCallExpression)exRebasedQuantifier);
        }
                       


        class Modifier : ParseModifier<IQueryable<TElem>, bool>
        {
            MethodCallExpression _exRebasedQuantifier;

            public Modifier(IModifier upstreamMod, MethodCallExpression exRebasedQuantifier)
                : base(upstreamMod) 
            {
                _exRebasedQuantifier = exRebasedQuantifier;
            }
            

            protected override Expression Rewrite(Expression exQuery) 
            {                
                return _exRebasedQuantifier.Replace(
                                                _exRebasedQuantifier.Arguments[0], 
                                                exQuery);
            }


            protected override bool Transform(object fetched) {
                return (bool)fetched;
            }

        }

    }
}
