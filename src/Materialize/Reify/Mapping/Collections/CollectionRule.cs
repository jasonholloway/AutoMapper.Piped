using Materialize.CollectionFactories;
using System;
using System.Linq.Expressions;

namespace Materialize.Reify.Mapping.Collections
{
    class CollectionRule : MapRuleBase
    {
        IMapStrategySource _strategySource;
        ICollectionFactorySource _collFactorySource;


        public CollectionRule(
            IMapStrategySource strategySource, 
            ICollectionFactorySource collFactorySource) 
        {
            _strategySource = strategySource;
            _collFactorySource = collFactorySource;
        }


        public override IMapStrategy DeduceStrategy(MapContext ctx) 
        {
            var tOrig = ctx.TypeVector.SourceType;
            var tDest = ctx.TypeVector.DestType;
            
            if(tOrig.IsEnumerable()) {
                var collFactory = _collFactorySource.GetFactory(tDest);
                if(collFactory == null) return null;
                
                var tOrigElem = tOrig.GetEnumerableElementType();
                var tDestElem = tDest.GetEnumerableElementType();
                
                var elemStrategy = _strategySource.GetStrategy(
                                                        ctx.QueryRegime, 
                                                        tOrigElem, 
                                                        tDestElem);

                if(elemStrategy != null) {
                    if(elemStrategy.RewritesExpression) {
                        var tMedElem = elemStrategy.FetchedType;

                        return base.CreateStrategy(
                                            typeof(CollectionStrategy<,,,>)
                                                .MakeGenericType(tOrigElem, tMedElem, tDestElem, tDest),
                                            ctx,
                                            collFactory,
                                            elemStrategy);
                    }
                    else {
                        return base.CreateStrategy(
                                            typeof(DirectCollectionStrategy<,,>)
                                                .MakeGenericType(tOrigElem, tDestElem, tDest),
                                            ctx,
                                            collFactory,
                                            elemStrategy);
                    }                    
                }
            }

            return null;
        }
    }
    
}
