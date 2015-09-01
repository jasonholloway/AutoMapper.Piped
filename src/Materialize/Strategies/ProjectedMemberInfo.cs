using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies
{
    struct ProjectedMemberInfo<TSpec>
    {
        public readonly TSpec Spec;
        public readonly FieldInfo ProjectedField;

        public ProjectedMemberInfo(TSpec spec, FieldInfo projField) {
            Spec = spec;
            ProjectedField = projField;
        }
    }

}
