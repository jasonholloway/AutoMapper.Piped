using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing
{
    struct RebaseMap
    {
        public readonly Type OrigType;
        public readonly Type RebasedType;

        public RebaseMap(Type tOrig, Type tRebased) {
            OrigType = tOrig;
            RebasedType = tRebased;
        }

    }



    //a visitor would be more efficient, and would be more programmable.
    //would still have to supply handlers for everything possible - eventually.
    //unhandled expression-parts would throw exception, which, when caught, could
    //signal server rejection.

    //Without caching, the case for strategies is more slender.
    //


}
