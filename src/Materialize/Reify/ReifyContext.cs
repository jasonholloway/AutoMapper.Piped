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
        public readonly TypeVector RootTypeVector;
        public readonly IMappingEngine MappingEngine;
        public readonly ISourceRegime SourceRegime;
        public readonly bool AllowClientSideFiltering;

        public ReifyContext(
            TypeVector rootTypeVector,
            IMappingEngine mappingEngine, 
            ISourceRegime sourceRegime, 
            bool allowClientFiltering) 
        {
            RootTypeVector = rootTypeVector;
            MappingEngine = mappingEngine;
            SourceRegime = sourceRegime;
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
            return x.RootTypeVector.Equals(y.RootTypeVector)
                    && x.MappingEngine.Equals(y.MappingEngine)
                    && x.SourceRegime.Equals(y.SourceRegime)
                    && x.AllowClientSideFiltering.Equals(y.AllowClientSideFiltering);
        }

        public int GetHashCode(ReifyContext obj) {
            return (obj.RootTypeVector.GetHashCode() << 24)
                    + (obj.MappingEngine.GetHashCode() << 16)
                    + (obj.SourceRegime.GetHashCode() << 1)
                    + (obj.AllowClientSideFiltering ? 1 : 0);
        }
    }
    
}
