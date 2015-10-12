using Materialize.SourceRegimes;
using Materialize.Types;
using System.Collections.Generic;

namespace Materialize.Reify.Mapping
{
    internal struct MapContext
    {
        public readonly TypeVector TypeVector;
        public readonly ReifyContext ReifyContext;
        
        public ISourceRegime SourceRegime {
            get { return ReifyContext.SourceRegime; }
        }


        public MapContext(
            TypeVector typeVector,
            ReifyContext reifyContext)
        {                              
            TypeVector = typeVector;
            ReifyContext = reifyContext;
        }        
    }


    class MapContextEqualityComparer
        : IEqualityComparer<MapContext>
    {
        public static readonly MapContextEqualityComparer Default = new MapContextEqualityComparer();
        
        public bool Equals(MapContext x, MapContext y) {
            return x.TypeVector.Equals(y.TypeVector)
                    && x.ReifyContext.Equals(y.ReifyContext);
        }

        public int GetHashCode(MapContext obj) {
            return (obj.ReifyContext.GetHashCode() << 8) 
                    ^ obj.TypeVector.GetHashCode();
        }
    }


}
