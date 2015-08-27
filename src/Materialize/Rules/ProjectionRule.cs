﻿using AutoMapper;
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
        LambdaExpression _exProject;
        DataType _dataType;

        public ProjectionReifierFactory(TypeMap typeMap) 
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
        : IReifier<TOrig, TDest>
    {
        ReifyContext _ctx;
        DataType _dataType;

        public ProjectionReifier(ReifyContext ctx, DataType dataType) {
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
                                                    Expression.MakeMemberAccess(exSource, f.SourceMember)) //need to delegate to other reifiers...
                            ).ToArray();
        }


        public object Finalize(object orig) {
            throw new NotImplementedException();
        }
    }



}
