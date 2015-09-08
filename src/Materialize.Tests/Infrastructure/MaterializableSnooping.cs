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
        public static IMaterializable<TDest> Snoop<TDest>(
            this IMaterializable<TDest> @this,
            Action<IEnumerable<object>> fnOnFetched,
            Action<IEnumerable<TDest>> fnOnTransformed = null)             
        {
            var mat = (Materializable)@this;

            if(fnOnFetched != null) {
                mat.Fetched += new EventHandler<IEnumerable>((o, e) => fnOnFetched(e.Cast<object>()));
            }

            if(fnOnTransformed != null) {
                mat.Transformed += new EventHandler<IEnumerable>((o, e) => fnOnTransformed(e.Cast<TDest>()));
            }
            
            return @this;
        }
        
    }
}
