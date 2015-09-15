using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Unaries
{
    class FirstOrDefaultStrategy<TElem> : ParseStrategy<TElem>
    {
        public override IModifier CreateModifier(IModifier upstreamMod) {
            return new Modifier(upstreamMod);
        }
               

        class Modifier : ParserModifier<IEnumerable<TElem>, TElem>
        {            
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }

            protected override Expression Rewrite(Expression exQuery) {                
                return exQuery;
            }

            protected override TElem Transform(IEnumerable<TElem> fetched) {                
                return fetched.FirstOrDefault();
            }
        }

    }
}
