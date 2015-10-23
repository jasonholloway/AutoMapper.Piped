using Materialize.Reify2.Rebasing.Methods;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2.Rebasing
{
    partial class Rebaser 
    {
        protected override IRebaseStrategy VisitMethodCall(MethodCallExpression exCall) 
        {
            var methodStrategizer = new MethodRebaser(new ParentRebaserAdaptor(this));

            return methodStrategizer.Strategize(exCall);
        }




        class ParentRebaserAdaptor : IParentRebaser
        {
            Rebaser _strategizer;

            public ParentRebaserAdaptor(Rebaser strategizer) {
                _strategizer = strategizer;
            }

            public Rebaser SpawnNestedVisitor(Action<IRootStrategyRegistrar> fnRegister) {
                return _strategizer.SpawnNestedRebaser(fnRegister);
            }

            public IRebaseStrategy Visit(Expression ex) {
                return _strategizer.Visit(ex);
            }
        }


    }
}
