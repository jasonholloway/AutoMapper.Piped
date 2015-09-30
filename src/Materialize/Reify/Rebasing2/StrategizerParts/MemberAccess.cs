using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer 
    {
        protected override IRebaseStrategy VisitMemberAccess(MemberExpression exMember) 
        {
            var strInst = Visit(exMember.Expression);

            var strExpanded = strInst.Expand(exMember);

            if(strExpanded != null) {
                return strExpanded;
            }
            else {
                return UnrootedStrategy(
                            new TypeVector(exMember.Type, exMember.Type),
                            (MemberExpression x) => {
                                return Expression.MakeMemberAccess(
                                                    strInst.Rebase(x.Expression),
                                                    exMember.Member);
                            });
            }
        }
    }
}
