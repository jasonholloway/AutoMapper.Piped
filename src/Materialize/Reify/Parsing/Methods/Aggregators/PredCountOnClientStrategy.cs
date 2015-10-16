using Materialize.Expressions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class PredCountOnClientStrategy<TElem> 
        : MethodStrategyBase<IEnumerable<TElem>, IEnumerable<TElem>>
    {
        public PredCountOnClientStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) { }
                

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //GHASTLY!!!!!!!!!!!!!!!!!!!!!!!
            //have to parameterize... but this will do for demo

            var tElem = exSubject.Arguments[0].Type.GetEnumerableElementType();

            var exParam = Expression.Parameter(typeof(IEnumerable<>).MakeGenericType(tElem));

            var mEnumerableQuantifier = EnumerableMethods
                                            .GetFromQueryableMethod(exSubject.Method.GetGenericMethodDefinition())
                                            .MakeGenericMethod(tElem);                                                            
            
            var exLambda = Expression.Lambda<Func<IEnumerable<TElem>, int>>(
                                        Expression.Call(
                                                    mEnumerableQuantifier,
                                                    exParam,
                                                    ((UnaryExpression)exSubject.Arguments[1]).Operand
                                                    ),
                                        exParam);

            var fnCount = exLambda.Compile();
                        
            return new Modifier(upstreamMod, fnCount);
        }
                       

        class Modifier : ParseModifier<IEnumerable<TElem>, int>
        {
            Func<IEnumerable<TElem>, int> _fnCount;

            public Modifier(IModifier upstreamMod, Func<IEnumerable<TElem>, int> fnCount)
                : base(upstreamMod) 
            {
                _fnCount = fnCount;
            }
            

            protected override Expression Rewrite(Expression exQuery) {
                return UpstreamRewrite(exQuery);
            }


            protected override int Transform(object fetched) 
            {                
                var transformed = UpstreamTransform(fetched);
                return _fnCount((IEnumerable<TElem>)fetched);
            }

        }

    }
}
