using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reification.Mods
{
    class SimpleUnaryMod : IReifyNode
    {
        MethodInfo _mUnary;

        public SimpleUnaryMod(MethodInfo mUnary) {
            _mUnary = mUnary;
        }

        public Expression TransformExpression(Expression exp) {            
            return Expression.Call(_mUnary, exp);
        }

        public object TransformFetched(object inp) {
            return inp;
        }
    }
}
