using Materialize.Expressions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class PredCountOnClientStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, int>
    {
        public PredCountOnClientStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) { }
                

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exPredicate = (Expression<Func<TElem, bool>>)((UnaryExpression)exSubject.Arguments[1]).Operand;

            return new Modifier(upstreamMod, exPredicate);
        }
                       

        class Modifier : ParseModifier<IEnumerable<TElem>, int>
        {
            Expression<Func<TElem, bool>> _exPredicate;

            public Modifier(IModifier upstreamMod, Expression<Func<TElem, bool>> exPredicate)
                : base(upstreamMod) 
            {
                _exPredicate = exPredicate;
            }

            
            protected override Expression ClientTransform(Expression exTransform) {
                return Expression.Call(
                            EnumerableMethods.CountPred.MakeGenericMethod(typeof(TElem)),
                            UpstreamClientTransform(exTransform),
                            _exPredicate);
            }




            //protected override Expression FetchMod(Expression exQuery) {
            //    return UpstreamFetchMod(exQuery);
            //}


            //protected override Expression TransformMod(Expression exQuery) {
            //    return Expression.Call(
            //                EnumerableMethods.CountPred.MakeGenericMethod(typeof(TElem)),
            //                UpstreamTransformMod(exQuery),
            //                _exPredicate);
            //}


            //protected override int Transform(object fetched) 
            //{
            //    throw new NotImplementedException();

            //    //var transformed = UpstreamTransform(fetched);
            //    //return transformed.Count(_exPredicate);
            //}
        }

    }
}
