using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify2.Parsing.Methods.Aggregators
{
    class CountOnClientStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, int>
    {
        public CountOnClientStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) { }

        
        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod);
        }
        

        class Modifier : ParseModifier<IEnumerable<TElem>, int>
        {
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }

            
            protected override Expression ClientTransform(Expression exTransform) {
                return Expression.Call(
                            EnumerableMethods.Count.MakeGenericMethod(typeof(TElem)),
                            UpstreamClientTransform(exTransform));
            }





            //protected override Expression FetchMod(Expression exSourceQuery) {
            //    return UpstreamFetchMod(exSourceQuery);
            //}


            //protected override Expression TransformMod(Expression exQuery) {
            //    return Expression.Call(
            //                EnumerableMethods.Count.MakeGenericMethod(typeof(TElem)),
            //                UpstreamTransformMod(exQuery));
            //}



            //protected override int Transform(object fetched) {
            //    throw new NotImplementedException();
                  
            //    //var transformed = UpstreamTransform(fetched);
            //    //return transformed.Count();
            //}

        }

    }
}
