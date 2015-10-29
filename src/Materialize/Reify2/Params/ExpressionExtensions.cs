using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Params
{
    internal static class ExpressionExtensions
    {
        public static void ForEach(this Expression @this, Action<Expression, ExpressionPather.PathInfo> action) {
            new ExpressionPather(action).Path(@this);
        }
    }

}
