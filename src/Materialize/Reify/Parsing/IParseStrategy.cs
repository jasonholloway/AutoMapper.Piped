using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{
    //Unlike MapStrategies, which form quasi-static hierarchies,
    //ParseStrategies are more loosely assembled

    //Each incoming query is read clause by clause



    interface IParseStrategy
    {
        IModifier CreateModifier(IModifier upstreamMod);
    }
}
