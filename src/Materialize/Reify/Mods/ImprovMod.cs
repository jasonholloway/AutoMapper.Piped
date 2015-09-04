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
        Func<Expression, Expression> _fnModQuery;
        Func<object, object> _fnModReified;

        public ImprovMod(
            Func<Expression, Expression> fnModQuery,
            Func<object, object> fnModReified = null) 
        {
            _fnModQuery = fnModQuery;
            _fnModReified = fnModReified;
        }

        public override Expression ModifySourceQuery(Expression exQuery) {
            return _fnModQuery(exQuery);
        }

        public override object ModifyReified(object reified) {
            return _fnModReified != null
                        ? _fnModReified(reified)
                        : reified;
        }
    }
}
