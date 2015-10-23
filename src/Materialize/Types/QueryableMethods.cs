using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Types
{
    internal static class QueryableMethods
    {
        public static MethodInfo MapAs = Refl.GetGenMethod(
                                            () => QueryableExtensions.MapAs<object>(null));


        public static MethodInfo Select = Refl.GetGenMethod(
                                            () => Queryable.Select<object, object>(null, i => i));

        public static MethodInfo Where = Refl.GetGenMethod(
                                            () => Queryable.Where<object>(null, i => true));
        
        public static MethodInfo Skip = Refl.GetGenMethod(
                                            () => Queryable.Skip<object>(null, 0));

        public static MethodInfo Take = Refl.GetGenMethod(
                                            () => Queryable.Take<object>(null, 0));


        public static MethodInfo First = Refl.GetGenMethod(
                                            () => Queryable.First<object>(null));

        public static MethodInfo Single = Refl.GetGenMethod(
                                            () => Queryable.Single<object>(null));

        public static MethodInfo Last = Refl.GetGenMethod(
                                            () => Queryable.Last<object>(null));


        public static MethodInfo All = Refl.GetGenMethod(
                                            () => Queryable.All<object>(null, i => true));

        public static MethodInfo AnyPred = Refl.GetGenMethod(
                                            () => Queryable.Any<object>(null, i => true));



        public static MethodInfo Count = Refl.GetGenMethod(
                                            () => Queryable.Count<object>(null));

        public static MethodInfo CountPred = Refl.GetGenMethod(
                                            () => Queryable.Count<object>(null, i => true));


    }
}
