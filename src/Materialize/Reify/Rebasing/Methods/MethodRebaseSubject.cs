using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Rebasing.Methods
{
    struct MethodRebaseSubject
    {
        public readonly MethodCallExpression CallExp;
        
        public readonly MethodInfo Method;
        public readonly MethodInfo MethodDef;
        public readonly Type[] TypeArgs;

        public MethodRebaseSubject(MethodCallExpression exCall) 
        {
            CallExp = exCall;

            Method = exCall.Method;

            if(Method.IsGenericMethod) {
                MethodDef = Method.GetGenericMethodDefinition();
                TypeArgs = Method.GetGenericArguments();
            }
            else {
                MethodDef = null;
                TypeArgs = null;
            }
        }
                
    }


    


}
