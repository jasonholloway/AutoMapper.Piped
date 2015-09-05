using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Modifiers
{
    class AdLibModifier : IModifier
    {
        IModifier _upstreamModifier;
        Func<Expression, Expression> _fnRewrite;
        Func<object, object> _fnTransform;


        public AdLibModifier(
            IModifier upstreamModifier,
            Func<Expression, Expression> fnRewrite,
            Func<object, object> fnTransform = null) 
        {
            _upstreamModifier = upstreamModifier;
            _fnRewrite = fnRewrite;
            _fnTransform = fnTransform;
        }


        public Expression RewriteQuery(Expression exQuery) 
        {
            var ex = _upstreamModifier.RewriteQuery(exQuery);
            return _fnRewrite(ex);
        }


        public object TransformFetched(object fetched) 
        {
            var obj = _upstreamModifier.TransformFetched(fetched);

            return _fnTransform != null
                        ? _fnTransform(obj)
                        : obj;
        }
    }
}
