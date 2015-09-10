using Materialize.Reify;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Infrastructure
{
    public static class MaterializableSnoopingExtensions
    {
        public static IMaterializable<TDest> SnoopOnQuery<TDest>(
            this IMaterializable<TDest> @this,
            Action<IQueryable> fnOnQuery)
        {
            var mat = (Materializable)@this;

            mat.Queried += new EventHandler<IQueryable>((o, q) => fnOnQuery(q));
            
            return @this;
        }

        
        public static IMaterializable<TDest> SnoopOnFetched<TDest>(
            this IMaterializable<TDest> @this,
            Action<IEnumerable<object>> fnOnFetched)
        {
            var mat = (Materializable)@this;
            
            mat.Fetched += new EventHandler<IEnumerable>((o, e) => fnOnFetched(e.Cast<object>()));
            
            return @this;
        }


        public static IMaterializable<TDest> SnoopOnTransformed<TDest>(
            this IMaterializable<TDest> @this,
            Action<IEnumerable<TDest>> fnOnTransformed) 
        {
            var mat = (Materializable)@this;

            mat.Transformed += new EventHandler<IEnumerable>((o, e) => fnOnTransformed(e.Cast<TDest>()));

            return @this;
        }


    }
}
