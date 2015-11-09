using AutoMapper;
using Materialize.Reify2.Mapping;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2
{
    class ReifyContext
    {
        public readonly IMappingEngine MappingEngine;
        public readonly ISourceRegime SourceRegime;
        public readonly MapperSource MapperSource;
        public readonly bool AllowClientSideFiltering;
        public readonly ISnooper Snooper;
        
        public ReifyContext(
            IMappingEngine mappingEngine, 
            ISourceRegime sourceRegime,
            MapperSource mapperSource,
            bool allowClientFiltering,
            ISnooper snooper) 
        {
            MappingEngine = mappingEngine;
            SourceRegime = sourceRegime;
            MapperSource = mapperSource;
            AllowClientSideFiltering = allowClientFiltering;
            Snooper = snooper;
        }

        public override bool Equals(object obj) {
            return obj is ReifyContext
                    && ReifyContextEqualityComparer.Default.Equals(this, (ReifyContext)obj);
        }

        public override int GetHashCode() {
            return ReifyContextEqualityComparer.Default.GetHashCode(this);
        }

    }
    

    class ReifyContextEqualityComparer : IEqualityComparer<ReifyContext>
    {
        public static readonly ReifyContextEqualityComparer Default = new ReifyContextEqualityComparer();

        public bool Equals(ReifyContext x, ReifyContext y) {
            return x.MappingEngine.Equals(y.MappingEngine)
                    && x.SourceRegime.Equals(y.SourceRegime)
                    && x.AllowClientSideFiltering.Equals(y.AllowClientSideFiltering);
        }

        public int GetHashCode(ReifyContext obj) {
            return (obj.MappingEngine.GetHashCode() << 16)
                    ^ (obj.SourceRegime.GetHashCode() << 1)
                    ^ (obj.AllowClientSideFiltering ? 1 : 0);
        }
    }
    
}
