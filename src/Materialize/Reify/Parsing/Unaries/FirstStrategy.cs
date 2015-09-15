using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.Unaries
{
    class FirstStrategy<TElem> : ParseStrategy<TElem>
    {
        static MethodInfo _mFirst = Refl.GetMethod(() => Queryable.First<TElem>(null));
        
        public override IModifier CreateModifier(IModifier upstreamMod) {
            return new Modifier(upstreamMod);
        }
                       

        class Modifier : ParserModifier<TElem, TElem>
        {
            public Modifier(IModifier upstreamMod)
                : base(upstreamMod) { }
            
            //stick on query if we can.

            protected override Expression Rewrite(Expression exQuery) {
                return Expression.Call(
                                    _mFirst,
                                    exQuery);
            }

            protected override TElem Transform(TElem fetched) {
                return fetched; //.First(); 
            }
        }

    }
}
