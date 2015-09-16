using AutoMapper;
using Materialize.SourceRegimes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing.CallParsing
{
    class CallParserProvider : ICallParserProvider
    {
        static ICallParseRule[] _rules
            = new ICallParseRule[] {
                new Unaries.UnaryRule(),
                new Where.WhereRule()
            };

        ConcurrentDictionary<CallParseContext, CallParserFactory> _dParserFacs
            = new ConcurrentDictionary<CallParseContext, CallParserFactory>(ParseContextEqualityComparer.Default);
        

        public ICallParser GetParser(Parser parser, CallParseContext ctx) {
            var fac = _dParserFacs.GetOrAdd(ctx, 
                                        c => BuildFactory(c));
            return fac(parser);
        }


        CallParserFactory BuildFactory(CallParseContext ctx) {            
            foreach(var rule in _rules) {
                var factory = rule.GetParserFactory(ctx);
                if(factory != null) return factory;
            }

            throw new InvalidOperationException("No ICallParseRule for method {ctx.Method.Name}!");
        }
                
    }
}
