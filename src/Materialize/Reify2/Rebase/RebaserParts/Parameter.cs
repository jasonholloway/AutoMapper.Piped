﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Rebase
{
    partial class Rebaser 
    {
        protected override IRebaseStrategy VisitParameter(ParameterExpression exParam) 
        {                        
            return PassiveStrategy(exParam.Type);
        }        
    }
}
