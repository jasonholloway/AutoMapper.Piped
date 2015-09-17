using System.Collections.Generic;

namespace Materialize.Reify.Parsing
{
    interface IParseRuleRegistry
    {
        IEnumerable<IParseRule> Rules { get; }
    }
}
