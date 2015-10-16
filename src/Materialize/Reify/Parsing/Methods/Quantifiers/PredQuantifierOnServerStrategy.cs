using Materialize.Reify.Rebasing;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Quantifiers
{
    class PredQuantifierOnServerStrategy<TElem> 
        : MethodStrategyBase<IEnumerable<TElem>, bool>
    {
        IRebaseStrategy _predRebaseStrategy;

        public PredQuantifierOnServerStrategy(
            IParseStrategy upstreamStrategy, 
            IRebaseStrategy predRebaseStrategy)
            : base(upstreamStrategy) 
        {
            _predRebaseStrategy = predRebaseStrategy;
        }
               

        public override bool FiltersFetchedSet {
            get { return false; }
        }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exRebaseSubject = exSubject.Replace( //Don't even think this is necessary, as strategy will be in place, regardless of the expression type.
                                                exSubject.Arguments[0],
                                                Expression.Parameter(exSubject.Arguments[0].Type)
                                                );

            var exRebasedQuantifier = _predRebaseStrategy.Rebase(exRebaseSubject);
            
            return new Modifier(upstreamMod, (MethodCallExpression)exRebasedQuantifier);
        }
                       


        class Modifier : ParseModifier<IEnumerable<TElem>, bool>
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


            protected override bool Transform(object fetched) 
            {
                return (bool)fetched;
            }

        }

    }
}
