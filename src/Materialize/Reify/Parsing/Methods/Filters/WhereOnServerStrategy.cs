using Materialize.Reify.Rebasing;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Types;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    class WhereOnServerStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, IEnumerable<TElem>>
    {
        IRebaseStrategy _predRebaseStrategy;

        public WhereOnServerStrategy(
            IParseStrategy upstreamStrategy, 
            IRebaseStrategy predRebaseStrategy)
            : base(upstreamStrategy) 
        {
            _predRebaseStrategy = predRebaseStrategy;
        }
               

        public override bool FiltersFetchedSet {
            get { return false; }
        }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exSubjectPredicate = (LambdaExpression)((UnaryExpression)exSubject.Arguments[1]).Operand;

            var exRebasedPredicate = (LambdaExpression)_predRebaseStrategy.Rebase(exSubjectPredicate);
            
            return new Modifier(upstreamMod, exRebasedPredicate);
        }
                       

        class Modifier : ParseModifier<IEnumerable<TElem>, IEnumerable<TElem>>
        {
            LambdaExpression _exRebasedPredicate;

            public Modifier(IModifier upstreamMod, LambdaExpression exRebasedPredicate)
                : base(upstreamMod) 
            {
                _exRebasedPredicate = exRebasedPredicate;
            }

            

            protected override Expression ServerFilter(Expression exQuery) {                
                return Expression.Call(
                                    QueryableMethods.Where.MakeGenericMethod(exQuery.Type.GetEnumerableElementType()),
                                    UpstreamServerFilter(exQuery),
                                    _exRebasedPredicate);
            }
            



            //protected override Expression FetchMod(Expression exSource) 
            //{                
            //    //var exStitched = _exRebasedPredicate.Replace(
            //    //                                    _exRebasedPredicate.Arguments[0], 
            //    //                                    exSource);

            //    var exWhere = Expression.Call(
            //                                QueryableMethods.Where.MakeGenericMethod(exSource.Type.GetEnumerableElementType()),
            //                                exSource,
            //                                _exRebasedPredicate);
                
            //    return UpstreamFetchMod(exWhere);
            //}


            //protected override Expression TransformMod(Expression exQuery) {
            //    return UpstreamTransformMod(exQuery);
            //}



            //protected override IEnumerable<TElem> Transform(object fetched) 
            //{                
            //    return UpstreamTransform(fetched);
            //}

        }

    }
}
