using Materialize.Dependencies;
using Materialize.Reify.Mapping.CustomProject;
using Materialize.Reify.Mapping.Direct;
using Materialize.Reify.Mapping.PropertyMaps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Mapping
{
    class MapRuleRegistry : IMapRuleRegistry
    {
        static Type[] _ruleTypes = new[] {
                                        typeof(CustomProjectRule),
                                        typeof(PropertyMapRule),
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
