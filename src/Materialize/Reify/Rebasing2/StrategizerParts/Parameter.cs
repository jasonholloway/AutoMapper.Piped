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
            ParameterExpression exNewParam = null;

            if(Roots.TryGetValue(exParam, out exNewParam)) {
                return RootedStrategy(
                            new TypeVector(exParam.Type, exNewParam.Type),
                            (ParameterExpression x) => exNewParam);
            }

            return PassiveStrategy(exParam.Type);
        }        
    }
}
