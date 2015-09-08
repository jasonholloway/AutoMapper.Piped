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


        protected IMapStrategy CreateStrategy(
            Type typeDef, 
            TypeVector types, 
            params object[] ctorArgs) 
        {
            var tStrategy = typeDef.MakeGenericType(types.SourceType, types.DestType);
            return (IMapStrategy)Activator.CreateInstance(tStrategy, ctorArgs);
        }

    }


}
