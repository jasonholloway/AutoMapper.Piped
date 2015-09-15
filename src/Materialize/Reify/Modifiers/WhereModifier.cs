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

    abstract class WhereModifier : IModifier
    {
        public abstract Expression Rewrite(Expression exQuery);
        public abstract object Transform(object fetched);


        public static WhereModifier Create(Type tElem, IModifier upstreamMod, Expression exTest) 
        {
            return (WhereModifier)Activator.CreateInstance(
                                                typeof(WhereModifier<>).MakeGenericType(tElem),
                                                upstreamMod,
                                                exTest);
        }

    }


    class WhereModifier<TElem> : WhereModifier
    {
        IModifier _upstreamModifier;
        Func<TElem, bool> _fnTest;

        public WhereModifier(
            IModifier upstreamModifier,
            Expression<Func<TElem, bool>> exFnTest)
        {
            _upstreamModifier = upstreamModifier;
            _fnTest = exFnTest.Compile();
        }


        public override Expression Rewrite(Expression exQuery) 
        {
            return _upstreamModifier.Rewrite(exQuery);
        }


        public override object Transform(object fetched)
        {
            var enTransformed = (IEnumerable<TElem>)_upstreamModifier
                                                        .Transform(fetched);

            return enTransformed.Where(_fnTest);
        }


        //There's an issue with unary operators! If any filtering, projections, etc occur 
        //client-side, then they can't just apply themselves to the source query.
        //They will be forced to be client-side too...

        //They need to know what they're working on to put in place the correct strategy.

        //And so, we need another structure of strategies to parse the ReifyQuery.
        //These could in part be keyed by MethodInfo, having asserted their suitability by the usual method.

        //But then the exact behaviour of each QueryHandler is to be determined at the last moment contextually.
        




    }
}
