using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Types
{
    internal static class DefaultValueFactory
    {
        static ConcurrentDictionary<Type, Func<object>> _dValueFacs
            = new ConcurrentDictionary<Type, Func<object>>();
        

        public static object GetForType(Type type) 
        {
            if(type.IsValueType) {                   
                if(type == typeof(int)) {
                    return default(int);
                }

                var valueFac = _dValueFacs.GetOrAdd(type, 
                                            t => Expression.Lambda<Func<object>>(
                                                                Expression.Convert(
                                                                        Expression.Default(t), 
                                                                        typeof(object))
                                                                ).Compile());

                return valueFac();
            }

            return null;
        }





    }
}
