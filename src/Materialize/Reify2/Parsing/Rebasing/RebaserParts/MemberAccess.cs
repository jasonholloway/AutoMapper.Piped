﻿using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Rebasing
{
    partial class Rebaser 
    {
        protected override IRebaseStrategy VisitMemberAccess(MemberExpression exMember) 
        {
            var strInstance = Visit(exMember.Expression);

            var strMember = strInstance.Expand(exMember);

            if(strMember != null) {
                return strMember;
            }
            else {
                return UnrootedStrategy(
                            new TypeVector(exMember.Type, exMember.Type),
                            (MemberExpression x) => {
                                return Expression.MakeMemberAccess(
                                                    strInstance.Rebase(x.Expression),
                                                    exMember.Member);
                            });
            }
        }
    }
}
