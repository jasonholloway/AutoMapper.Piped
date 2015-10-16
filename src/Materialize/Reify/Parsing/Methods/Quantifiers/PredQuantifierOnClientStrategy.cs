using Materialize.Expressions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Quantifiers
{
    class PredQuantifierOnClientStrategy<TElem> 
        : MethodStrategyBase<IEnumerable<TElem>, IEnumerable<TElem>>
    {
        public PredQuantifierOnClientStrategy(IParseStrategy upstreamStrategy)
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
            
            var exLambda = Expression.Lambda<Func<IEnumerable<TElem>, bool>>(
                                        Expression.Call(
                                                    mEnumerableQuantifier,
                                                    exParam,
                                                    ((UnaryExpression)exSubject.Arguments[1]).Operand
                                                    ),
                                        exParam);

            var fnQuantifier = exLambda.Compile();
                        
            return new Modifier(upstreamMod, fnQuantifier);
        }
                       

        class Modifier : ParseModifier<IEnumerable<TElem>, bool>
        {
            Func<IEnumerable<TElem>, bool> _fnQuantifier;

            public Modifier(IModifier upstreamMod, Func<IEnumerable<TElem>, bool> fnQuantifier)
                : base(upstreamMod) 
            {
                _fnQuantifier = fnQuantifier;
            }
            

            protected override Expression Rewrite(Expression exQuery) {
                return UpstreamRewrite(exQuery);
            }


            protected override bool Transform(object fetched) 
            {                
                var transformed = UpstreamTransform(fetched);
                return _fnQuantifier((IEnumerable<TElem>)fetched);
            }

        }

    }
}
