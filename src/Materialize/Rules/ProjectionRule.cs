using AutoMapper;
using System;
using System.Linq.Expressions;

namespace Materialize.Rules
{
    class ProjectionRule : IReifyRule
    {
        ReifierSource _source;

        public ProjectionRule(ReifierSource source) {
            _source = source;
        }

        public IReifierFactory BuildFactoryIfApplicable(ReifySpec spec) 
        {
            var typeMap = Mapper.FindTypeMapFor(spec.SourceType, spec.DestType);

            if(typeMap != null && typeMap.CustomProjection != null) {
                var facType = typeof(ProjectionReifierFactory<,>).MakeGenericType(spec.SourceType, spec.DestType);
                return (IReifierFactory)Activator.CreateInstance(facType, typeMap);
            }

            return null;
        }
    }
    

    class ProjectionReifierFactory<TOrig, TDest>
        : ReifierFactory<TOrig, TDest>
    {
        TypeMap _typeMap;

        public ProjectionReifierFactory(TypeMap typeMap) {
            _typeMap = typeMap;
        }

        //build up important info here, to feed to reifier instances; factories will be cached
        //...

        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            return new ProjectionReifier<TOrig, TDest>(ctx);
        }
    }


    class ProjectionReifier<TOrig, TDest>
        : IReifier<TOrig, TDest>
    {
        ReifyContext _ctx;

        public ProjectionReifier(ReifyContext ctx) {
            _ctx = ctx;
        }

        public Expression VisitExpression(Expression exOrig) {
            return exOrig;
        }

        public object VisitFetchedNode(object orig) {
            return orig;
        }
    }



}
