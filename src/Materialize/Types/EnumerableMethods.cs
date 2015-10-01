using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Types
{
    static class EnumerableMethods
    {
        public static MethodInfo SelectDef = Refl.GetGenMethod(
                                                    () => Enumerable.Select<object, object>(null, i => i));

        public static MethodInfo WhereDef = Refl.GetGenMethod(
                                                    () => Enumerable.Where<object>(null, i => true));

        public static MethodInfo CountDef = Refl.GetGenMethod(
                                                    () => Enumerable.Count<object>(null));

        public static MethodInfo CountWithPredDef = Refl.GetGenMethod(
                                                           () => Enumerable.Count<object>(null, i => true));

    }
}
