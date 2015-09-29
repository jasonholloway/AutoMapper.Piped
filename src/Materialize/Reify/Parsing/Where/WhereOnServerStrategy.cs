using Materialize.Reify.Rebasing2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Where
{
    class WhereOnServerStrategy<TElem> 
        : QueryableMethodStrategy<IEnumerable<TElem>, IEnumerable<TElem>>
    {
        IRebaseStrategy _rebaseStrategy;

        public WhereOnServerStrategy(
            IParseStrategy upstreamStrategy, 
            IRebaseStrategy rebaseStrategy)
            : base(upstreamStrategy) 
        {
            _rebaseStrategy = rebaseStrategy;
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

            var exRebasedWhere = _rebaseStrategy.Rebase(exRebaseSubject);

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
