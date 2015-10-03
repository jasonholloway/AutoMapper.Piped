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
using System.Collections;

using ExpressionConverter = System.Object;
using Funcletizer = System.Object;
using Translator = System.Object;
using System.Data.Entity.Core.Common.CommandTrees;

namespace Materialize.SourceRegimes
{
    //But how will this hook in to library? Via some app.config rule? 
           
        
    class EF6RegimeProvider : ISourceRegimeProvider
    {        
        #region Static accessor creation (via hacky reflection)

        static T Exec<T>(Func<T> fn) { return fn(); }
        
        static Assembly _asmEF = typeof(DbQuery).Assembly;

        static Type _tDbQueryProvider = _asmEF.GetType("System.Data.Entity.Internal.Linq.DbQueryProvider");
        static Type _tInternalContext = _asmEF.GetType("System.Data.Entity.Internal.InternalContext");

        static Func<IQueryProvider, DbContext> GetDbContext
            = Exec(() => {
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
            });
        
        #endregion
        

        ConcurrentDictionary<Type, ISourceRegime> _dRegimeCache
            = new ConcurrentDictionary<Type, ISourceRegime>();
        

        public ISourceRegime GetRegime(IQueryable qySource) 
        {
            var dbContext = GetDbContext(qySource.Provider);
            
            if(dbContext != null) {                
                return _dRegimeCache.GetOrAdd(
                                        dbContext.GetType(),
                                        _ => new EF6Regime(dbContext));
            }
                        
            return null;
        }
        
    }
        


    class ExpressionTester
    {
        #region Hacky reflection here!

        static T Exec<T>(Func<T> fn) { return fn(); }

        static Assembly _asmEF = typeof(DbQuery).Assembly;

        static Type _tExpressionConverter = _asmEF.GetType("System.Data.Entity.Core.Objects.ELinq.ExpressionConverter");
        static Type _tFuncletizer = _asmEF.GetType("System.Data.Entity.Core.Objects.ELinq.Funcletizer");
        
        static Func<ObjectContext, Funcletizer> CreateFuncletizer
            = Exec(() => {
                var exObjContext = Expression.Parameter(typeof(ObjectContext));

                var exLambda = Expression.Lambda<Func<ObjectContext, Funcletizer>>(
                                    Expression.Call(
                                        _tFuncletizer.GetMethod(
                                                        "CreateQueryFuncletizer",
                                                        BindingFlags.NonPublic | BindingFlags.Static,
                                                        null,
                                                        new[] { typeof(ObjectContext) },
                                                        null),
                                        exObjContext),                                                    
                                    exObjContext);

                return exLambda.Compile();
            });

        static Func<Funcletizer, Expression, ExpressionConverter> CreateConverter
            = Exec(() => {
                var exFuncletizer = Expression.Parameter(typeof(object));
                var exExpression = Expression.Parameter(typeof(Expression));

                var exLambda = Expression.Lambda<Func<Funcletizer, Expression, ExpressionConverter>>(
                                            Expression.New(
                                                _tExpressionConverter.GetConstructor(
                                                                        BindingFlags.NonPublic | BindingFlags.Instance,
                                                                        null,
                                                                        new[] { _tFuncletizer, typeof(Expression) },
                                                                        null
                                                                        ),
                                                Expression.Convert(exFuncletizer, _tFuncletizer),
                                                exExpression
                                                ),
                                            exFuncletizer,
                                            exExpression
                                            );

                return exLambda.Compile();
            });
                
        static Func<ExpressionConverter, DbExpression> InvokeConvert
            = Exec(() => {
                var mConvert = _tExpressionConverter.GetMethod(
                                                        "Convert",
                                                        BindingFlags.NonPublic | BindingFlags.Instance);

                var exConverter = Expression.Parameter(typeof(object));

                var exLambda = Expression.Lambda<Func<ExpressionConverter, DbExpression>>(
                                        Expression.Call(
                                                Expression.Convert(exConverter, _tExpressionConverter),
                                                mConvert),
                                        exConverter);

                return exLambda.Compile();
            });

        #endregion


        Funcletizer _funcletizer;

        public ExpressionTester(DbContext dbContext) 
        {
            var objContext = ((IObjectContextAdapter)dbContext).ObjectContext;
            _funcletizer = CreateFuncletizer(objContext);       
        }
                
        public Result Test(Expression ex) {
            var converter = CreateConverter(_funcletizer, ex);
            
            try {
                var dbExp = InvokeConvert(converter);
                return new Result(true);
            }
            catch(NotSupportedException e) {
                return new Result(e);
            }
        }
        
        public struct Result
        {
            public readonly bool Success;
            public readonly Exception Exception;

            public Result(bool bSuccess) {
                Success = bSuccess;
                Exception = null;
            }

            public Result(Exception exception) {
                Success = false;
                Exception = exception;
            }
        }

    }




    class EF6Regime : ISourceRegime
    { 
        DbContext _dbContext;
                
        public EF6Regime(DbContext dbContext) {
            _dbContext = dbContext;
        }
               
        public bool ServerAccepts(Expression ex) 
        {
            var tester = new ExpressionTester(_dbContext);
            return tester.Test(ex).Success;
        }
    }
}
