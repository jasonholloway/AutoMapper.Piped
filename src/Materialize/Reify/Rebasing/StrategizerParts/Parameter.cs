using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    partial class RebaseStrategizer 
    {
        protected override IRebaseStrategy VisitParameter(ParameterExpression exParam) 
        {                        
            return PassiveStrategy(exParam.Type);
        }        
    }
}
