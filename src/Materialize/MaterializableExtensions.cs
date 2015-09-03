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
            var reifiable = (Reifiable)@this;

            if(reifiable.IsCompleted) {
                return ((IEnumerable<TDest>)reifiable).First();
            }
            else {
                //get original query out of parent
                //and modify it, creating new reifiable

                

                var newExp = Expression.Call(
                                        typeof(Queryable),
                                        "First",
                                        new[] { reifiable.OrigType },
                                        reifiable.QueryExpression
                                        );

                var newReifiable = ReifiableSingle.Create(
                                                        null,
                                                        newExp,
                                                        typeof(TDest));

                return newReifiable.Result;
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


        public static TDest Last<TDest>(this IMaterializable<TDest> @this) {
            throw new NotImplementedException();
        }

        public static TDest LastOrDefault<TDest>(this IMaterializable<TDest> @this) {
            throw new NotImplementedException();
        }
        
    }
}
