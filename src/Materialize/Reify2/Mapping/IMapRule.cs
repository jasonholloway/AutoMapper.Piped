using System;

namespace Materialize.Reify2.Mapping
{
    internal interface IMapRule
    {
        IMapStrategy DeduceStrategy(MapContext ctx);
    }




}
