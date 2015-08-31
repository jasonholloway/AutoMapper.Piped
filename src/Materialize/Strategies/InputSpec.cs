using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies
{
    struct InputSpec
    {
        public readonly MemberInfo MemberInfo;

        public InputSpec(MemberInfo memberInfo) {
            MemberInfo = memberInfo;
        }
    }
}
