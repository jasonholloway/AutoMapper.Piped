using System;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionConverter = System.Object;
using Funcletizer = System.Object;

namespace Materialize.SourceRegimes
{

    internal class EF6Regime : ISourceRegime
    {
        DbContext _dbContext;

        public EF6Regime(DbContext dbContext) {
            _dbContext = dbContext;
        }

        public bool ServerAccepts(Expression ex) {
            var tester = new ExpressionTester(_dbContext);
            return tester.Test(ex).Success;
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

        static Action<ExpressionConverter, Expression, DbExpression> PushBindingScope
            = Exec(() => {
                var tBindingContext = _asmEF.GetType("System.Data.Entity.Core.Objects.ELinq.BindingContext");
                var tBinding = _asmEF.GetType("System.Data.Entity.Core.Objects.ELinq.Binding");

                var mPushScope = tBindingContext.GetMethod(
                                                    "PushBindingScope",
                                                    BindingFlags.NonPublic | BindingFlags.Instance);

                var fBindingContext = _tExpressionConverter.GetField(
                                                                "_bindingContext",
                                                                BindingFlags.NonPublic | BindingFlags.Instance);

                var ctorBinding = tBinding.GetConstructor(
                                            BindingFlags.NonPublic | BindingFlags.Instance,
                                            null,
                                            new Type[] { typeof(Expression), typeof(DbExpression) },
                                            null);

                var exConverter = Expression.Parameter(typeof(object));
                var exExp = Expression.Parameter(typeof(Expression));
                var exDbExp = Expression.Parameter(typeof(DbExpression));
                
                var exLambda = Expression.Lambda<Action<ExpressionConverter, Expression, DbExpression>>(
                                            Expression.Call(
                                                Expression.MakeMemberAccess(                                                    
                                                            Expression.Convert(exConverter, _tExpressionConverter),
                                                            fBindingContext),
                                                mPushScope,
                                                Expression.New(
                                                            ctorBinding,
                                                            exExp,
                                                            exDbExp)
                                                ),
                                            exConverter,
                                            exExp,
                                            exDbExp);

                return exLambda.Compile();
            });

        static Func<TypeUsage, DbNullExpression> CreateDbNullExpression
            = Exec(() => {
                var exTypeUsage = Expression.Parameter(typeof(TypeUsage));
                
                var exLambda = Expression.Lambda<Func<TypeUsage, DbNullExpression>>(
                                                Expression.New(
                                                    typeof(DbNullExpression).GetConstructor(
                                                                BindingFlags.NonPublic | BindingFlags.Instance,
                                                                null,
                                                                new[] { typeof(TypeUsage) },
                                                                null),
                                                    exTypeUsage
                                                    ),
                                            exTypeUsage);

                return exLambda.Compile();
            });



        delegate void GetTypeUsageDelegate(ExpressionConverter converter, Type type, out TypeUsage typeUsage);

        static GetTypeUsageDelegate GetTypeUsageFromClrType
            = Exec(() => {
                var mTryGetValueLayerType = _tExpressionConverter.GetMethod(
                                                                    "TryGetValueLayerType",
                                                                    BindingFlags.NonPublic | BindingFlags.Instance);

                var exConverter = Expression.Parameter(typeof(object));
                var exType = Expression.Parameter(typeof(Type));
                var exTypeUsage = Expression.Parameter(typeof(TypeUsage).MakeByRefType());

                var exLambda = Expression.Lambda<GetTypeUsageDelegate>(
                                            Expression.Call(
                                                Expression.Convert(exConverter, _tExpressionConverter),
                                                mTryGetValueLayerType,
                                                exType,
                                                exTypeUsage),
                                            exConverter,
                                            exType,
                                            exTypeUsage);

                return exLambda.Compile();
            });


        #endregion
        
        Funcletizer _funcletizer;

        public ExpressionTester(DbContext dbContext) 
        {
            var objContext = dbContext.GetObjectContext();
            _funcletizer = CreateFuncletizer(objContext);       
        }
                
        public Result Test(Expression ex) 
        {
            //if lambda, ef will not convert naturally: params need to be artificially bound
            //to dummy DbExpressions, and body of lambda tested            

            int cBinding = 0;
            var exLambda = ex as LambdaExpression;
            
            try {
                var converter = CreateConverter(
                                        _funcletizer, 
                                        exLambda != null ? exLambda.Body : ex);
                
                if(exLambda != null) {
                    foreach(var exParam in exLambda.Parameters) 
                    {
                        TypeUsage typeUsage = null;                        
                        GetTypeUsageFromClrType(converter, exParam.Type, out typeUsage);

                        PushBindingScope(converter, exParam, CreateDbNullExpression(typeUsage)); //bind param to null DbExpression - type, not value, is tested
                    }
                }
                
                var dbExp = InvokeConvert(converter);

                return new Result(true);
            }
            catch(NotSupportedException e) {
                return new Result(e);
            }
            finally {
                for(int i = 0; i < cBinding; i++) {
                    //PopBindingScope(converter); //Not needed with current usage!
                }
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
    

}
