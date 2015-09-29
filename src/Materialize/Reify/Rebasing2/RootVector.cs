using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing2
{
    struct RootVector
    {
        public readonly ParameterExpression OrigRoot;
        public readonly ParameterExpression RebasedRoot;

        public RootVector(
            ParameterExpression origRoot,
            ParameterExpression rebasedRoot) 
        {
            OrigRoot = origRoot;
            RebasedRoot = rebasedRoot;
        }
    }

}
