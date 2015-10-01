using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping
{

    abstract class MapRuleBase
        : IMapRule
    {
        public abstract IMapStrategy DeduceStrategy(MapContext ctx);


        protected IMapStrategy CreateStrategy(
            Type typeDef,
            TypeVector types,
            params object[] ctorArgs) {
            var tStrategy = typeDef.MakeGenericType(types.SourceType, types.DestType);
            return CreateStrategy(tStrategy, ctorArgs);
        }


        protected IMapStrategy CreateStrategy(
            Type type,
            params object[] ctorArgs) {
            return (IMapStrategy)Activator.CreateInstance(type, ctorArgs);
        }


    }

}
