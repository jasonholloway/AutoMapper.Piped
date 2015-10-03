﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Types
{
    internal static class TypeExtensions
    {
        public static bool IsEnumerable(this Type @this) {
            return @this.IsArray || typeof(IEnumerable).IsAssignableFrom(@this);
        }

        public static bool IsQueryable(this Type @this) {
            return typeof(IQueryable).IsAssignableFrom(@this);
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



        /// <summary>
        /// Resolves the lowest base class of a type, excluding the universal object type
        /// </summary>
        public static Type GetLowestBaseClass(this Type @this) {
            var t = @this;

            while(t.BaseType != null && t.BaseType != typeof(object)) {
                t = t.BaseType;
            }

            return t;
        }

        


    }
}
