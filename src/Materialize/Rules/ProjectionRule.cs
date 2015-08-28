using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using JH.DynaType;
using System.Reflection;

namespace Materialize.Rules
{
    class ProjectionRule : IReifyRule
    {
        ReifierSource _source;

        public ProjectionRule(ReifierSource source) {
            _source = source;
        }

        public IReifyStrategy ResolveStrategy(ReifySpec spec) 
        {
            var typeMap = Mapper.FindTypeMapFor(spec.SourceType, spec.DestType);

            if(typeMap != null && typeMap.CustomProjection != null) {
                var strategyType = typeof(ProjectionStrategy<,>).MakeGenericType(spec.SourceType, spec.DestType);
                return (IReifyStrategy)Activator.CreateInstance(strategyType, typeMap);
            }

            return null;
        }
    }
    

    class ProjectionStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        LambdaExpression _exProject;
        DataType _dataType;

        public ProjectionStrategy(TypeMap typeMap) 
        {           
            _exProject = typeMap.CustomProjection;

            //is projection fit for EDM constraints?
            //if so, can stitch into expression

            //otherwise, have to use data object - maybe this should be separate rule, separate factories, etc.

            //should try and figure out exactly what data is needed to feed projection
            //for now just fetch it all
            var sourceProps = typeof(TOrig).GetProperties();

            _dataType = BuildDataType(sourceProps);
        }

        DataType BuildDataType(MemberInfo[] sourceMembers) 
        {
            //will eventually have to use tuple here - can't emit in certain environments
            var type = DynaType.Design(x => {  
                foreach(var sourceProp in sourceMembers.OfType<PropertyInfo>()) {   //obvs use fields too
                    x.Field(sourceProp.Name, sourceProp.PropertyType)
                        .MakePublic();
                }
            });

            var fieldMaps = sourceMembers
                                .Select(m => new DataFieldMap(type.GetField(m.Name), m))
                                .ToArray();
            
            return new DataType(type, fieldMaps);
        }

        
        public override IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx) {
            return new ProjectionReifier<TOrig, TDest>(ctx, _dataType);
        }
    }


    struct DataType
    {
        public readonly Type Type;
        public readonly DataFieldMap[] FieldMaps;

        public DataType(Type type, DataFieldMap[] fieldMaps) {
            Type = type;
            FieldMaps = fieldMaps;
        }
    }

    struct DataFieldMap
    {
        public readonly FieldInfo Field;
        public readonly MemberInfo SourceMember;

        public DataFieldMap(FieldInfo field, MemberInfo sourceMember) {
            Field = field;
            SourceMember = sourceMember;
        }
    }



    class ProjectionReifier<TOrig, TDest>
        : ReifierBase<TOrig, TDest>
    {
        ReifyContext _ctx;
        DataType _dataType;

        public ProjectionReifier(ReifyContext ctx, DataType dataType) {
            _ctx = ctx;
            _dataType = dataType;
        }

        protected override Expression MapSingle(Expression exSource) {
            return Expression.MemberInit(
                                Expression.New(_dataType.Type),
                                BuildBindings(exSource)
                                );
        }

        MemberBinding[] BuildBindings(Expression exSource) {
            return _dataType.FieldMaps
                            .Select(f => Expression.Bind(
                                                    f.Field,
                                                    Expression.MakeMemberAccess(exSource, f.SourceMember)) //need to delegate to other reifiers...
                            ).ToArray();

            //I need to delegate to subreifiers. But what mappings will these be effecting?
            //depends on the mapping between source and dest types

            //as things are with projection, all source properties are brought into the data type, which is fair enough,
            //so we fetch all we need for reconstitution.

            //the expression to be bound with each member is the subreifier's concern. And the type of the expression
            //it offers us should be respected, in that our own custom type must accommodate it. 
            //Reconstition is a further step; offering up the correct eventual types is not important here.

            //With this the case, then any rule that delegates downwards must expect custom types, and must
            //accommodate them. That is, even innocent PropertyMappings need custom data types.

            //To decide on its own behaviour, each ruled node therefore first needs to examine its children,
            //rather than deciding up front, then chugging out child reifiers monolithically. 

            //This is a sub-rule, indeed, selectable only after children have been examined. At which point does
            //such examination become possible? Either with the fetching of a typemap, or the analysis of the
            //needs of a projection expression.

            //Non-EDM-compatible projections need simply need data types populating; only reconstitution actually
            //applies the projection; the expression-mapping behaviour is identical to non-direct property maps.

            //And whether property mapping is direct or indirect via a data type is again decided by delegating
            //to child nodes. First step of consulting children is common.

            //But the decision of whether we need to consult with children is itself rule-determined. As if the very
            //top-level rule objects need to delegate downwards before deciding their own applicability. Yet it is the
            //rule itself that identifies possible children. So does each rule need to delegate downwards just to say
            //yes or no? This is unavoidable. Unless this common information is aggregated beforehand by the too-clever
            //runner. Like rules should be able to request cached information objects from their context. The context
            //would of course be fresh for each stratum.

            //So DirectPropertyMap rule would test for TypeMap object, then would get rules for all children,
            //before deciding on its own applicability. Would these child rules, still of use to IndirectPropertyMap,
            //be jettisoned? Surely not... Could I suppose delegate directly to IndirectPropertyMap here - could in fact
            //just serve different factory. This would seem simplest solution.

            //But how could we get these child rules in their totality? Only in the full analysis (currently taking place 
            //in factory ctor) of each rule's situation can each child decision be made. This decision must then
            //be made up front and returned by the rule itself. Functionality needs to creep back from the factory to
            //the rule itself. Yet, as is, this won't be strongly-typed, as that is the advantage of the factory.






            //Seems then that splitting rules horizontally makes no sense: different rules share too many behaviours.
            //Need behaviours as set of components, built up through analysis of probelm at hand.

            //Components of algo:
            //  > Member values required
            //      - either PropertyMaps or from projection exp.
            //  > Get mapped value expressions from below
            //  > Based on these, do we need to use custom data type?
            //  
            //
            //
            //
            //
            // ProjectRule ReformRule






        }
        

        protected override TDest ReformSingle(object orig) {
            throw new NotImplementedException();
        }
    }



}
