using Materialize.Dependencies;
using Materialize.Reify.Parsing.Unaries;
using Materialize.Reify.Parsing.Where;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Parsing
{
    class ParseRuleRegistry : IParseRuleRegistry
    {
        static Type[] _ruleTypes = new[] {
                                        typeof(BaseRule),
                                        typeof(UnaryRule),
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
