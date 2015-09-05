using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    static class ReflectionHelper
    {
        public static MethodInfo GetMethod(Expression<Action> exAction) 
        {
            var exCall = exAction.Body as MethodCallExpression;

            if(exCall == null) {
                throw new ArgumentException("Must represent method call!", "exAction");
            }

            return exCall.Method;
        } 


        public static MethodInfo GetGenericMethodDef(Expression<Action> exAction) 
        {
            return GetMethod(exAction).GetGenericMethodDefinition();
        }

    }
}
