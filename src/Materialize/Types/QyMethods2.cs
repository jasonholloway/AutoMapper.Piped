using Materialize;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

internal static partial class QyMethods
{
    public static readonly MethodInfo MapAs = Refl.GetGenMethod(() => QueryableExtensions.MapAs<object>(null));
    
}
