using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Limiters
{
    class LimiterRule : QueryableMethodRule
    {
        static MethodInfo _mTakeGen = Refl.GetGenMethod(() => Queryable.Take<object>(null, 1));
        static MethodInfo _mSkipGen = Refl.GetGenMethod(() => Queryable.Skip<object>(null, 1));
        

        public LimiterRule(IParseStrategySource parseStrategies)
            : base(parseStrategies) { }



        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef == _mTakeGen || ctx.MethodDef == _mSkipGen) 
            {
                var tElem = ctx.Method.GetGenericArguments().First();

                var upstreamStrategy = GetUpstreamStrategy(ctx);

                return CreateStrategy(
                                typeof(ServerSideLimiterStrategy<>).MakeGenericType(tElem),
                                upstreamStrategy,
                                ctx.MethodDef);
            }

            return null;
        }
    }
}
