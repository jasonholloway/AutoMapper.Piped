using System;
using Materialize.Types;
using Materialize.Expressions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Reflection;
using System.Data.Entity.Core.Metadata.Edm;
using System.Collections.Concurrent;

namespace Materialize.SourceRegimes
{
    //But how will this hook in to library? Via some app.config rule? 
    
    //Need to hackily summon an instance of eLinq.ExpressionConverter.MethodCallTranslator to do our bidding...?

        
    class EF6RegimeProvider : ISourceRegimeProvider
    {        

        #region Static accessor creation (via hacky reflection)

        static Assembly _asmEF = typeof(DbQuery).Assembly;

        static Type _tDbQueryProvider = _asmEF.GetType("System.Data.Entity.Internal.Linq.DbQueryProvider");
        static Type _tInternalContext = _asmEF.GetType("System.Data.Entity.Internal.InternalContext");

        static Func<IQueryProvider, DbContext> FnGetDbContext = BuildFnGetDbContext();
        
        //the below could be threaded off somehow... (eg make lazy and access from thread on start)
        static Func<IQueryProvider, DbContext> BuildFnGetDbContext() 
        {        
            var exParam = Expression.Parameter(typeof(IQueryProvider));
            
            var exLambda = Expression.Lambda<Func<IQueryProvider, DbContext>>(
                                Expression.Condition(
                                    Expression.TypeIs(exParam, _tDbQueryProvider),
                                    Expression.MakeMemberAccess(
                                            Expression.MakeMemberAccess(
                                                    Expression.Convert(exParam, _tDbQueryProvider),
                                                    _tDbQueryProvider.GetField("_internalContext", BindingFlags.NonPublic | BindingFlags.Instance)
                                                    ),
                                            _tInternalContext.GetProperty("Owner")                                                    
                                            ),
                                    Expression.Default(typeof(DbContext))
                                    ),
                                exParam
                                );

            return exLambda.Compile();
        }
        
        #endregion
        

        ConcurrentDictionary<MetadataWorkspace, ISourceRegime> _dRegimeCache
            = new ConcurrentDictionary<MetadataWorkspace, ISourceRegime>();
        

        public ISourceRegime GetRegime(IQueryable qySource) 
        {
            var dbContext = FnGetDbContext(qySource.Provider);
            
            if(dbContext != null) {                
                return _dRegimeCache.GetOrAdd(
                                        dbContext.GetMetadata(),
                                        m => new EF6Regime(m));
            }
                        
            return null;
        }
        
    }


    class EF6Regime : ISourceRegime
    {

        #region Hacky reflection here

        static Func<EdmType, Type> FnGetClrType = BuildFnGetClrType();

        static Func<EdmType, Type> BuildFnGetClrType() {
            var exParam = Expression.Parameter(typeof(EdmType));

            var exLambda = Expression.Lambda<Func<EdmType, Type>>(
                                        Expression.MakeMemberAccess(
                                                exParam,
                                                typeof(EdmType).GetProperty("ClrType", BindingFlags.NonPublic | BindingFlags.Instance)
                                                ),
                                        exParam
                                        );

            return exLambda.Compile();
        }



        static Assembly _asmEF = typeof(DbQuery).Assembly;
        static Type _tFuncletizer = _asmEF.GetType("System.Data.Entity.Core.Objects.ELinq.Funcletizer");
        static Type _tExpressionConverter = _asmEF.GetType("System.Data.Entity.Core.Objects.ELinq.ExpressionConverter");


        static object Funcletizer = BuildFuncletizer();
        static object ExpressionConverter = BuildExpressionConverter();
        

        static object BuildFuncletizer() {
            var mCreate = _tFuncletizer.GetMethod(
                                            "CreateCompiledQueryLockdownFuncletizer",
                                            BindingFlags.Static
                                            | BindingFlags.NonPublic);

            return mCreate.Invoke(null, new object[0]);
        }

        static object BuildExpressionConverter() 
        {
            var ctor = _tExpressionConverter.GetConstructor(
                                                BindingFlags.NonPublic | BindingFlags.Instance,
                                                null,
                                                new Type[] { _tFuncletizer, typeof(Expression) },
                                                null);

            var conv = ctor.Invoke(new object[] { Funcletizer, Expression.Constant(9) });

            return conv;
        }




        static Action<Expression> FnTestExpression = BuildFnTestExpression();

        static Action<Expression> BuildFnTestExpression() 
        {
            var exExpParam = Expression.Parameter(typeof(Expression));
            
            var exLambda = Expression.Lambda<Action<Expression>>(
                                    Expression.Call(
                                            Expression.Constant(ExpressionConverter, _tExpressionConverter),
                                            _tExpressionConverter.GetMethod(
                                                                    "TranslateExpression",
                                                                    BindingFlags.NonPublic | BindingFlags.Instance,
                                                                    null,
                                                                    new[] { typeof(Expression) },
                                                                    null),
                                            exExpParam),     
                                    exExpParam
                                    );

            return exLambda.Compile();
        }


        #endregion
        

        ISet<Type> _mappedTypes;
        
        public EF6Regime(MetadataWorkspace metadata) 
        {
            _mappedTypes = new HashSet<Type>(metadata.GetItems(DataSpace.OSpace)
                                                        .OfType<EdmType>()
                                                        .Where(t => t is EntityType || t is ComplexType)
                                                        .Select(t => FnGetClrType(t)));
        }
               

        public bool ServerAccepts(Expression exp) 
        {
            return !exp.Contains(ex => {                                                
                var exNew = ex as NewExpression;

                if(exNew != null) {
                    //No parameterized ctors!
                    if(exNew.Constructor.GetParameters().Any()) {
                        return true;
                    }

                    //No creation of mapped entities!
                    if(_mappedTypes.Contains(exNew.Type)) {
                        return true;
                    }
                }

                if(ex is MemberExpression) {
                    FnTestExpression(ex);
                }
                
                //No non-model member accesses!

                //No non-EDM functions!



                return false;
            });

            

            
        }
    }
}
