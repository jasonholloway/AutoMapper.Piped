using AutoMapper;
using Materialize.SourceRegimes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing
{
    class ParseStrategySource : IParseStrategySource
    {
        static IParseRule[] _rules
            = new IParseRule[] {
                new Unaries.UnaryRule(),
                new Where.WhereRule()
            };

        ConcurrentDictionary<ParseContext, IParseStrategy> _dParsers
            = new ConcurrentDictionary<ParseContext, IParseStrategy>(ParseContextEqualityComparer.Default);
        

        public IParseStrategy GetStrategy(ParseContext ctx) {
            return _dParsers.GetOrAdd(ctx, c => DeviseParser(c));
        }


        IParseStrategy DeviseParser(ParseContext ctx) {            
            foreach(var rule in _rules) {
                var strategy = rule.GetStrategy(ctx);
                if(strategy != null) return strategy;
            }

            throw new InvalidOperationException("No IParseRule found!");
        }
                
    }
}
