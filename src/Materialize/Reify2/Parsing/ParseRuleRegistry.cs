using Materialize.Dependencies;
using Materialize.Reify2.Parsing.Mapping;
using Materialize.Reify2.Parsing.Methods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing
{
    class ParseRuleRegistry
    {
        static Type[] _ruleTypes = {
                            typeof(MapperRule), //should always be first!
                            typeof(MethodRule)
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
