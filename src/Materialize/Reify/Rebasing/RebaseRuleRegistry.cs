using Materialize.Dependencies;
using Materialize.Reify.Rebasing.Root;
using Materialize.Reify.Rebasing.Where;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing
{
    class RebaseRuleRegistry : IRebaseRuleRegistry
    {
        static Type[] _ruleTypes = new Type[] {
                                        typeof(WhereRule),
                                        typeof(RootRule)
                                    };


        Lazy<IRebaseRule[]> _lzRules;

        public RebaseRuleRegistry(IServiceRegistry registry) {
            foreach(var ruleType in _ruleTypes) {
                registry.Register(ruleType);
            }

            _lzRules = new Lazy<IRebaseRule[]>(
                            () => _ruleTypes
                                        .Select(t => (IRebaseRule)registry.Resolve(t))
                                        .ToArray());
        }


        public IEnumerable<IRebaseRule> Rules {
            get { return _lzRules.Value; }
        }

    }
}
