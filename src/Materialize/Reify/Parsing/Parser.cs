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
        Type _sourceType;
        ReifyContext _reifyContext;
        ParseStrategySource _parseStrategies;
        
        public Parser(
            Expression exBase, 
            Type sourceType,
            ReifyContext reifyContext,
            ParseStrategySource parseStrategies) 
        {
            _exBase = exBase;
            _sourceType = sourceType;
            _reifyContext = reifyContext;
            _parseStrategies = parseStrategies;
        }


        public Result Parse(Expression exSubject) 
        {
            var parseContext = new ParseContext(
                                            exSubject, 
                                            _exBase,
                                            _sourceType,
                                            _reifyContext);

            var strategy = _parseStrategies.GetStrategy(parseContext);

            return new Result(
                        strategy.Parse(exSubject),
                        strategy);
        }
        

        public struct Result
        {
            public readonly IModifier Modifier;
            public readonly IParseStrategy UsedStrategy;

            public Result(IModifier modifier, IParseStrategy usedStrategy) {
                Modifier = modifier;
                UsedStrategy = usedStrategy;
            }
        }

    }
}
