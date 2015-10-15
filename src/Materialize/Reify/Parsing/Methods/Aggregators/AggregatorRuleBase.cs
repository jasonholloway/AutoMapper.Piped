using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Aggregators
{
    abstract class AggregatorRuleBase : MethodRule
    {
        ISet<MethodInfo> _methods;

        public AggregatorRuleBase(IParseStrategySource strategySource, IEnumerable<MethodInfo> methods)
            : base(strategySource) 
        {
            _methods = new HashSet<MethodInfo>(methods);
        }


        protected abstract IParseStrategy CreateClientStrategy(Type tElem, IParseStrategy upstreamStrategy, MethodInfo methodDef);
        protected abstract IParseStrategy CreateServerStrategy(Type tElem, IParseStrategy upstreamStrategy, MethodInfo methodDef);

        
        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef != null && ctx.TypeArgs.Length == 1) 
            {
                if(_methods.Contains(ctx.MethodDef)) {
                    var upstreamStrategy = GetUpstreamStrategy(ctx);

                    var tElem = ctx.TypeArgs.Single();

                    if(upstreamStrategy.FiltersFetchedSet) {
                        return CreateClientStrategy(tElem, upstreamStrategy, ctx.MethodDef);
                    }
                    else {
                        return CreateServerStrategy(tElem, upstreamStrategy, ctx.MethodDef);
                    }                    
                }
            }

            return null;
        }
    }
}
