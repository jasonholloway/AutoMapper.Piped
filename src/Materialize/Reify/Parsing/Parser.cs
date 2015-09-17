using Materialize.Reify.Modifiers;
using Materialize.Reify.Parsing;
using Materialize.Reify.Parsing.CallParsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing
{
    //Just wraps parsing operation so Reifiable need know nothing of strategies etc

    class Parser
    {
        Expression _exBase;
        IParseStrategySource _parseStrategies;
        
        public Parser(
            Expression exBase, 
            IParseStrategySource parseStrategies) 
        {
            _exBase = exBase;
            _parseStrategies = parseStrategies;
        }


        public IModifier Parse(Expression exSubject) 
        {
            var context = new ParseContext(
                                    exSubject, 
                                    _exBase);

            var strategy = _parseStrategies.GetStrategy(context);

            return strategy.Parse(exSubject);
        }
        
    }
}
