using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    partial class Rebaser 
    {
        protected override IRebaseStrategy VisitLambda(LambdaExpression exLambda) 
        {
            return PassiveStrategy(exLambda.Type);            
        }
    }
}
