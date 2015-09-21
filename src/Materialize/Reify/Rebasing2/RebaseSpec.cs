using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing2
{
    struct RebaseSpec
    {
        public readonly Type OriginalType;
        public readonly Type RebasedType;

        public RebaseSpec(Type originalType, Type rebasedType) {
            OriginalType = originalType;
            RebasedType = rebasedType;
        }

    }
}
