using AutoMapper;
using Materialize.SourceRegimes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Mapping
{
    class MapStrategySource : IMapStrategySource
    {
        IMapRuleRegistry _ruleRegistry;

        ConcurrentDictionary<MapContext, IMapStrategy> _dStrategies
            = new ConcurrentDictionary<MapContext, IMapStrategy>(MapContextEqualityComparer.Default);

        
        public MapStrategySource(IMapRuleRegistry ruleRegistry) {
            _ruleRegistry = ruleRegistry;
        }
        

        public IMapStrategy GetStrategy(ISourceRegime regime, Type tSource, Type tDest) {
            var context = new MapContext(
                                    regime,
                                    new TypeVector(tSource, tDest));
                        
            return _dStrategies.GetOrAdd(
                                    context, 
                                    c => PlanStrategy(c));
        }


        IMapStrategy PlanStrategy(MapContext ctx) {            
            foreach(var rule in _ruleRegistry.Rules) {
                var fac = rule.DeduceStrategy(ctx);
                if(fac != null) return fac;
            }

            throw new AutoMapperMappingException("Unsupported mapping!");
        }



        //Once container is in place, this will be obsolete: container will be cleared on reset
        public void Reset() {
            _dStrategies.Clear();
        }


    }
}
