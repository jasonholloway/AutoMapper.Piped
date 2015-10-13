using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Rebasing.Methods
{
    
    abstract class LinqMethodRule
        : IMethodRebaseRule
    {
        ISet<MethodInfo> _methodDefs;

        public LinqMethodRule(MethodInfo[] methodDefs) {
            _methodDefs = new HashSet<MethodInfo>(methodDefs);
        }


        bool IMethodRebaseRule.Accepts(MethodRebaseSubject ctx) 
        {
            return _methodDefs.Contains(ctx.MethodDef);
        }
        
        IRebaseStrategy IMethodRebaseRule.CreateStrategy(
            MethodRebaseSubject ctx, 
            IParentRebaseStrategizer parentStrategizer) 
        {
            return CreateStrategy(new LinqMethodContext(ctx, parentStrategizer));
        }

        

        protected abstract IRebaseStrategy CreateStrategy(LinqMethodContext ctx);




        protected IRebaseStrategy PassiveStrategy(Type type) {
            return new PassiveRebaseStrategy(type);
        }

        protected IRebaseStrategy RootedStrategy<TExp>(IRebaseStrategy upstreamStrategy, Func<TExp, TExp> fnRebase)
            where TExp : Expression {
            return new RebaseStrategy<TExp>(upstreamStrategy, fnRebase);
        }

        protected IRebaseStrategy RootedStrategy<TExp>(TypeVector typeVector, IRebaseStrategy upstreamStrategy, Func<TExp, TExp> fnRebase)
            where TExp : Expression {
            return new RebaseStrategy<TExp>(typeVector, upstreamStrategy, fnRebase);
        }

        protected IRebaseStrategy UnrootedStrategy<TExp>(TypeVector typeVector, Func<TExp, TExp> fnRebase)
            where TExp : Expression {
            return new RebaseStrategy<TExp>(typeVector, null, fnRebase);
        }




        protected class LinqMethodContext
        {
            public readonly MethodCallExpression CallExp;
            public readonly MethodInfo MethodDef;
            public readonly IRebaseStrategy UpstreamStrategy;
                                    
            public readonly Type RebasedElemType;

            IParentRebaseStrategizer _parentStrategizer;

            public LinqMethodContext(
                MethodRebaseSubject ctx,
                IParentRebaseStrategizer parentStrategizer) 
            {
                _parentStrategizer = parentStrategizer;
                
                CallExp = ctx.CallExp;
                MethodDef = ctx.MethodDef;
                
                UpstreamStrategy = Strategize(CallExp.Arguments[0]);

                RebasedElemType = UpstreamStrategy.TypeVector
                                                    .DestType.GetEnumerableElementType();                
            }



            public RebaseStrategizer SpawnNestedStrategizer(Action<RebaseStrategizer.IRootStrategyRegistrar> fnRegistrar) {
                return _parentStrategizer.SpawnNestedStrategizer(fnRegistrar);
            }


            public IRebaseStrategy Strategize(Expression exSubject) {
                return _parentStrategizer.Visit(exSubject);
            }


            public IRebaseStrategy StrategizePredicate(LambdaExpression exPred) 
            {
                var roots = new RootVector(
                                        exPred.Parameters.Single(),
                                        Expression.Parameter(RebasedElemType));
                
                var rootStrategy = UpstreamStrategy.GetRootStrategy(roots);
                
                var bodyStrategizer = SpawnNestedStrategizer(x => {
                    x.AddRootStrategy(roots.OrigRoot, rootStrategy);
                });

                var bodyStrategy = bodyStrategizer.Strategize(exPred.Body);
                var exRebasedParam = (ParameterExpression)roots.RebasedRoot;

                TypeVector typeVector = new TypeVector(
                                                exPred.Type, 
                                                typeof(Func<,>).MakeGenericType(
                                                                        exRebasedParam.Type,
                                                                        bodyStrategy.TypeVector.DestType
                                                                        ));

                return new RebaseStrategy<LambdaExpression>(
                                        typeVector,
                                        null,
                                        (LambdaExpression ex) => {
                                            return Expression.Lambda(
                                                                bodyStrategy.Rebase(ex.Body),
                                                                exRebasedParam);
                                        });                
            }
            

        }

    }
}
