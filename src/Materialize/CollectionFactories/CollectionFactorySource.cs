using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.Types;

namespace Materialize.CollectionFactories
{
    class CollectionFactorySource : ICollectionFactorySource
    {
        CollFactoryBuilder _arrayFactoryBuilder = new ArrayFactoryBuilder();
        CollFactoryBuilder _listFactoryBuilder = new ListFactoryBuilder();
        CollFactoryBuilder _enumerableQueryFactoryBuilder = new EnumerableQueryFactoryBuilder();

        public CollectionFactory GetFactory(Type collType) 
        {
            if(collType.IsArray && collType.GetArrayRank() == 1) {
                var elemType = collType.GetElementType();
                return _arrayFactoryBuilder.Build(elemType);
            }
                        
            if(collType.IsEnumerable()) {
                var elemType = collType.GetEnumerableElementType();

                var listType = typeof(List<>).MakeGenericType(elemType);

                if(collType.IsAssignableFrom(listType)) {
                    return _listFactoryBuilder.Build(elemType);
                }

                var enumerableQueryType = typeof(EnumerableQuery<>).MakeGenericType(elemType);

                if(collType.IsAssignableFrom(enumerableQueryType)) {
                    return _enumerableQueryFactoryBuilder.Build(elemType);
                }
             }

            return null;
        }
    }
    

}
