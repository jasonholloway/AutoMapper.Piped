using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.CollectionFactories
{
    public delegate object CollectionFactory(IEnumerable items);
    


    class ArrayFactory<TElem>
        : CollectionFactoryBase<TElem>
    {
        protected override object Create(IEnumerable<TElem> items) {
            return items.ToArray();
        }
    }
    

    class ListFactory<TElem>
        : CollectionFactoryBase<TElem>
    {
        protected override object Create(IEnumerable<TElem> items) {
            return new List<TElem>(items);
        }
    }
    

    abstract class CollectionFactoryBase<TElem> : ICollectionFactory
    {
        protected abstract object Create(IEnumerable<TElem> items);

        public object CreateCollection(IEnumerable items) {
            return Create(items.Cast<TElem>());
        }
    }
}
