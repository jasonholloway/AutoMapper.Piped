using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Modifiers
{
    //For simple unary clauses such as Queryable.First, correctly-typed versions
    //of the same unary method should be appended to the source query: that is,
    //after the mapping projection, and therefore limiting what is fetched.

    //No additional transformations on fetched are needed, as the mapping transformers
    //should be agnostic as to quantity.
             
    class UnaryModifier : IModifier
    {
        IModifier _upstreamModifier;
        MethodInfo _mUnaryGenDef;

        public UnaryModifier(
            IModifier upstreamModifier,
            MethodInfo mUnaryGenDef)
        {
            _upstreamModifier = upstreamModifier;
            _mUnaryGenDef = mUnaryGenDef;
        }


        public Expression RewriteQuery(Expression exQuery) 
        {
            var ex = _upstreamModifier.RewriteQuery(exQuery);

            var tElem = ex.Type.GetEnumerableElementType();

            var mTypedUnary = _mUnaryGenDef.MakeGenericMethod(tElem);

            return Expression.Call(mTypedUnary, ex);
        }


        public object TransformFetched(object fetched) 
        {
            return _upstreamModifier.TransformFetched(fetched);
        }
    }
}
