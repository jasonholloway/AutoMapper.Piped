using System;

namespace Materialize.Reify.Mapping
{
    internal interface IMapRule
    {
        IMapStrategy DeduceStrategy(MapContext ctx);
    }



    abstract class MapRuleBase
        : IMapRule
    {
        public abstract IMapStrategy DeduceStrategy(MapContext ctx);

        protected IMapStrategy CreateStrategy(Type typeDef, Type tOrig, Type tDest, params object[] ctorArgs) {
            var type = typeDef.MakeGenericType(tOrig, tDest);
            return (IMapStrategy)Activator.CreateInstance(type, ctorArgs);
        }

    }


}
