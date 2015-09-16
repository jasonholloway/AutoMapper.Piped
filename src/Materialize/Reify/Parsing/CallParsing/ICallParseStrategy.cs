using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.CallParsing
{
    delegate IModifier CallParser(MethodCallExpression exCall);
    
    interface ICallParseStrategy
    {
        bool FiltersFetchedSet { get; } //affects behavioural possibilities downstream...

        CallParser CreateCallParser(Parser parser);
    }
}
