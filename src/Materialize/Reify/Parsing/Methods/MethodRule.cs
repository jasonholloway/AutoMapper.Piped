using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing.Methods
{
    abstract class MethodRule : ParseRule
    {
        IParseStrategySource _parseStrategies;

        public MethodRule(IParseStrategySource parseStrategies) {
            _parseStrategies = parseStrategies;
        }

        protected IParseStrategy GetUpstreamStrategy(ParseContext ctx) 
        {
            var exUpstreamSubject = ctx.CallExp.Arguments.First();
            var upstreamContext = ctx.Spawn(exUpstreamSubject);

            return _parseStrategies.GetStrategy(upstreamContext);
        }

    }
}
