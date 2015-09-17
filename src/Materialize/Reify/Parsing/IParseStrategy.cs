using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing
{
    interface IParseStrategy
    {
        bool FiltersFetchedSet { get; } //affects behavioural possibilities downstream...
        IModifier Parse(Expression exSubject);
    }
}
