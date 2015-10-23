using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2.Rebasing.Methods
{
    interface IMethodRebaseRule
    {
        bool Accepts(MethodRebaseSubject subject);
        IRebaseStrategy CreateStrategy(MethodRebaseSubject subject, IParentRebaser parentStrategizer);
    }
}
