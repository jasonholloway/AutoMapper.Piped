using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Types
{
    internal static class Refl
    {
        public static Type GetMemberType(MemberInfo member) {
            if(member is PropertyInfo) {
                return ((PropertyInfo)member).PropertyType;
            }

            if(member is FieldInfo) {
                return ((FieldInfo)member).FieldType;
            }

            if(member is MethodInfo) {
                return ((MethodInfo)member).ReturnType;
            }

            throw new NotImplementedException();
        }


        public static MethodInfo GetMethod<TInst>(Expression<Action<TInst>> exAction) {
            var exCall = exAction.Body as MethodCallExpression;

            if(exCall == null) {
                throw new ArgumentException("Must represent method call!", "exAction");
            }

            return exCall.Method;
        }

        public static MethodInfo GetMethod(Expression<Action> exAction) 
        {
            var exCall = exAction.Body as MethodCallExpression;

            if(exCall == null) {
                throw new ArgumentException("Must represent method call!", "exAction");
            }

            return exCall.Method;
        } 


        public static MethodInfo GetGenMethod(Expression<Action> exAction) 
        {
            return GetMethod(exAction).GetGenericMethodDefinition();
        }

        public static MethodInfo GetGenMethod<TInst>(Expression<Action<TInst>> exAction) {
            return GetMethod(exAction).GetGenericMethodDefinition();
        }
        


    }
}
