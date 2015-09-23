using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class Rebaser 
    {
        protected override Rebased VisitMemberAccess(MemberExpression exMember) 
        {
            var resInst = Visit(exMember.Expression);

            if(resInst.IsRebased) {                
                var exRebased = MemberRebaser.Rebase(resInst, exMember.Member);

                return Rebased.Active(
                                exRebased,
                                exMember.Type,  //reckon this should really be supplied by IMemberRebaser
                                exRebased.Type); 
            }

            return Rebased.Passive(exMember);
        }
    }
}
