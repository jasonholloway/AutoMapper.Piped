using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies
{
    class InputSpecSource
    {
        //public InputSpec[] GetAllInputsFrom(Type sourceType) 
        //{
        //    var typeInfo = GetTypeInfo(sourceType);

        //    return typeInfo.PublicReadAccessors
        //                    .Select(a => new InputSpec(a))
        //                    .ToArray();
        //}



        

        AutoMapper.TypeInfo GetTypeInfo(Type type) {
            return _lzFnGetTypeInfo.Value(type);
        }
        

        static Lazy<Func<Type, AutoMapper.TypeInfo>> _lzFnGetTypeInfo
            = new Lazy<Func<Type, AutoMapper.TypeInfo>>(() => BuildTypeInfoFetcher());
        

        static Func<Type, AutoMapper.TypeInfo> BuildTypeInfoFetcher() 
        {
            var typeMapFac = (TypeMapFactory)Mapper.Engine
                                                    .ConfigurationProvider.ServiceCtor(typeof(TypeMapFactory));

            var mGetTypeInfo = typeof(TypeMapFactory).GetMethod(
                                                        "GetTypeInfo",
                                                        BindingFlags.Instance | BindingFlags.NonPublic,
                                                        null,
                                                        new[] {
                                                            typeof(Type),
                                                            typeof(Func<PropertyInfo, bool>),
                                                            typeof(Func<FieldInfo, bool>),
                                                            typeof(IEnumerable<MethodInfo>)
                                                        },
                                                        null);

            var exParam = Expression.Parameter(typeof(Type));

            var exLambda = Expression.Lambda<Func<Type, AutoMapper.TypeInfo>>(
                                        Expression.Call(
                                                    Expression.Constant(typeMapFac),
                                                    mGetTypeInfo,
                                                    exParam,
                                                    Expression.Constant((Func<PropertyInfo, bool>)(p => true)),
                                                    Expression.Constant((Func<FieldInfo, bool>)(f => true)),
                                                    Expression.Constant(Enumerable.Empty<MethodInfo>())
                                                    ),
                                        exParam
                                        );

            return exLambda.Compile();
        }

    }
}
