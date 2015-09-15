using Materialize.Dependencies;
using Materialize.Reify.Mapping.Collections;
using Materialize.Reify.Mapping.Direct;
using Materialize.Reify.Mapping.PropertyMaps;
using Materialize.Reify.Mapping.Translation;
using Materialize.Reify.Parsing.Unaries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing
{
    class ParseRuleRegistry : IParseRuleRegistry
    {
        static Type[] _ruleTypes = new[] {
                                        typeof(UnaryRule),                                        
                                    };


        Lazy<IParseRule[]> _lzRules;

        public ParseRuleRegistry(IServiceRegistry registry) 
        {   
            foreach(var ruleType in _ruleTypes) {
                registry.Register(ruleType);
            }

            _lzRules = new Lazy<IParseRule[]>(
                            () => _ruleTypes
                                        .Select(t => (IParseRule)registry.Resolve(t))
                                        .ToArray());
        }
        

        public IEnumerable<IParseRule> Rules {
            get { return _lzRules.Value; }
        }

    }
}
