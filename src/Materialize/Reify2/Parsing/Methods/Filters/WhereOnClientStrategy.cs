using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2.Parsing.Methods.Filters
{
    class WhereOnClientStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, IEnumerable<TElem>>
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
                       

        class Modifier : ParseModifier<IEnumerable<TElem>, IEnumerable<TElem>>
        {
            Expression<Func<TElem, bool>> _exPredicate;

            public Modifier(IModifier upstreamMod, Expression<Func<TElem, bool>> exPredicate)
                : base(upstreamMod) 
            {
                _exPredicate = exPredicate;
            }

            

            protected override Expression ClientTransform(Expression exTransform) {
                return Expression.Call(
                            EnumerableMethods.Where.MakeGenericMethod(typeof(TElem)),
                            UpstreamClientTransform(exTransform),
                            _exPredicate);
            }




            //protected override Expression FetchMod(Expression exQuery) {
            //    return UpstreamFetchMod(exQuery);
            //}


            //protected override Expression TransformMod(Expression exQuery) {                
            //    return Expression.Call(
            //                EnumerableMethods.Where.MakeGenericMethod(typeof(TElem)),
            //                UpstreamTransformMod(exQuery),
            //                _exPredicate);
            //}



            //protected override IEnumerable<TElem> Transform(object fetched) 
            //{
            //    throw new NotImplementedException();

            //    //var transformed = UpstreamTransform(fetched);
            //    //return transformed.Where(_exPredicate);
            //}

        }

    }
}
