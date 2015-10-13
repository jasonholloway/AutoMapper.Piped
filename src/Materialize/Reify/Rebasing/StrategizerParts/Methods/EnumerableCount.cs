using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    partial class RebaseStrategizer
    {
        [Obsolete]
        IRebaseStrategy EnumerableCount(MethodCallExpression exCall) 
        {
            var upstreamStrategy = Visit(exCall.Arguments[0]);
            
            var tRebasedElem = upstreamStrategy.TypeVector
                                                    .DestType.GetEnumerableElementType();

            var mRebasedCount = EnumerableMethods.CountDef
                                                    .MakeGenericMethod(tRebasedElem);

            return UnrootedStrategy(
                        new TypeVector(typeof(int), typeof(int)),
                        (MethodCallExpression ex) => {
                            return Expression.Call(
                                                mRebasedCount,
                                                upstreamStrategy.Rebase(ex.Arguments[0])
                                                );
                        });                 
        }
    }
}
