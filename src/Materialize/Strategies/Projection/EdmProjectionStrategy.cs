using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using JH.DynaType;
using System.Reflection;

namespace Materialize.Strategies.Projection
{
    class EdmProjectionStrategy<TOrig, TDest>
        : ReifierStrategy<TOrig, TDest>
    {
        LambdaExpression _exProject;
        DataType _dataType;

        public EdmProjectionStrategy(TypeMap typeMap) 
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


        public override bool UsesIntermediateType {
            get { throw new NotImplementedException(); }
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
            return new EdmCompProjectionReifier<TOrig, TDest>(ctx, _dataType);
        }
    }

    

    class EdmCompProjectionReifier<TOrig, TDest>
        : IReifier<TOrig, TDest>
    {
        ReifyContext _ctx;
        DataType _dataType;

        public EdmCompProjectionReifier(ReifyContext ctx, DataType dataType) {
            _ctx = ctx;
            _dataType = dataType;
        }

        public Expression Map(Expression exSource) {
            return Expression.MemberInit(
                                Expression.New(_dataType.Type),
                                BuildBindings(exSource)
                                );
        }

        MemberBinding[] BuildBindings(Expression exSource) {
            return _dataType.FieldMaps
                            .Select(f => Expression.Bind(
                                                    f.Field,
                                                    Expression.MakeMemberAccess(exSource, f.SourceMember))
                            ).ToArray();
        }


        public object Reform(object orig) {
            throw new NotImplementedException();
        }
    }



}
