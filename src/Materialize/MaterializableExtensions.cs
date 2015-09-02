using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    public static class MaterializableExtensions
    {
        public static TDest First<TDest>(this IMaterializable<TDest> @this) {
            var subject = (Materializable<TDest, TDest, TDest>)@this;
            
            throw new NotImplementedException();
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
