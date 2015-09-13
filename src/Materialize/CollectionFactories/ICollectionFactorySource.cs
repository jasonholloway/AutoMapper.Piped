using System;
using System.Collections;

namespace Materialize.CollectionFactories
{

    public delegate object CollectionFactory(IEnumerable items);


    public interface ICollectionFactorySource
    {
        CollectionFactory GetFactory(Type collType);
    }
}
