using AutoMapper;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing
{
    class ParseStrategySource
    {
        ParseRuleRegistry _ruleRegistry;

        ConcurrentDictionary<ParseContext, IParseStrategy> _dStrategies
            = new ConcurrentDictionary<ParseContext, IParseStrategy>(ParseContextEqualityComparer.Default);
                

        public ParseStrategySource(ParseRuleRegistry ruleRegistry) {
            _ruleRegistry = ruleRegistry;
        }



        public IParseStrategy GetStrategy(ParseContext ctx) {
            return _dStrategies.GetOrAdd(ctx, c => DeviseParser(c));
        }


        IParseStrategy DeviseParser(ParseContext ctx) {            
            foreach(var rule in _ruleRegistry.Rules) {
                var strategy = rule.GetStrategy(ctx);
                if(strategy != null) return strategy;
            }

            throw new ParseException("No accepting IParseRule found for method {0}!", ctx.Method.GetNiceName());
        }
                
    }
}
