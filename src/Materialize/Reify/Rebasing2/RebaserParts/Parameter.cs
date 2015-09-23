using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class Rebaser 
    {
        protected override Rebased VisitParameter(ParameterExpression exParam) 
        {
            ParameterExpression exNewParam = null;

            if(Roots.TryGetValue(exParam, out exNewParam)) {
                return Rebased.Active(
                                exNewParam, 
                                exParam.Type,
                                exNewParam.Type);
            }

            return Rebased.Passive(exParam);
        }        
    }
}
