using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class Rebaser 
    {
        protected override Rebased VisitConstant(ConstantExpression constant) {
            return Rebased.Passive(constant);
        }        
    }
}
