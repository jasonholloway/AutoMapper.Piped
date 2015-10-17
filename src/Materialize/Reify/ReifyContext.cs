using AutoMapper;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{
    struct ReifyContext
    {
        public readonly IMappingEngine MappingEngine;
        public readonly ISourceRegime SourceRegime;
        public readonly Type MapDestType;
        public readonly bool AllowClientSideFiltering;

        public ReifyContext(
            IMappingEngine mappingEngine, 
            ISourceRegime sourceRegime,
            Type mapDestType, 
            bool allowClientFiltering) 
        {
            MappingEngine = mappingEngine;
            SourceRegime = sourceRegime;
            MapDestType = mapDestType;
            AllowClientSideFiltering = allowClientFiltering;
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
                    && x.MapDestType.Equals(y.MapDestType)
                    && x.AllowClientSideFiltering.Equals(y.AllowClientSideFiltering);
        }

        public int GetHashCode(ReifyContext obj) {
            return (obj.MapDestType.GetHashCode() << 24)
                    ^ (obj.MappingEngine.GetHashCode() << 16)
                    ^ (obj.SourceRegime.GetHashCode() << 1)
                    ^ (obj.AllowClientSideFiltering ? 1 : 0);
        }
    }
    
}
