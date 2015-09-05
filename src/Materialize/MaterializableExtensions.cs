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
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return queryable.First();
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
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return queryable.Last();
        }

        public static TDest LastOrDefault<TDest>(this IMaterializable<TDest> @this) {
            throw new NotImplementedException();
        }
        
    }
}
