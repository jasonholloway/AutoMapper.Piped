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
        IRebaseStrategy EnumerableAny(MethodCallExpression exCall) 
        {
            var upstreamStrategy = Visit(exCall.Arguments[0]);
            
            var tRebasedElem = upstreamStrategy.TypeVector
                                                    .DestType.GetEnumerableElementType();

            var mRebasedAny = EnumerableMethods.AnyDef
                                                 .MakeGenericMethod(tRebasedElem);

            return UnrootedStrategy(
                        new TypeVector(typeof(bool), typeof(bool)),
                        (MethodCallExpression ex) => {
                            return Expression.Call(
                                                mRebasedAny,
                                                upstreamStrategy.Rebase(ex.Arguments[0])
                                                );
                        });                       
            
        }
    }
}
