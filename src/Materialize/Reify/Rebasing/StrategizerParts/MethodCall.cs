using Materialize.Reify.Rebasing.Methods;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Rebasing
{
    partial class RebaseStrategizer 
    {
        protected override IRebaseStrategy VisitMethodCall(MethodCallExpression exCall) 
        {
            var methodStrategizer = new MethodRebaseStrategizer(new ParentStrategizerAdaptor(this));

            return methodStrategizer.Strategize(exCall);
        }




        class ParentStrategizerAdaptor : IParentRebaseStrategizer
        {
            RebaseStrategizer _strategizer;

            public ParentStrategizerAdaptor(RebaseStrategizer strategizer) {
                _strategizer = strategizer;
            }

            public RebaseStrategizer SpawnNestedStrategizer(Action<IRootStrategyRegistrar> fnRegister) {
                return _strategizer.SpawnNestedStrategizer(fnRegister);
            }

            public IRebaseStrategy Visit(Expression ex) {
                return _strategizer.Visit(ex);
            }
        }


    }
}
