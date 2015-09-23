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

            if(strInst.IsRooted) {
                var strMember = MemberStrategizer.GetStrategy(strInst, exMember.Member);
                return strMember;
            }

            if(strInst.IsActive) {
                return ActiveStrategy(
                            new TypeVector(exMember.Type, exMember.Type),
                            (MemberExpression x) => {
                                return Expression.MakeMemberAccess(
                                                    strInst.Rebase(x.Expression),
                                                    exMember.Member);
                            });
            }

            return PassiveStrategy(exMember.Type);            
        }
    }
}
