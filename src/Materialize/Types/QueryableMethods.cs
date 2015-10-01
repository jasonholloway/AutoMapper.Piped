using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Types
{
    static class QueryableMethods
    {
        public static MethodInfo SelectDef = Refl.GetGenMethod(
                                                    () => Queryable.Select<object, object>(null, i => i));

        public static MethodInfo WhereDef = Refl.GetGenMethod(
                                                    () => Queryable.Where<object>(null, i => true));

    }
}
