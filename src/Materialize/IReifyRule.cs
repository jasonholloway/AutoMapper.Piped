using System;

namespace Materialize
{
    interface IReifyRule
    {
        IReifyStrategy DeduceStrategy(ReifyContext ctx);
    }



    abstract class ReifyRuleBase
        : IReifyRule
    {
        public abstract IReifyStrategy DeduceStrategy(ReifyContext ctx);

        protected IReifyStrategy CreateStrategy(Type typeDef, Type tOrig, Type tDest, params object[] ctorArgs) {
            var type = typeDef.MakeGenericType(tOrig, tDest);
            return (IReifyStrategy)Activator.CreateInstance(type, ctorArgs);
        }

    }


}
