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
        MethodInfo _mEnQuantifier;


        public PredQuantifierOnClientStrategy(IParseStrategy upstreamStrategy, MethodInfo mQyQuantifierDef)
            : base(upstreamStrategy) 
        {
            var mEnQuantifierDef = EnumerableMethods.GetFromQueryableMethod(mQyQuantifierDef);
            _mEnQuantifier = mEnQuantifierDef.MakeGenericMethod(typeof(TElem));
        }
            


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exPredicate = (Expression<Func<TElem, bool>>)((UnaryExpression)exSubject.Arguments[1]).Operand;

            return new Modifier(upstreamMod, _mEnQuantifier, exPredicate);
        }
                       


        class Modifier : ParseModifier<IEnumerable<TElem>, bool>
        {
            Expression<Func<TElem, bool>> _exPredicate;
            MethodInfo _mEnQuantifier;

            public Modifier(IModifier upstreamMod, MethodInfo mEnQuantifier, Expression<Func<TElem, bool>> exPredicate)
                : base(upstreamMod) 
            {
                _mEnQuantifier = mEnQuantifier;
                _exPredicate = exPredicate;
            }
            

            protected override Expression FetchMod(Expression exSource) {
                return UpstreamFetchMod(exSource);
            }


            protected override Expression TransformMod(Expression exFetched) {
                return Expression.Call(
                                _mEnQuantifier,
                                UpstreamTransformMod(exFetched),
                                _exPredicate);
            }



            protected override bool Transform(object fetched) 
            {
                throw new NotImplementedException();

                //var transformed = UpstreamTransform(fetched);
                //return _fnApply(transformed);
            }

        }

    }
}
