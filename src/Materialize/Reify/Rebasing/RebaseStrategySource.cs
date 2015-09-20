using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Rebasing
{
    class RebaseStrategySource : IRebaseStrategySource
    {
        IRebaseRuleRegistry _ruleRegistry;
        
        public RebaseStrategySource(IRebaseRuleRegistry ruleRegistry) {
            _ruleRegistry = ruleRegistry;
        }
        
        public IRebaseStrategy GetStrategy(RebaseContext ctx) 
        {        
            foreach(var rule in _ruleRegistry.Rules) {
                var strategy = rule.GetStrategy(ctx);
                if(strategy != null) return strategy;
            }

            throw new InvalidOperationException("No suitable IRebaseRule found!");
        }
                
    }
}
