using Materialize.Reifiables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize
{
    public static class MaterializableExtensions
    {
        public static TDest First<TDest>(this IMaterializable<TDest> @this) 
        {
            var reifiable = (ReifiableSeries<TDest>)@this;

            //return reifiable.AsQueryable().First();
            
            if(reifiable.IsCompleted) {
                return ((IEnumerable<TDest>)reifiable).First();
            }
            else {
                var reifiableSingle = ReifiableSingle.Create(
                                                        reifiable,
                                                        exp => {
                                                            return Expression.Call(         //could be compiled...
                                                                        typeof(Queryable),
                                                                        "First",
                                                                        new[] { reifiable.OrigType },
                                                                        exp);
                                                        });

                return (TDest)reifiableSingle.Result;
            }
        }


        public static TDest FirstOrDefault<TDest>(this IMaterializable<TDest> @this) {
            throw new NotImplementedException();
        }


        public static TDest Single<TDest>(this IMaterializable<TDest> @this) {
            throw new NotImplementedException();
        }

        public static TDest SingleOrDefault<TDest>(this IMaterializable<TDest> @this) {
            throw new NotImplementedException();
        }


        public static TDest Last<TDest>(this IMaterializable<TDest> @this) 
        {
            var reifiable = (ReifiableSeries)@this;

            if(reifiable.IsCompleted) {
                return ((IEnumerable<TDest>)reifiable).Last();
            }
            else {
                var reifiableSingle = ReifiableSingle.Create(
                                                        reifiable,
                                                        exp => {
                                                            return Expression.Call(         //could be compiled...
                                                                        typeof(Queryable),
                                                                        "Last",
                                                                        new[] { reifiable.OrigType },
                                                                        exp);
                                                        });

                return (TDest)reifiableSingle.Result;
            }
        }

        public static TDest LastOrDefault<TDest>(this IMaterializable<TDest> @this) {
            throw new NotImplementedException();
        }
        
    }
}
