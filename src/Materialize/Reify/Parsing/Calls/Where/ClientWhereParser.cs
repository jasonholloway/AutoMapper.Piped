using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.CallParsing.Where
{
    class ClientWhereParser<TElem> 
        : QueryableMethodParser
    {
        static MethodInfo _mWhere = Refl.GetGenericMethodDef(() => Queryable.Where<TElem>(null, i => true));

        
        public ClientWhereParser(Parser parser)
            : base(parser) { }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) {
            throw new NotImplementedException();
            //return new Modifier(upstreamMod);
        }
                       

        class Modifier : ParserModifier<IEnumerable<TElem>, IEnumerable<TElem>>
        {
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }
            
            protected override Expression Rewrite(Expression exQuery) {
                return UpstreamRewrite(exQuery); //no rewrite, as nothing to do on server
            }

            protected override IEnumerable<TElem> Transform(object fetched) {                
                var transformed = UpstreamTransform(fetched);

                //return transformed.Where();

                throw new NotImplementedException();
            }
        }

    }
}
