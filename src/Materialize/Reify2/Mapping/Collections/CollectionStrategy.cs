using Materialize.CollectionFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Materialize.Reify2.Rebasing;
using Materialize.Reify2.Parsing;
using Materialize.Types;
using System.ComponentModel;

namespace Materialize.Reify2.Mapping.Collections
{
    /// <summary>
    /// Maps collections by delegating to an element MapStrategy; creates and populates target collection by chosen CollectionFactory
    /// </summary>
    class CollectionStrategy<TOrig, TOrigElem, TMedElem, TDestElem, TDest>
        : CollectionStrategyBase<TOrig, TOrigElem, TDestElem, TDest>
        where TOrig : IEnumerable<TOrigElem>
    {
        MapContext _ctx;
        CollectionFactory _collFactory;
        
        public CollectionStrategy(
            MapContext ctx, 
            CollectionFactory collFactory, 
            IMapStrategy elemStrategy) 
            : base(elemStrategy)
        {
            _ctx = ctx;
            _collFactory = collFactory;
        }
        
        public override Type FetchType {
            get { return typeof(IEnumerable<TMedElem>); }
        }
        
        public override IModifier CreateModifier() {
            return new Mapper(_collFactory, _elemStrategy);
        }



        class Mapper : MapperModifier<IEnumerable<TOrigElem>, IEnumerable<TMedElem>, TDest>
        {
            static MethodInfo _mQueryableSelect = Refl.GetMethod(() => Queryable.Select(null, (Expression<Func<TOrigElem, TMedElem>>)null));
            static MethodInfo _mEnumerableSelect = Refl.GetMethod(() => Enumerable.Select(null, (Func<TOrigElem, TMedElem>)null));


            CollectionFactory _collFactory;
            IMapStrategy _elemStrategy;
            IModifier _elemModifier;

            public Mapper(
                CollectionFactory collFactory,
                IMapStrategy elemStrategy) {
                _collFactory = collFactory;
                _elemStrategy = elemStrategy;
                _elemModifier = elemStrategy.CreateModifier();
            }

            
            protected override Expression ServerProject(Expression exQuery) 
            {
                var exInParam = Expression.Parameter(typeof(TOrigElem));
                var exLambdaBody = _elemModifier.ServerProject(exInParam);

                return Expression.Call(
                            exQuery.Type.IsQueryable()
                                        ? _mQueryableSelect
                                        : _mEnumerableSelect,
                            exQuery,
                            Expression.Lambda(
                                        typeof(Func<TOrigElem, TMedElem>),
                                        exLambdaBody,
                                        exInParam)
                            );
            }


            protected override Expression ClientTransform(Expression exTransform) 
            {
                var exProjParam = Expression.Parameter(typeof(TMedElem));

                var exProjLambda = Expression.Lambda<Func<TMedElem, TDestElem>>(
                                                _elemModifier.ClientTransform(exProjParam),
                                                exProjParam);

                var exEnum = Expression.Call(
                                    EnumerableMethods.Select.MakeGenericMethod(typeof(TMedElem), typeof(TDestElem)),
                                    exTransform,
                                    exProjLambda);

                return Expression.Convert(
                            Expression.Call(
                                    Expression.Constant(_collFactory),
                                    "Invoke",
                                    null,
                                    exEnum),
                            typeof(TDest));
            }

        }






        //    protected override Expression FetchMod(Expression exFetch) 
        //    {
        //        var exInParam = Expression.Parameter(typeof(TOrigElem));
        //        var exLambdaBody = _elemModifier.FetchMod(exInParam);
                
        //        return Expression.Call(
        //                            exFetch.Type.IsQueryable()
        //                                            ? _mQueryableSelect
        //                                            : _mEnumerableSelect,
        //                            exFetch,
        //                            Expression.Lambda(
        //                                        typeof(Func<TOrigElem, TMedElem>),
        //                                        exLambdaBody,
        //                                        exInParam)
        //                            );
        //    }








        //    protected override Expression TransformMod(Expression exTransform) 
        //    {
        //        var exProjParam = Expression.Parameter(typeof(TMedElem));

        //        var exProjLambda = Expression.Lambda<Func<TMedElem, TDestElem>>(
        //                                        _elemModifier.TransformMod(exProjParam),
        //                                        exProjParam);
                
        //        var exEnum = Expression.Call(
        //                            EnumerableMethods.Select.MakeGenericMethod(typeof(TMedElem), typeof(TDestElem)),
        //                            exTransform,
        //                            exProjLambda);

        //        return Expression.Convert(
        //                    Expression.Call(
        //                            Expression.Constant(_collFactory),
        //                            "Invoke",
        //                            null,
        //                            exEnum),
        //                    typeof(TDest));
        //    }



        //    protected override TDest Transform(IEnumerable<TMedElem> fetched) {
        //        var transformedElems = fetched
        //                                .Select(elem => _elemModifier.Transform(elem));
                
        //        return (TDest)_collFactory(transformedElems);
        //    }
        //}
        
    }


}
