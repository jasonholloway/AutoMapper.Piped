using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Materialize.Strategies.PropertyMapping
{
    class MediatedPropMapStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        ReifyContext _ctx;
        TypeMap _typeMap;
        PropMapSpec[] _propSpecs;

        public MediatedPropMapStrategy(ReifyContext ctx, TypeMap typeMap, PropMapSpec[] propSpecs) {
            _ctx = ctx;
            _typeMap = typeMap;
            _propSpecs = propSpecs;
        }

        public override bool UsesIntermediateType {
            get { return true; }
        }

        public override IReifier<TOrig, TDest> CreateReifier() {
            throw new NotImplementedException();

            //var type = typeof(Reifier<>).MakeGenericType();
        }


        class Reifier<TMed> : ReifierBase<TOrig, TMed, TDest>
        {
            protected override Expression MapSingle(Expression exSource) {
                throw new NotImplementedException();
            }

            protected override TDest ReformSingle(TMed obj) {
                throw new NotImplementedException();
            }
        }
    }

}
