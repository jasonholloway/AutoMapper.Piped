using Materialize.Reifiables;
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
            Action<IEnumerable> fnOnFetched,
            Action<IEnumerable> fnOnTransformed = null)             
        {
            var mat = (Reifiable)@this;

            if(fnOnFetched != null) {
                mat.Fetched += new EventHandler<IEnumerable>((o, e) => fnOnFetched(e));
            }

            if(fnOnTransformed != null) {
                mat.Transformed += new EventHandler<IEnumerable>((o, e) => fnOnTransformed(e));
            }
            
            return @this;
        }
        
    }
}
