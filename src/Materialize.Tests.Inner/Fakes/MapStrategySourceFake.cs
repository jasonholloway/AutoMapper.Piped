using Materialize.Reify2.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Inner.Fakes
{
    class MapStrategySourceFake : IMapStrategySource
    {
        public IMapStrategy GetStrategy(MapContext mapContext) {
            return new MapStrategyFake(mapContext);
        }
    }
}
