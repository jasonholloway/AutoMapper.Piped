using System.Collections.Generic;

namespace Materialize.Reify.Mapping
{
    interface IMapRuleRegistry
    {
        IEnumerable<IMapRule> Rules { get; }
    }
}
