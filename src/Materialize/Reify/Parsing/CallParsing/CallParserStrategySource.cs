using AutoMapper;
using Materialize.SourceRegimes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing.CallParsing
{
    class CallParserStrategySource : ICallParseStrategySource
    {
        static ICallParseRule[] _rules
            = new ICallParseRule[] {
                new Unaries.UnaryRule(),
                new Where.WhereRule()
            };

        ConcurrentDictionary<CallParseContext, ICallParseStrategy> _dStrategies
            = new ConcurrentDictionary<CallParseContext, ICallParseStrategy>(ParseContextEqualityComparer.Default);
        

        public ICallParseStrategy GetStrategy(CallParseContext ctx) {
            return _dStrategies.GetOrAdd(ctx, 
                                        c => DeduceStrategy(c));
        }


        ICallParseStrategy DeduceStrategy(CallParseContext ctx) {            
            foreach(var rule in _rules) {
                var strategy = rule.GetStrategy(ctx);
                if(strategy != null) return strategy;
            }

            throw new InvalidOperationException("No ICallParseRule for method {ctx.Method.Name}!");
        }
                
    }
}
