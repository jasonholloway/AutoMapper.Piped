﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Types
{
    static class QueryableMethods
    {
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


    }
}
