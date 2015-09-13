using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.CollectionFactories
{
    abstract class CollFactoryBuilder
    {
        static MethodInfo _mTypedBuild = typeof(CollFactoryBuilder).GetMethod(
                                                                        "TypedBuild", 
                                                                        BindingFlags.Instance 
                                                                        | BindingFlags.NonPublic);

        public CollectionFactory Build(Type tElem) {
            return (CollectionFactory)_mTypedBuild.MakeGenericMethod(tElem).Invoke(this, null);
        }
        
        protected abstract CollectionFactory TypedBuild<TElem>();
    }



    class ArrayFactoryBuilder : CollFactoryBuilder
    {
        protected override CollectionFactory TypedBuild<TElem>() {
            return (items) => items.Cast<TElem>().ToArray();
        }        
    }
    

    class ListFactoryBuilder : CollFactoryBuilder
    {
        protected override CollectionFactory TypedBuild<TElem>() {
            return (items) => items.Cast<TElem>().ToList();
        }
    }    
}
