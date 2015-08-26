using System;

namespace Materialize
{
    struct ReifySpec
    {
        public readonly Type SourceType;
        public readonly Type DestType;

        public ReifySpec(Type sourceType, Type destType) {
            SourceType = sourceType;
            DestType = destType;
        }
    }
}
