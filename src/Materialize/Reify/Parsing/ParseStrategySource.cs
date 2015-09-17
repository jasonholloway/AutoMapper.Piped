﻿using AutoMapper;
using Materialize.SourceRegimes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing
{
    class ParseStrategySource : IParseStrategySource
    {
        IParseRuleRegistry _ruleRegistry;

        ConcurrentDictionary<ParseContext, IParseStrategy> _dParsers
            = new ConcurrentDictionary<ParseContext, IParseStrategy>(ParseContextEqualityComparer.Default);
                

        public ParseStrategySource(IParseRuleRegistry ruleRegistry) {
            _ruleRegistry = ruleRegistry;
        }



        public IParseStrategy GetStrategy(ParseContext ctx) {
            return _dParsers.GetOrAdd(ctx, c => DeviseParser(c));
        }


        IParseStrategy DeviseParser(ParseContext ctx) {            
            foreach(var rule in _ruleRegistry.Rules) {
                var strategy = rule.GetStrategy(ctx);
                if(strategy != null) return strategy;
            }

            throw new InvalidOperationException("No suitable IParseRule found!");
        }
                
    }
}
