using Materialize.Reify.Rebasing;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Types;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class PredCountOnServerStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, int>
    {
        IRebaseStrategy _predRebaseStrategy;

        public PredCountOnServerStrategy(
            IParseStrategy upstreamStrategy, 
            IRebaseStrategy predRebaseStrategy)
            : base(upstreamStrategy) 
        {
            FetchType = typeof(int);
            _predRebaseStrategy = predRebaseStrategy;
        }
                      

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exSubjectPredicate = ((UnaryExpression)exSubject.Arguments[1]).Operand;

            var exRebasedPredicate = (LambdaExpression)_predRebaseStrategy.Rebase(exSubjectPredicate);
            
            return new Modifier(upstreamMod, exRebasedPredicate);
        }
                       


        class Modifier : ParseModifier<IEnumerable<TElem>, int>
        {
            LambdaExpression _exRebasedPredicate;

            public Modifier(IModifier upstreamMod, LambdaExpression exRebasedPredicate)
                : base(upstreamMod) 
            {
                _exRebasedPredicate = exRebasedPredicate;
            }

            
            protected override Expression ServerProject(Expression exQuery) {
                return Expression.Call(
                                    EnumerableMethods.CountPred.MakeGenericMethod(exQuery.Type.GetEnumerableElementType()),
                                    exQuery, //short-circuit
                                    _exRebasedPredicate);
            }

            protected override Expression ClientTransform(Expression exTransform) {
                return exTransform; //short-circuit
            }



            //protected override Expression FetchMod(Expression exQuery) 
            //{
            //    //as usual, no care about upstream changes to cardinality
            //    //intervening filtering is just ignored!!!!!!

            //    return Expression.Call(
            //                        EnumerableMethods.CountPred.MakeGenericMethod(exQuery.Type.GetEnumerableElementType()),
            //                        exQuery, //UpstreamFetchMod(exQuery), //!!!! cuts short !!!!!
            //                        _exRebasedPredicate);                
            //}


            //protected override Expression TransformMod(Expression exQuery) {
            //    return exQuery;
            //}



            //protected override int Transform(object fetched) {
            //    return (int)fetched;
            //}

        }

    }
}
