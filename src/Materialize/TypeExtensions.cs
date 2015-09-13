using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    internal static class TypeExtensions
    {
        public static bool IsEnumerable(this Type @this) {
            return @this.IsArray || typeof(IEnumerable).IsAssignableFrom(@this);
        }
        
        public static Type GetEnumerableElementType(this Type @this) 
        {            
            if(@this.IsArray) {
                return @this.GetElementType();
            }

            var tEnumerable = new[] { @this }
                                .Concat(@this.GetInterfaces())
                                .FirstOrDefault(t => t.IsGenericType
                                                && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            if(tEnumerable == null) {
                if(@this.IsEnumerable()) {
                    return typeof(object);
                }

                throw new ArgumentException("Passed type is not of IEnumerable<T>!", "type");
            }

            return tEnumerable.GetGenericArguments().First();
        }



    }
}
