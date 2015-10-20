using Materialize.Reify.Rebasing;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;

namespace Materialize.Reify.Parsing.Methods.Quantifiers
{
    class PredQuantifierOnServerStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, bool>
    {
        IRebaseStrategy _predRebaseStrategy;
        MethodInfo _mQyQuantifier;

        public PredQuantifierOnServerStrategy(
            IParseStrategy upstreamStrategy, 
            IRebaseStrategy predRebaseStrategy,
            MethodInfo mQyQuantifierDef)
            : base(upstreamStrategy) 
        {
            _predRebaseStrategy = predRebaseStrategy;
            _mQyQuantifier = mQyQuantifierDef.MakeGenericMethod(typeof(TSource).GetEnumerableElementType());

            FetchType = typeof(bool);
        }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exSubjectPredicate = ((UnaryExpression)exSubject.Arguments[1]).Operand;

            var exRebasedPredicate = (LambdaExpression)_predRebaseStrategy.Rebase(exSubjectPredicate);
            
            return new Modifier(upstreamMod, _mQyQuantifier, exRebasedPredicate);
        }
                       


        class Modifier : ParseModifier<IEnumerable<TElem>, bool>
        {
            LambdaExpression _exRebasedPredicate;
            MethodInfo _mQyQuantifier;

            public Modifier(IModifier upstreamMod, MethodInfo mQyQuantifier, LambdaExpression exRebasedPredicate)
                : base(upstreamMod) 
            {
                _mQyQuantifier = mQyQuantifier;
                _exRebasedPredicate = exRebasedPredicate;
            }
                        

            protected override Expression ServerProject(Expression exQuery) {
                return Expression.Call(
                                    _mQyQuantifier,
                                    exQuery, //short-circuit
                                    _exRebasedPredicate);
            }

            protected override Expression ClientTransform(Expression exTransform) {
                return exTransform; //short-circuit
            }




            //protected override Expression FetchMod(Expression exQuery) 
            //{
            //    return Expression.Call(
            //                        _mQyQuantifier,
            //                        exQuery,
            //                        _exRebasedPredicate);
            //}


            //protected override Expression TransformMod(Expression exQuery) {
            //    return exQuery;
            //}



            //protected override bool Transform(object fetched) {
            //    return (bool)fetched;
            //}

        }

    }
}
