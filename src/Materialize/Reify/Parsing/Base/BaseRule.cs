using Materialize.Reify.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Unaries
{
    class BaseRule : ParseRule
    {
        IMapStrategySource _mapStrategies;

        public BaseRule(IMapStrategySource mapStrategies) {
            _mapStrategies = mapStrategies;
        }
        

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.SubjectExp == ctx.BaseExp) 
            {                
                var mapStrategy = _mapStrategies.GetStrategy(ctx.MapContext);
                return new BaseStrategy(mapStrategy);
            }
            
            return null;
        }
    }
}
