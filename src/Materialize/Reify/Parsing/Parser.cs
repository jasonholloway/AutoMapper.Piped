﻿using Materialize.Reify.Mapping;
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
        ReifyContext _reifyContext;
        IParseStrategySource _parseStrategies;
        
        public Parser(
            Expression exBase, 
            ReifyContext reifyContext,
            IParseStrategySource parseStrategies) 
        {
            _exBase = exBase;
            _reifyContext = reifyContext;
            _parseStrategies = parseStrategies;
        }


        public Result Parse(Expression exSubject) 
        {
            var parseContext = new ParseContext(
                                            exSubject, 
                                            _exBase,
                                            _reifyContext);

            var strategy = _parseStrategies.GetStrategy(parseContext);

            return new Result(
                        strategy.Parse(exSubject),
                        strategy);
        }
        

        public struct Result
        {
            public readonly IModifier Modifier;
            public readonly IReifyStrategy UsedStrategy;

            public Result(IModifier modifier, IReifyStrategy usedStrategy) {
                Modifier = modifier;
                UsedStrategy = usedStrategy;
            }
        }

    }
}
