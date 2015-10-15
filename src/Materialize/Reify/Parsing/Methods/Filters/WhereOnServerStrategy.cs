using Materialize.Reify.Rebasing;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    class WhereOnServerStrategy<TElem> 
        : MethodStrategy<IEnumerable<TElem>, IEnumerable<TElem>>
    {
        IRebaseStrategy _predRebaseStrategy;

        public WhereOnServerStrategy(
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

            var exRebasedWhere = _predRebaseStrategy.Rebase(exRebaseSubject);

            return new Modifier(upstreamMod, (MethodCallExpression)exRebasedWhere);
        }
                       

        class Modifier : ParseModifier<IEnumerable<TElem>, IEnumerable<TElem>>
        {
            MethodCallExpression _exRebasedWhere;

            public Modifier(IModifier upstreamMod, MethodCallExpression exRebasedWhere)
                : base(upstreamMod) 
            {
                _exRebasedWhere = exRebasedWhere;
            }
            

            protected override Expression Rewrite(Expression exQuery) 
            {                
                var exAppended = _exRebasedWhere.Replace(
                                                    _exRebasedWhere.Arguments[0], 
                                                    exQuery);
                
                return UpstreamRewrite(exAppended); //no rewrite, as nothing to do on server
            }


            protected override IEnumerable<TElem> Transform(object fetched) 
            {                
                return UpstreamTransform(fetched);
            }

        }

    }
}
