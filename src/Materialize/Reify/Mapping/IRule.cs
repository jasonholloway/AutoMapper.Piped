using Materialize.Reify.Mapping;
using System;

namespace Materialize.Reify.Mapping
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
