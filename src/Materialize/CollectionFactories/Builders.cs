using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.CollectionFactories
{
    abstract class CollFactoryBuilder
    {
        static MethodInfo _mBuildGen = Refl.GetGenMethod<CollFactoryBuilder>(b => b.Build<object>());
                  
        public CollectionFactory Build(Type tElem) {
            return (CollectionFactory)_mBuildGen.MakeGenericMethod(tElem).Invoke(this, null);
        }
        
        public abstract CollectionFactory Build<TElem>();
    }



    class ArrayFactoryBuilder : CollFactoryBuilder
    {
        public override CollectionFactory Build<TElem>() {
            return (items) => items.Cast<TElem>().ToArray();
        }        
    }
    

    class ListFactoryBuilder : CollFactoryBuilder
    {
        public override CollectionFactory Build<TElem>() {
            return (items) => items.Cast<TElem>().ToList();
        }
    }    
}
