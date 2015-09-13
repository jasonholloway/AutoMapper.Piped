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
            return CreateStrategy(tStrategy, ctorArgs);
        }


        protected IMapStrategy CreateStrategy(
            Type type,
            params object[] ctorArgs) 
        {
            return (IMapStrategy)Activator.CreateInstance(type, ctorArgs);
        }


    }


}
