using Materialize.Reify.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing
{
    //Just wraps parsing operation so Reifiable need know nothing of strategies etc

    class Parser
    {
        Expression _exBase;
        MapContext _mapContext;
        IParseStrategySource _parseStrategies;
        
        public Parser(
            Expression exBase, 
            MapContext mapContext,
            IParseStrategySource parseStrategies) 
        {
            _exBase = exBase;
            _mapContext = mapContext;
            _parseStrategies = parseStrategies;
        }


        public IModifier Parse(Expression exSubject) 
        {
            var parseContext = new ParseContext(
                                            exSubject, 
                                            _exBase,
                                            _mapContext);

            var strategy = _parseStrategies.GetStrategy(parseContext);

            return strategy.Parse(exSubject);
        }
        
    }
}
