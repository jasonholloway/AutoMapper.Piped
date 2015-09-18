using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Unaries
{
    class UnaryOnClientStrategy<TElem> 
        : QueryableMethodStrategy<IEnumerable<TElem>, TElem>
    {
        static Dictionary<MethodInfo, MethodInfo> _dEnumerableMethodDefs
            = new Dictionary<MethodInfo, MethodInfo>() {
                {
                    Refl.GetGenMethod(() => Queryable.First<int>(null)),
                    Refl.GetGenMethod(() => Enumerable.First<int>(null))
                },
                {
                    Refl.GetGenMethod(() => Queryable.Single<int>(null)),
                    Refl.GetGenMethod(() => Enumerable.Single<int>(null))
                },
                {
                    Refl.GetGenMethod(() => Queryable.Last<int>(null)),
                    Refl.GetGenMethod(() => Enumerable.Last<int>(null))
                },
                {
                    Refl.GetGenMethod(() => Queryable.FirstOrDefault<int>(null)),
                    Refl.GetGenMethod(() => Enumerable.FirstOrDefault<int>(null))
                },
                {
                    Refl.GetGenMethod(() => Queryable.SingleOrDefault<int>(null)),
                    Refl.GetGenMethod(() => Enumerable.SingleOrDefault<int>(null))
                },
                {
                    Refl.GetGenMethod(() => Queryable.LastOrDefault<int>(null)),
                    Refl.GetGenMethod(() => Enumerable.LastOrDefault<int>(null))
                }
            };


        Func<IEnumerable<TElem>, TElem> _fnEnumUnary;


        public UnaryOnClientStrategy(IParseStrategy upstreamStrategy, MethodInfo mUnaryDef)
            : base(upstreamStrategy) 
        {
            FetchType = UpstreamStrategy.FetchType;

            _fnEnumUnary = GetEnumUnaryMethod(mUnaryDef);
        }
        

        //This kind of stuff could of course be centrally cached
        Func<IEnumerable<TElem>, TElem> GetEnumUnaryMethod(MethodInfo queryMethodDef) 
        {
            var enumMethodDef = _dEnumerableMethodDefs[queryMethodDef];

            var exParam = Expression.Parameter(typeof(IEnumerable<TElem>));

            var exLambda = Expression.Lambda<Func<IEnumerable<TElem>, TElem>>(
                                        Expression.Call(
                                            enumMethodDef.MakeGenericMethod(typeof(TElem)),
                                            exParam),
                                        exParam);

            return exLambda.Compile();
        }


        
        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod, _fnEnumUnary);
        }
        

        class Modifier : ParseModifier<IEnumerable<TElem>, TElem>
        {
            Func<IEnumerable<TElem>, TElem> _fnEnumUnary;

            public Modifier(
                    IModifier upstreamMod, 
                    Func<IEnumerable<TElem>, TElem> fnEnumUnary) 
                : base(upstreamMod) 
            {
                _fnEnumUnary = fnEnumUnary;
            }            
        
                
            protected override Expression Rewrite(Expression exSourceQuery) 
            {
                return UpstreamRewrite(exSourceQuery);
            }
            
            protected override TElem Transform(object fetched) 
            {
                var transformed = UpstreamTransform(fetched);
                return _fnEnumUnary(transformed);
            }
        }

    }
}
