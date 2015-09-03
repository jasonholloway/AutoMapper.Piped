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
            var mat = (Reifiable)@this;

            if(mat.IsMaterialized) {
                return ((IEnumerable<TDest>)mat).First();
            }
            else {                 
                var newMat = mat.SpawnWithModifiedQuery(ex => {
                    return Expression.Call(
                                        typeof(Queryable),
                                        "First",
                                        new[] { mat.OrigType },
                                        ex              //THIS WON'T WORK COS NOT QUERYABLE!!!!!! - would have to access via Execute.
                                        );              //which requires a special Materializable
                });

                return ((IEnumerable<TDest>)newMat).Single();
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



        public static IEnumerable<TDest> Take<TDest>(this IMaterializable<TDest> @this, int count) {
            throw new NotImplementedException();
        }

        public static IEnumerable<TDest> Skip<TDest>(this IMaterializable<TDest> @this, int count) {
            throw new NotImplementedException();
        }
        
    }
}
