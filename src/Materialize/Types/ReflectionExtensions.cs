using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Types
{
    internal static class ReflectionExtensions
    {

        public static Type GetMemberType(this MemberInfo @this) {
            if(@this is FieldInfo) {
                return ((FieldInfo)@this).FieldType;
            }

            if(@this is PropertyInfo) {
                return ((PropertyInfo)@this).PropertyType;
            }

            if(@this is MethodInfo) {
                return ((MethodInfo)@this).ReturnType;
            }

            throw new NotImplementedException();
        }


        public static string GetNiceName(this MemberInfo @this) {
            return string.Format(
                            "{0}.{1}",
                            @this.DeclaringType.GetNiceName(),
                            @this.Name);

            //not fully implemented: would be nice to print arg types too
        }


    }
}
