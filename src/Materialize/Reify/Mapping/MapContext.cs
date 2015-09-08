using Materialize.SourceRegimes;
using System.Collections.Generic;

namespace Materialize.Reify.Mapping
{
    internal struct MapContext
    {
        public readonly ISourceRegime QueryRegime;
        public readonly TypeVector TypeVector;
                
        public MapContext(
            ISourceRegime queryRegime,
            TypeVector typeVector)
        {                                           
            QueryRegime = queryRegime;
            TypeVector = typeVector;
        }        
    }


    class MapContextEqualityComparer
        : IEqualityComparer<MapContext>
    {
        public static readonly MapContextEqualityComparer Default = new MapContextEqualityComparer();
        static TypeVectorEqualityComparer _vectorComparer = TypeVectorEqualityComparer.Default;

        public bool Equals(MapContext x, MapContext y) {
            return ReferenceEquals(x.QueryRegime, y.QueryRegime)
                    && _vectorComparer.Equals(x.TypeVector, y.TypeVector);
        }

        public int GetHashCode(MapContext obj) {
            return (obj.QueryRegime.GetHashCode() << 8) 
                    ^ _vectorComparer.GetHashCode(obj.TypeVector);
        }
    }


}
