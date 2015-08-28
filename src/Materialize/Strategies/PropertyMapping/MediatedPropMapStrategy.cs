using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.PropertyMapping
{
    class MediatedPropMapStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        TypeMap _typeMap;
        PropMapSpec[] _propSpecs;

        public MediatedPropMapStrategy(TypeMap typeMap, PropMapSpec[] propSpecs) {
            _typeMap = typeMap;
            _propSpecs = propSpecs;
        }

        public override bool UsesIntermediateType {
            get { return true; }
        }

        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            throw new NotImplementedException();
        }
    }

}
