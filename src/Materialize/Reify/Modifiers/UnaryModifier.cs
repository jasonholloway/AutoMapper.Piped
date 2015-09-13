using System;
using System.Collections;
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

    //On transformation however, this modifier will be the first encountered,
    //and so we have to package the fetched single object into an enumerable
    //to pass up the modifier stack.

             
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


        public Expression Rewrite(Expression exQuery) 
        {
            var ex = _upstreamModifier.Rewrite(exQuery);

            var tElem = ex.Type.GetEnumerableElementType();

            var mTypedUnary = _mUnaryGenDef.MakeGenericMethod(tElem);

            return Expression.Call(mTypedUnary, ex);
        }


        public object Transform(object fetched) 
        {
            var rFetched = Array.CreateInstance(fetched.GetType(), 1);
            rFetched.SetValue(fetched, 0);

            var enTransformed = (IEnumerable)_upstreamModifier.Transform(rFetched);

            return enTransformed.OfType<object>().Single();
        }

    }
}
