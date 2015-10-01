using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Rebasing
{
    partial class RebaseStrategizer 
    {
        delegate IRebaseStrategy MethodHandler(RebaseStrategizer strategizer, MethodCallExpression exCall);
        
        IDictionary<MethodInfo, MethodHandler> _dMethodHandlers
            = new Dictionary<MethodInfo, MethodHandler>() {
                { QueryableMethods.WhereDef, (@this, ex) => @this.QueryableWhere(ex) },
                { EnumerableMethods.CountDef, (@this, ex) => @this.EnumerableCount(ex) }
            };


        protected override IRebaseStrategy VisitMethodCall(MethodCallExpression exCall) 
        {
            if(exCall.Method.IsGenericMethod) 
            {
                var methodDef = exCall.Method.GetGenericMethodDefinition();

                var strategy = _dMethodHandlers[methodDef](this, exCall);

                return strategy;
            }
            
            throw new NotImplementedException("Unhandled MethodCallExpression!");
        }
    }
}
