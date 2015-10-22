using System.Collections.Generic;

namespace Materialize.Reify2.Mapping
{
    interface IMapRuleRegistry
    {
        IEnumerable<IMapRule> Rules { get; }
    }
}
