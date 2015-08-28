using System;
using System.Linq.Expressions;

namespace Materialize.Strategies.Direct
{
    class DirectRule : IReifyRule
    {        
        public IReifyStrategy DeduceStrategy(ReifySpec spec) 
        {
            if(spec.SourceType == spec.DestType) {
                var strategyType = typeof(DirectStrategy<,>).MakeGenericType(spec.SourceType, spec.DestType);
                return (IReifyStrategy)Activator.CreateInstance(strategyType);
            }

            return null;
        }
    }
    
}
