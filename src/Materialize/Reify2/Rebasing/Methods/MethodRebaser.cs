using Materialize.Reify2.Rebasing.Methods.Rules;
using Materialize.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2.Rebasing.Methods
{
    class MethodRebaser
    {
        static IMethodRebaseRule[] _rules = {
            new QueryablePredicatorRule(),
            new EnumerablePredicatorRule(),
            new EnumerableUnaryRule()
        };
        
        static ConcurrentDictionary<MethodInfo, IMethodRebaseRule> _dRuleCache
            = new ConcurrentDictionary<MethodInfo, IMethodRebaseRule>();


                
        IParentRebaser _parentStrategizer;
                
        public MethodRebaser(IParentRebaser parentStrategizer) {
            _parentStrategizer = parentStrategizer;
        }


        public IRebaseStrategy Strategize(MethodCallExpression exCall) 
        {
            var subject = new MethodRebaseSubject(exCall);

            var rule = _dRuleCache.GetOrAdd(
                                        exCall.Method,
                                        _ => FindRule(subject));

            return rule.CreateStrategy(subject, _parentStrategizer);            
        }
        

        IMethodRebaseRule FindRule(MethodRebaseSubject subject) {
            var rule = _rules.FirstOrDefault(r => r.Accepts(subject));

            if(rule == null) {
                throw new RebaseException(
                            "Can't find suitable IMethodRebaseRule for method {0}",
                            subject.Method.GetNiceName());
            }

            return rule;
        }

    }
}
