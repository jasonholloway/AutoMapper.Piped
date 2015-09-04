using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mods
{
    class ImprovMod : ModBase
    {
        Func<Expression, Expression> _fnRewrite;
        Func<object, object> _fnTransform;

        public ImprovMod(
            Func<Expression, Expression> fnRewrite,
            Func<object, object> fnTransform = null) 
        {
            _fnRewrite = fnRewrite;
            _fnTransform = fnTransform;
        }

        public override Expression RewriteQuery(Expression exQuery) {
            return _fnRewrite(exQuery);
        }

        public override object TransformFetched(object fetched) {
            return _fnTransform != null
                        ? _fnTransform(fetched)
                        : fetched;
        }
    }
}
