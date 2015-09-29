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

            if(strInst is IRootedRebaseStrategy) {
                var strMember = ((IRootedRebaseStrategy)strInst).Expand(exMember);

                if(strMember != null) {
                    return strMember;
                }
            }
            
            if(strInst is PassiveRebaseStrategy) {
                return PassiveStrategy(exMember.Type);
            }
            
            return Strategy(
                        new TypeVector(exMember.Type, exMember.Type),
                        (MemberExpression x) => {
                            return Expression.MakeMemberAccess(
                                                strInst.Rebase(x.Expression),
                                                exMember.Member);
                        });
        }
    }
}
