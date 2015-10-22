using AutoMapper;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Mapping
{
    class MapStrategySource : IMapStrategySource
    {
        IMapRuleRegistry _ruleRegistry;

        ConcurrentDictionary<MapContext, IMapStrategy> _dStrategies
            = new ConcurrentDictionary<MapContext, IMapStrategy>(MapContextEqualityComparer.Default);

        
        public MapStrategySource(IMapRuleRegistry ruleRegistry) {
            _ruleRegistry = ruleRegistry;
        }
        

        public IMapStrategy GetStrategy(MapContext mapContext) {
            return _dStrategies.GetOrAdd(
                                    mapContext,
                                    c => DeduceStrategy(c));
        }

        

        IMapStrategy DeduceStrategy(MapContext ctx) {            
            foreach(var rule in _ruleRegistry.Rules) {
                var strategy = rule.DeduceStrategy(ctx);
                if(strategy != null) return strategy;
            }

            throw new AutoMapperMappingException("Unsupported mapping!");
        }
                

    }
}
