using Materialize.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reifiables
{   
    internal abstract class Reifiable
    {
        public abstract bool IsCompleted { get; }
        public abstract object Result { get; }
        
        public abstract Type OrigType { get; }
        public abstract Type ProjType { get; }
        public abstract Type DestType { get; }

        public event EventHandler<IEnumerable> Fetched;
        public event EventHandler<IEnumerable> Transformed;

        protected void OnFetched(IEnumerable elems) {
            if(Fetched != null) {
                Fetched(this, elems);
            }
        }

        protected void OnTransformed(IEnumerable elems) {
            if(Transformed != null) {
                Transformed(this, elems);
            }
        }    
        
    }


}
