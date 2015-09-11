using System;
using System.Collections.Generic;

namespace Materialize
{
    struct TypeVector
    {
        public readonly Type SourceType;
        public readonly Type DestType;

        public TypeVector(Type sourceType, Type destType) {
            SourceType = sourceType;
            DestType = destType;
        }

        public override string ToString() {
            return string.Format(
                            "{0} -> {1}",
                            SourceType.Name,
                            DestType.Name);
        }
    }


    class TypeVectorEqualityComparer : IEqualityComparer<TypeVector>
    {
        public static readonly TypeVectorEqualityComparer Default = new TypeVectorEqualityComparer();

        public bool Equals(TypeVector x, TypeVector y) {
            return x.SourceType == y.SourceType
                    && x.DestType == y.DestType;
        }

        public int GetHashCode(TypeVector obj) {
            return obj.SourceType.GetHashCode() ^ obj.DestType.GetHashCode();
        }
    }

}
