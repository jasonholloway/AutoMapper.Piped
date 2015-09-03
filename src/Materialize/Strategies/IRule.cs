using Materialize.Strategies;
using System;

namespace Materialize.Strategies
{
    interface IRule
    {
        IStrategy DeduceStrategy(Context ctx);
    }



    abstract class RuleBase
        : IRule
    {
        public abstract IStrategy DeduceStrategy(Context ctx);

        protected IStrategy CreateStrategy(Type typeDef, Type tOrig, Type tDest, params object[] ctorArgs) {
            var type = typeDef.MakeGenericType(tOrig, tDest);
            return (IStrategy)Activator.CreateInstance(type, ctorArgs);
        }

    }


}
