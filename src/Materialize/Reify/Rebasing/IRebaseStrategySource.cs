using Materialize.SourceRegimes;
using System;

namespace Materialize.Reify.Rebasing
{
    internal interface IRebaseStrategySource
    {
        IRebaseStrategy GetStrategy(RebaseContext ctx);
    }
}
