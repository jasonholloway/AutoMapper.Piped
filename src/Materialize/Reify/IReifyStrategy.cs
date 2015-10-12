using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{
    //All parse & map strategies will implement the below, which will be used in inspecting strategization

    public interface IReifyStrategy
    {
        IEnumerable<IReifyStrategy> UpstreamStrategies { get; }
    }
}
