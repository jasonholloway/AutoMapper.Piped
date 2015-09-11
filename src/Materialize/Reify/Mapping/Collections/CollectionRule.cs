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
            
            //NEED TO ENSURE DESTINATION TYPE IS CREATABLE ENUMERABLE
            //ie test is array, list, etc. Need to test against hash prob.
            //otherwise we will come a cropper

            if(tOrig.IsEnumerable()) {
                var collFactory = _collFactorySource.GetFactory(tDest);
                if(collFactory == null) return null;
                



            }




            if(tOrig.IsEnumerable() && tDest.IsEnumerable()) 
            {




                var tOrigElem = tOrig.GetEnumerableElementType();
                var tDestElem = tDest.GetEnumerableElementType();
                
                var elemStrategy = _strategySource.GetStrategy(
                                                        ctx.QueryRegime, 
                                                        tOrigElem, 
                                                        tDestElem);
                if(elemStrategy != null) {
                    //now branch out to cater for different collection types
                    //for each handler, see if emitted collection type would fit destination

                    //try list first
                    //then array
                    //then collection

                    //return base.CreateStrategy(
                    //                    typeof(DirectStrategy<,>),
                    //                    ctx.TypeVector,
                    //                    ctx);

                    throw new NotImplementedException();
                }
            }

            return null;
        }
    }
    
}
