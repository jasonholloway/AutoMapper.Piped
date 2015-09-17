using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Unaries
{
    class FirstOrDefaultStrategy<TElem> 
        : QueryableMethodStrategy
    {
        static MethodInfo _mFirstGen = Refl.GetGenericMethodDef(() => Queryable.FirstOrDefault<object>(null));


        public FirstOrDefaultStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) { }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) {
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
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //if default has been returned due to lack of data, we 
                //shouldn't then send that default through mapping etc.
                //Should just emplace default(TElem) here.
                //
                //TO DO!
                //...

                throw new NotImplementedException("See note in class");

                var rFetched = Array.CreateInstance(fetched.GetType(), 1);
                rFetched.SetValue(fetched, 0);

                var transformed = UpstreamTransform(rFetched);
                   
                return transformed.FirstOrDefault();
            }
        }

    }
}
