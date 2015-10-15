using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Partitioners
{
    class PartitionerRule : MethodRule
    {
        static MethodInfo _mTakeGen = Refl.GetGenMethod(() => Queryable.Take<object>(null, 1));
        static MethodInfo _mSkipGen = Refl.GetGenMethod(() => Queryable.Skip<object>(null, 1));
        

        public PartitionerRule(IParseStrategySource parseStrategies)
            : base(parseStrategies) { }



        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef == _mTakeGen || ctx.MethodDef == _mSkipGen) 
            {
                var tElem = ctx.Method.GetGenericArguments().First();

                var upstreamStrategy = GetUpstreamStrategy(ctx);

                return CreateStrategy(
                                typeof(ServerSidePartitionerStrategy<>).MakeGenericType(tElem),
                                upstreamStrategy,
                                ctx.MethodDef);
            }

            return null;
        }
    }
}
