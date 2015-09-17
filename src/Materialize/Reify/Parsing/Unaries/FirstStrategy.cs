using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Unaries
{
    class FirstStrategy<TElem> 
        : QueryableMethodStrategy
    {
        static MethodInfo _mFirstGen = Refl.GetGenericMethodDef(() => Queryable.First<object>(null));

        public FirstStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) { }
        
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //currently, though the rule knows the form of the expression, the actual
        //instance to be parsed must be passed here: this is because this is our only
        //way of accessing variable constant values. If all were converted to a 
        //parameterised lambda, then this could be different (though parameter values
        //would always have to be passed on each parse!!!

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            return new Modifier(upstreamMod);
        }
        


        class Modifier : ParseModifier<IEnumerable<TElem>, TElem>
        {
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }
            

            protected override Expression Rewrite(Expression exSourceQuery) 
            {
                var exInst = UpstreamRewrite(exSourceQuery);

                var mFirst = _mFirstGen.MakeGenericMethod(
                                        exInst.Type.GetEnumerableElementType());

                return Expression.Call(mFirst, exInst);
            }


            protected override TElem Transform(object fetched) 
            {
                var rFetched = Array.CreateInstance(fetched.GetType(), 1);
                rFetched.SetValue(fetched, 0);

                var transformed = UpstreamTransform(rFetched);
                
                return transformed.First();
            }
        }

    }
}
