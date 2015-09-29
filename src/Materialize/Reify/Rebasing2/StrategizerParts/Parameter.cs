using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer 
    {
        protected override IRebaseStrategy VisitParameter(ParameterExpression exParam) 
        {
            ParameterExpression exRebasedRoot = null;

            if(_dRootVectors.TryGetValue(exParam, out exRebasedRoot)) {
                return _rootStrategyProvider(
                                new TypeVector(exParam.Type, exRebasedRoot.Type),
                                exRebasedRoot);
            }
                        
            return PassiveStrategy(exParam.Type);
        }        
    }
}
