using Materialize.Dependencies;
using Materialize.Reify.Parsing.Methods.Partitioners;
using Materialize.Reify.Parsing.Map;
using Materialize.Reify.Parsing.Methods.Unaries;
using Materialize.Reify.Parsing.Methods.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing
{
    class ParseRuleRegistry : IParseRuleRegistry
    {
        static Type[] _ruleTypes = new[] {
                                        typeof(MapperRule), //should always be first
                                        typeof(UnaryRule),
                                        typeof(PartitionerRule),
                                        typeof(WhereRule),
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
