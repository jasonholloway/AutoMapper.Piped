using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    class AggregatorRule : AggregatorRuleBase
    {
        static MethodInfo[] _methods = {
            Refl.GetGenMethod(() => Queryable.Count<object>(null))
        };

        public AggregatorRule(IParseStrategySource strategySource)
            : base(strategySource, _methods) { }


        protected override IParseStrategy CreateClientStrategy(
            Type tElem, 
            IParseStrategy upstreamStrategy, 
            MethodInfo methodDef) 
        {
            return CreateStrategy(
                            null, //!!!!!!!!!
                            upstreamStrategy,
                            methodDef);
        }


        protected override IParseStrategy CreateServerStrategy(
            Type tElem,
            IParseStrategy upstreamStrategy,
            MethodInfo methodDef) 
        {
            return CreateStrategy(
                            null, //!!!!!!!!!!!!!
                            upstreamStrategy,
                            methodDef);
        }
                
    }
}
