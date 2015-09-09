using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    static class Refl
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


        public static Type GetElementType(Type type) {
            var tEnumerable = new[] { type }
                                .Concat(type.GetInterfaces())
                                .FirstOrDefault(t => t.IsGenericType
                                                && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            if(tEnumerable == null) {
                throw new ArgumentException("Passed type is not of IEnumerable<T>!", "type");
            }

            return tEnumerable.GetGenericArguments().First();
        }

    }
}
