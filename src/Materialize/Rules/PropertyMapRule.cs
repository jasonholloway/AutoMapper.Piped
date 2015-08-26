using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Rules
{
    class PropertyMapRule : IReifyRule
    {
        ReifierSource _source;

        public PropertyMapRule(ReifierSource source) {
            _source = source;
        }

        public IReifierFactory BuildFactoryIfApplicable(ReifySpec spec) 
        {
            var typeMap = Mapper.FindTypeMapFor(spec.SourceType, spec.DestType);

            if(typeMap != null && typeMap.CustomProjection == null) {
                var facType = typeof(PropertyMapReifierFactory<,>).MakeGenericType(spec.SourceType, spec.DestType);
                return (IReifierFactory)Activator.CreateInstance(facType, typeMap, _source);
            }

            return null;
        }
    }
    

    class PropertyMapReifierFactory<TOrig, TDest>
        : ReifierFactory<TOrig, TDest>
    {
        PropSpec[] _propSpecs;

        public PropertyMapReifierFactory(TypeMap typeMap, ReifierSource source) 
        {
            _propSpecs = typeMap.GetPropertyMaps()
                                    .Select(map => new PropSpec(map, 
                                                            source.GetReifierFactory(((PropertyInfo)map.SourceMember).PropertyType, map.DestinationPropertyType)))
                                    .ToArray();                 
        }

        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            return new PropertyMapReifier<TOrig, TDest>(ctx, _propSpecs);
        }
    }


    struct PropSpec
    {
        public readonly PropertyMap Map;
        public readonly IReifierFactory ReifierFactory; 

        public PropSpec(PropertyMap map, IReifierFactory factory) {
            Map = map;
            ReifierFactory = factory;
        }
    }


    class PropertyMapReifier<TOrig, TDest>
        : IReifier<TOrig, TDest>
    {
        ReifyContext _ctx;
        PropSpec[] _propSpecs;

        public PropertyMapReifier(ReifyContext ctx, PropSpec[] propSpecs) {
            _ctx = ctx;
            _propSpecs = propSpecs;
        }

        public Expression VisitExpression(Expression exOrig) {
            //what will the input of the expression be?
            //...


            //any expression that evaluates to an IQueryable
            //yet...
            //if an iqueryable of the sourcetype, then agent should add select statement.
            //in fact, don't we always impose a select statement? Cos it's only this final stage
            //we care about.

            //Instead of visiting the entire tree, we're appending one select statement, and building
            //by strategem the projection expression. So not really visiting, but creating by cascade.

            //and yet we need to project only what is made available to us by the preceding expression.
            //so we can't project solely by crawling types and properties.
                                  





            return Expression.MemberInit(
                                Expression.New(typeof(TDest)),  //SHOULD USE CUSTOM CTOR IF SPECIFIED
                                _propSpecs.Select(s => Expression.Bind(
                                                            s.Map.DestinationProperty.MemberInfo, 
                                                            null
                                                            )).ToArray()
                                );
        }

        public object VisitFetchedNode(object orig) {
            throw new NotImplementedException();
        }
    }



}
