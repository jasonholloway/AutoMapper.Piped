using Materialize.Dependencies;
using Materialize.Reify.Mapping.Collections;
using Materialize.Reify.Mapping.Direct;
using Materialize.Reify.Mapping.PropertyMaps;
using Materialize.Reify.Mapping.Translation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Mapping
{
    class MapRuleRegistry : IMapRuleRegistry
    {
        static Type[] _ruleTypes = new[] {
                                        typeof(CustomTranslationRule),
                                        typeof(PropertyMapRule),
                                        //special string rule here to preempt collection rule
                                        typeof(CollectionRule),
                                        typeof(DirectRule)
                                    };


        Lazy<IMapRule[]> _lzRules;

        public MapRuleRegistry(IServiceRegistry registry) 
        {   
            foreach(var ruleType in _ruleTypes) {
                registry.Register(ruleType);
            }

            _lzRules = new Lazy<IMapRule[]>(
                            () => _ruleTypes.Select(t => (IMapRule)registry.Resolve(t))
                                                .ToArray());
        }
        

        public IEnumerable<IMapRule> Rules {
            get { return _lzRules.Value; }
        }

    }
}
