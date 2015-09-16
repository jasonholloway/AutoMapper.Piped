using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.CallParsing.Unaries
{
    class FirstParser<TElem> 
        : QueryableMethodParser
    {
        static MethodInfo _mFirst = Refl.GetGenericMethodDef(() => Queryable.First<TElem>(null));


        public FirstParser(Parser parser)
            : base(parser) { }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) {
            return new Modifier(upstreamMod);
        }
        


        class Modifier : ParserModifier<IEnumerable<TElem>, TElem>
        {
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }
            
            protected override Expression Rewrite(Expression exQuery) {
                return Expression.Call(
                                    _mFirst.MakeGenericMethod(
                                                exQuery.Type.GetEnumerableElementType()),
                                    exQuery);
            }

            protected override TElem Transform(object fetched) {
                var rFetched = Array.CreateInstance(fetched.GetType(), 1);
                rFetched.SetValue(fetched, 0);

                var transformed = UpstreamTransform(rFetched);
                
                return transformed.First();
            }
        }

    }
}
