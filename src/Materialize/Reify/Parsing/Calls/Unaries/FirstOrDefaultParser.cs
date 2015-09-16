using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.CallParsing.Unaries
{
    class FirstOrDefaultParser<TElem> 
        : QueryableMethodParser
    {
        public FirstOrDefaultParser(Parser parser)
            : base(parser) { }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            throw new NotImplementedException();
        }



        class Modifier : ParserModifier<IEnumerable<TElem>, TElem>
        {            
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }

            protected override Expression Rewrite(Expression exQuery) {               
                
                //append firstordefault
                //...
                 
                return exQuery;
            }

            protected override TElem Transform(object fetched) {

                //package in array to send upstream
                //...

                var upstream = UpstreamTransform(fetched);

                return upstream.FirstOrDefault();
            }
        }

    }
}
