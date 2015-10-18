using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    class WhereOnClientStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, IQueryable<TElem>>
    {
        
        public WhereOnClientStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) { }
               

        public override bool FiltersFetchedSet {
            get { return true; }
        }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exPredicate = (Expression<Func<TElem, bool>>)((UnaryExpression)exSubject.Arguments[1]).Operand;
                        
            return new Modifier(upstreamMod, exPredicate);
        }
                       

        class Modifier : ParseModifier<IQueryable<TElem>, IQueryable<TElem>>
        {
            Expression<Func<TElem, bool>> _exPredicate;

            public Modifier(IModifier upstreamMod, Expression<Func<TElem, bool>> exPredicate)
                : base(upstreamMod) 
            {
                _exPredicate = exPredicate;
            }
            

            protected override Expression Rewrite(Expression exQuery) {
                return UpstreamRewrite(exQuery); //no rewrite, as nothing to do on server
            }


            protected override IQueryable<TElem> Transform(object fetched) 
            {                
                var transformed = UpstreamTransform(fetched);
                return transformed.Where(_exPredicate);
            }

        }

    }
}
