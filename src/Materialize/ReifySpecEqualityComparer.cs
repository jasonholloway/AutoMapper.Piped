using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    class ReifySpecEqualityComparer : IEqualityComparer<ReifySpec>
    {
        public static readonly ReifySpecEqualityComparer Default = new ReifySpecEqualityComparer();

        public bool Equals(ReifySpec x, ReifySpec y) {
            return x.SourceType == y.SourceType
                    && x.DestType == y.DestType;
        }

        public int GetHashCode(ReifySpec obj) {
            return obj.SourceType.GetHashCode() ^ obj.DestType.GetHashCode();
        }
    }
}
