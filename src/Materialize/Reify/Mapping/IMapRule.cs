using Materialize.Reify.Mapping;
using System;

namespace Materialize.Reify.Mapping
{
    interface IMapRule
    {
        IMapStrategy DeduceStrategy(Context ctx);
    }



    abstract class MapRuleBase
        : IMapRule
    {
        public abstract IMapStrategy DeduceStrategy(Context ctx);

        protected IMapStrategy CreateStrategy(Type typeDef, Type tOrig, Type tDest, params object[] ctorArgs) {
            var type = typeDef.MakeGenericType(tOrig, tDest);
            return (IMapStrategy)Activator.CreateInstance(type, ctorArgs);
        }

    }


}
