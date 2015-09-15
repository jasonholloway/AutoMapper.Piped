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


        public static TDest FirstOrDefault<TDest>(this IMaterializable<TDest> @this) 
        {
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return queryable.FirstOrDefault();
        }


        public static TDest Single<TDest>(this IMaterializable<TDest> @this) 
        {
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return queryable.Single();
        }


        public static TDest SingleOrDefault<TDest>(this IMaterializable<TDest> @this) 
        {
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return queryable.SingleOrDefault();
        }


        public static TDest Last<TDest>(this IMaterializable<TDest> @this) 
        {
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return queryable.Last();
        }

        public static TDest LastOrDefault<TDest>(this IMaterializable<TDest> @this) 
        {
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return queryable.LastOrDefault();
        }
     
        
        public static IMaterializable<TDest> Take<TDest>(this IMaterializable<TDest> @this, int count) 
        {
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return new Materializable<TDest>(queryable.Take(count));
        }


        public static IMaterializable<TDest> Skip<TDest>(this IMaterializable<TDest> @this, int count) 
        {
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return new Materializable<TDest>(queryable.Skip(count));
        }


        public static IMaterializable<TDest> Where<TDest>(
            this IMaterializable<TDest> @this, 
            Expression<Func<TDest, bool>> predicate) 
        {
            var queryable = ((Materializable<TDest>)@this).AsQueryable();
            return new Materializable<TDest>(queryable.Where(predicate));
        }



    }
}
