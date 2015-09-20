using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    class RootedExpression
    {
        public readonly ParameterExpression Root;
        public readonly Expression Subject;

        public RootedExpression(ParameterExpression exRoot, Expression exSubject) {
            Root = exRoot;
            Subject = exSubject;
        }
    }
}
