using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Rebasing2
{
    interface IMemberRebaser
    {
        Expression Rebase(Rebased instance, MemberInfo member);
    }
}
