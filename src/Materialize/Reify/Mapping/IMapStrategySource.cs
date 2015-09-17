using Materialize.SourceRegimes;
using System;

namespace Materialize.Reify.Mapping
{
    internal interface IMapStrategySource
    {
        IMapStrategy GetStrategy(ISourceRegime regime, Type tSource, Type tDest);
        IMapStrategy GetStrategy(MapContext mapContext);
    }
}
