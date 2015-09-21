using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Info
{
    static class QueryableMethods
    {
        public static MethodInfo SelectDef = Refl.GetGenMethod(
                                                    () => Queryable.Select<object, object>(null, i => i));

        public static MethodInfo WhereDef = Refl.GetGenMethod(
                                                    () => Queryable.Where<object>(null, i => true));

    }
}
