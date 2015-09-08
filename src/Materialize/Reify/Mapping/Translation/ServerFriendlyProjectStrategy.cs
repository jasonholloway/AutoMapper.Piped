using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using JH.DynaType;
using System.Reflection;
using Materialize.Reify.Modifiers;

namespace Materialize.Reify.Mapping.Translation
{
    class ServerFriendlyProjectStrategy<TOrig, TDest>
        : StrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        LambdaExpression _exProject;
        
        public ServerFriendlyProjectStrategy(MapContext ctx, TypeMap typeMap) 
        {
            _ctx = ctx;
            _exProject = typeMap.CustomProjection;            
        }

        public override Type FetchedType {
            get { return typeof(TDest); }
        }
        
        public override IModifier CreateModifier() {
            return new Mapper(_exProject);
        }
        


        class Mapper : MapperModifier<TOrig, TDest>
        {
            LambdaExpression _exProject;

            public Mapper(LambdaExpression exProject) {
                _exProject = exProject;
            }

            protected override Expression RewriteSingle(Expression exSource) {
                throw new NotImplementedException();
            }

            protected override TDest TransformSingle(TDest obj) {
                throw new NotImplementedException();
            }
        }


    }

    

    class EdmCompProjectionReifier<TOrig, TDest>
        : MapperModifier<TOrig, TDest>
    {
        MapContext _ctx;
        DataType _dataType;

        public EdmCompProjectionReifier(MapContext ctx, DataType dataType) {
            _ctx = ctx;
            _dataType = dataType;
        }

        protected override Expression RewriteSingle(Expression exSource) 
        {
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

        protected override TDest TransformSingle(TDest obj) {
            throw new NotImplementedException();
        }
        
    }



}
