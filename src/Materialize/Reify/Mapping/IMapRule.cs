using System;

namespace Materialize.Reify.Mapping
{
    internal interface IMapRule
    {
        IMapStrategy DeduceStrategy(MapContext ctx);
    }




}
