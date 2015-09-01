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
        : ReifyStrategyBase<TOrig, TDest>
    {
        ReifyContext _ctx;
        TypeMap _typeMap;
        PropStrategySpec[] _propSpecs;

        public MediatedPropMapStrategy(ReifyContext ctx, TypeMap typeMap, PropStrategySpec[] propSpecs) {
            _ctx = ctx;
            _typeMap = typeMap;
            _propSpecs = propSpecs;


            //need to create mediate type to project into


        }


        public override Type ProjectedType {
            get {
                throw new NotImplementedException();
            }
        }
               


        public override IReifier<TOrig, TDest> CreateReifier() {
            throw new NotImplementedException();

            //var type = typeof(Reifier<>).MakeGenericType();
        }





        class Reifier<TMed> : ReifierBase<TOrig, TMed, TDest>
        {
            protected override Expression ProjectSingle(Expression exSource) {
                throw new NotImplementedException();
            }

            protected override TDest TransformSingle(TMed obj) {
                throw new NotImplementedException();
            }
        }
    }

}
