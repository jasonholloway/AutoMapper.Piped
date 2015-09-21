using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing2
{
    class RebaserVisitor : ExpressionVisitor
    {
        RebaseContext _ctx;

        RebaseSpec _spec;
        
        public ParameterExpression OldRootParam { get; private set; }
        public ParameterExpression NewRootParam { get; private set; }


        public RebaserVisitor(RebaseSpec spec, ParameterExpression exOldRootParam) {
            _spec = spec;
            OldRootParam = exOldRootParam;
            NewRootParam = Expression.Parameter(_spec.RebasedType);

            _ctx = new RebaseContext();
        }

        protected override Expression VisitParameter(ParameterExpression node) {
            if(node == OldRootParam) {
                _ctx = new RebaseContext();
                return NewRootParam;
            }

            throw new InvalidOperationException("Non-root parameter encountered!");
        }


        protected override Expression VisitMethodCall(MethodCallExpression node) 
        {
            if(node.Method.IsGenericMethod 
                && node.Method.DeclaringType == typeof(Queryable)) 
            {
                var methodDef = node.Method.GetGenericMethodDefinition();

                if(methodDef == QueryableMethods.WhereDef) {
                    var exUpstream = Visit(node.Arguments.First());

                    //and now to get upstream info...


                }
            }

            throw new InvalidOperationException("Unhandled method call encountered!");
        }



    }
}
