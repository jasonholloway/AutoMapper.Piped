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
        : ReifierBase<TOrig, TDest>
    {
        ReifyContext _ctx;
        PropSpec[] _propSpecs;

        public PropertyMapReifier(ReifyContext ctx, PropSpec[] propSpecs) {
            _ctx = ctx;
            _propSpecs = propSpecs;
        }


        protected override Expression MapSingle(Expression exSource) 
        {
            return Expression.MemberInit(
                                Expression.New(typeof(TDest).GetConstructors().First()),
                                _propSpecs.Select(
                                            spec => {   //these returned expressions should be pre-built in above factory...
                                                var sourceMember = spec.Map.SourceMember;
                                                var destMember = spec.Map.DestinationProperty.MemberInfo;
                                                var subReifier = spec.ReifierFactory.CreateReifier(_ctx);

                                                var exInput = Expression.MakeMemberAccess(
                                                                                    exSource,
                                                                                    sourceMember);

                                                var exMappedInput = subReifier.Map(exInput);

                                                return Expression.Bind(
                                                                    destMember, 
                                                                    exMappedInput);
                                            }).ToArray()
                                );

        }

                
        protected override TDest FinalizeSingle(object obj) {
            throw new NotImplementedException();
        }


        //exSource will always be singular, framed nicely by our feeder
        //exSource will in most cases be replaced with a select statement or conversion function
        //the singular/multiple problem in the output also needs to be patted together by the base class
        public Expression _Map(Expression exSource) {
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
            
            //if any child nodes need special projection, then all parent nodes need this too (i think??)
            
            
            //it's up to the parent to pose the problem correctly to its child reifiers, ie each reifier
            //should be given a standard form of source expression. The parent has to deal with select statements
            //and/or enumerations. In fact, the fed source should always be singular.

            //This behaviour can be generalised by making it a function of a common base class.

            //reiteration: parent shouldn't crawl typesystem, but fed expression, which will of course
            //implicate the type system, but also limits it. First port of call: the source exp.

            //At the very top, a ReifierRunner, that packages the problem nicely, and thereafter delegates
            //to ReifierSource's banks.





            return Expression.MemberInit(
                                Expression.New(typeof(TDest)),  //SHOULD USE CUSTOM CTOR IF SPECIFIED
                                _propSpecs.Select(s => Expression.Bind(
                                                            s.Map.DestinationProperty.MemberInfo, 
                                                            null
                                                            )).ToArray()
                                );
        }

        public object Finalize(object orig) {
            throw new NotImplementedException();
        }
    }



}
