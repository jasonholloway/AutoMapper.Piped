using Materialize.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{
    abstract class ReifyStrategy : IReifyStrategy
    {        
        public virtual IEnumerable<IReifyStrategy> UpstreamStrategies {
            get { return Enumerable.Empty<IReifyStrategy>(); }
        }
    }
}
