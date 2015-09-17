using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Where
{
    class WhereRule : QueryableMethodRule
    {
        static MethodInfo _mWhereGen = Refl.GetGenMethod(() => Queryable.Where<int>(null, i => true));

        
        public WhereRule(IParseStrategySource strategySource)
            : base(strategySource) { }

        

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef == _mWhereGen)
            {                
                var tElem = ctx.TypeArgs.First();

                //if we do any filtering client-side, then unary functions can't be passed onto server:
                //strategies must register the fact that the set extent only gets finalized client-side.
                //How to pass it? Has to be via the parser... Or rather, the parser is the active party.

                //Strategies should just expose a property, to be picked up and remembered by the parser.
                
                var upstreamStrategy = GetUpstreamStrategy(ctx);
                                
                return CreateStrategy(
                                typeof(ClientOnlyWhereStrategy<>).MakeGenericType(tElem),
                                upstreamStrategy);
            }

            return null;
        }
    }
}
