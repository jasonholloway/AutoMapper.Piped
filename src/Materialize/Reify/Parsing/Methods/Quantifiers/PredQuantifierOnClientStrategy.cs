using Materialize.Expressions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Quantifiers
{
    class PredQuantifierOnClientStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, bool>
    {
        delegate bool Applicator(IQueryable<TElem> input, Expression<Func<TElem, bool>> predicate);
        
        Applicator _fnApply = null;


        public PredQuantifierOnClientStrategy(IParseStrategy upstreamStrategy, MethodInfo mQuantifier)
            : base(upstreamStrategy) 
        {
            _fnApply = CompileApplicator(mQuantifier);             
        }
            
        
        
        Applicator CompileApplicator(MethodInfo mQuantifier) 
        {
            var exInput = Expression.Parameter(typeof(IQueryable<TElem>));
            var exPredicate = Expression.Parameter(typeof(Expression<Func<TElem, bool>>));

            var exLambda = Expression.Lambda<Applicator>(
                                        Expression.Call(
                                                    mQuantifier,
                                                    exInput,
                                                    exPredicate),
                                        exInput,
                                        exPredicate);

            return exLambda.Compile();
        }




        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exPredicate = (Expression<Func<TElem, bool>>)((UnaryExpression)exSubject.Arguments[1]).Operand;

            return new Modifier(upstreamMod, inp => _fnApply(inp, exPredicate));
        }
                       


        class Modifier : ParseModifier<IQueryable<TElem>, bool>
        {
            Func<IQueryable<TElem>, bool> _fnApply;

            public Modifier(IModifier upstreamMod, Func<IQueryable<TElem>, bool> fnApply)
                : base(upstreamMod) 
            {
                _fnApply = fnApply;
            }
            

            protected override Expression Rewrite(Expression exQuery) {
                return UpstreamRewrite(exQuery);
            }


            protected override bool Transform(object fetched) 
            {                
                var transformed = UpstreamTransform(fetched);
                return _fnApply(transformed);
            }

        }

    }
}
