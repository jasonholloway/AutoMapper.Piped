using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

//namespace Materialize.Types
//{
//    internal static class EnMethods
//    {
//        public static MethodInfo Select = Refl.GetGenMethod(
//                                                    () => Enumerable.Select<object, object>(null, i => i));

//        public static MethodInfo Where = Refl.GetGenMethod(
//                                                    () => Enumerable.Where<object>(null, i => true));


//        public static MethodInfo Any = Refl.GetGenMethod(
//                                                    () => Enumerable.Any<object>(null));

//        public static MethodInfo AnyPred = Refl.GetGenMethod(
//                                                    () => Enumerable.Any<object>(null, o => true));

//        public static MethodInfo All = Refl.GetGenMethod(
//                                                    () => Enumerable.All<object>(null, o => true));

//        public static MethodInfo Count = Refl.GetGenMethod(
//                                                    () => Enumerable.Count<object>(null));

//        public static MethodInfo CountPred = Refl.GetGenMethod(
//                                                           () => Enumerable.Count<object>(null, i => true));

//        public static MethodInfo Single = Refl.GetGenMethod(
//                                                    () => Enumerable.Single<object>(null));


//        public static MethodInfo Skip = Refl.GetGenMethod(
//                                                    () => Enumerable.Skip<object>(null, 1));


//        public static MethodInfo Take = Refl.GetGenMethod(
//                                                    () => Enumerable.Take<object>(null, 1));



//        public static MethodInfo GetFromQueryableMethod(MethodInfo mQueryable) {
//            return _dQueryable2Enumerable[mQueryable];
//        }



//        static T Exec<T>(Func<T> fn) { return fn(); }


//        static IDictionary<MethodInfo, MethodInfo> _dQueryable2Enumerable
//            = Exec(() => {
//                var dEnMethods = typeof(EnMethods)
//                                            .GetFields(BindingFlags.Static | BindingFlags.Public)
//                                            .Where(f => f.FieldType == typeof(MethodInfo))
//                                            .ToDictionary(f => f.Name, f => (MethodInfo)f.GetValue(null));

//                var tups = typeof(QyMethods)
//                                .GetFields(BindingFlags.Static | BindingFlags.Public)
//                                .Where(f => f.FieldType == typeof(MethodInfo))
//                                .Select(f => new {
//                                    Name = f.Name,
//                                    QueryableMethod = (MethodInfo)f.GetValue(null),
//                                    EnumerableMethod = dEnMethods.ContainsKey(f.Name) 
//                                                        ? dEnMethods[f.Name]
//                                                        : null
//                                });

//                return tups.Where(t => t.EnumerableMethod != null)
//                            .ToDictionary(t => t.QueryableMethod, t => t.EnumerableMethod);
//            });
               


//    }
//}
