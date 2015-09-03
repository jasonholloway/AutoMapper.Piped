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
        //protected readonly object Sync;
        
        public event EventHandler<IEnumerable> Fetched;
        public event EventHandler<IEnumerable> Transformed;
        
        public abstract Type OrigType { get; }
        public abstract Type ProjType { get; }
        public abstract Type DestType { get; }

        public abstract bool IsMaterialized { get; }

        public abstract Reifiable SpawnWithModifiedQuery(Func<Expression, Expression> fnModifyExpression);


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
     

        //-----------------------------------------------------------------------------


        public static IMaterializable<TDest> Create<TDest>(IQueryable qyOrig) {
            //should create singles too...
            //...

            var tOrig = qyOrig.ElementType;
            var tDest = typeof(TDest);
            
            var rootStrategy = StrategySource.Default.GetStrategy(tOrig, tDest);

            var tProj = rootStrategy.ProjectedType;

            return (IMaterializable<TDest>)Activator.CreateInstance(
                                                        typeof(ReifiableSeries<,,>)
                                                                    .MakeGenericType(tOrig, tProj, tDest),
                                                        qyOrig,
                                                        rootStrategy);
        }

    }


}
