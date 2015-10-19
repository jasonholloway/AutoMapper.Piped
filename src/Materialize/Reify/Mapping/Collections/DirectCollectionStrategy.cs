using Materialize.CollectionFactories;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Mapping.Collections
{
    class DirectCollectionStrategy<TOrig, TOrigElem, TDestElem, TDest>
        : CollectionStrategyBase<TOrig, TOrigElem, TDestElem, TDest>
        where TOrig : IEnumerable<TOrigElem>
    {
        MapContext _ctx;
        CollectionFactory _collFactory;
        
        public DirectCollectionStrategy(
            MapContext ctx, 
            CollectionFactory collFactory, 
            IMapStrategy elemStrategy) 
            : base(elemStrategy)
        {
            _ctx = ctx;
            _collFactory = collFactory;
        }
        
        public override Type FetchType {
            get { return typeof(IEnumerable<TOrigElem>); }
        }

        public override bool RewritesExpression {
            get { return false; }
        }

        public override IModifier CreateModifier() {
            return new Mapper(_ctx, _collFactory, _elemStrategy);
        }
                
        

        class Mapper : MapperModifier<IEnumerable<TOrigElem>, IEnumerable<TOrigElem>, TDest>
        {
            MapContext _ctx;
            CollectionFactory _collFactory;
            IModifier _elemModifier;

            public Mapper(MapContext ctx, CollectionFactory collFactory, IMapStrategy elemStrategy) {
                _ctx = ctx;
                _collFactory = collFactory;
                _elemModifier = elemStrategy.CreateModifier();
            }
            
            protected override Expression FetchMod(Expression exSource) {
                return exSource;
            }



            protected override Expression TransformMod(Expression exFetched) {

                var exProjParam = Expression.Parameter(typeof(TOrigElem));

                var exProjLambda = Expression.Lambda<Func<TOrigElem, TDestElem>>(
                                                _elemModifier.TransformMod(exProjParam),
                                                exProjParam);

                var exEnum = Expression.Call(
                                    EnumerableMethods.Select.MakeGenericMethod(typeof(TOrigElem), typeof(TDestElem)),
                                    exFetched,
                                    exProjLambda);

                return Expression.Convert(
                            Expression.Call(
                                    Expression.Constant(_collFactory),
                                    "Invoke",
                                    null,
                                    exEnum),
                            typeof(TDest));
            }






            protected override TDest Transform(IEnumerable<TOrigElem> fetched) {
                var transformedElems = fetched
                                        .Select(elem => _elemModifier.Transform(elem));

                return (TDest)_collFactory(transformedElems); //wrap into proper destination collection type
            }
        }
                        

    }


}
