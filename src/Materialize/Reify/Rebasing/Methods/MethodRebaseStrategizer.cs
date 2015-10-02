using Materialize.Reify.Rebasing.Methods.Rules;
using Materialize.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Rebasing.Methods
{
    class MethodRebaseStrategizer
    {
        static IMethodRebaseRule[] _rules = {
            new QueryableWhereRule(),
            new EnumerablePredicatorRule(),
            new EnumerableUnaryRule()
        };
        
        static ConcurrentDictionary<MethodInfo, IMethodRebaseRule> _dRuleCache
            = new ConcurrentDictionary<MethodInfo, IMethodRebaseRule>();


                
        IParentRebaseStrategizer _parentStrategizer;
                
        public MethodRebaseStrategizer(IParentRebaseStrategizer parentStrategizer) {
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
            return _rules.First(r => r.Accepts(subject));
        }

    }
}
