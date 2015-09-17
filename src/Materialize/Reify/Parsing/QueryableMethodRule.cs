using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{
    abstract class QueryableMethodRule : ParseRule
    {
        IParseStrategySource _parseStrategies;

        public QueryableMethodRule(IParseStrategySource parseStrategies) {
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
