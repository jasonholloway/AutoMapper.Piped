using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing2
{
    struct StrategizedRootVector
    {
        public readonly ParameterExpression OrigRoot;
        public readonly ParameterExpression RebasedRoot;
        public readonly IRebaseStrategy RebaseStrategy;
        
        public StrategizedRootVector(
            ParameterExpression origRoot,
            ParameterExpression rebasedRoot,
            IRebaseStrategy rebaseStrategy) 
        {
            OrigRoot = origRoot;
            RebasedRoot = rebasedRoot;
            RebaseStrategy = rebaseStrategy;
        }
    }

}
