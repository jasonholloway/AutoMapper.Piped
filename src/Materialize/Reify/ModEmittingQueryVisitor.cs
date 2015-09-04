using Materialize.Reify.Mods;
using Materialize.Reify.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{
    class ModEmittingQueryVisitor : ExpressionVisitor
    {
        IQueryable _rootQueryable;
        Action<IMod> _fnModSink;


        public ModEmittingQueryVisitor(
            IQueryable rootQueryable, 
            Action<IMod> fnModSink) 
        {
            _rootQueryable = rootQueryable;
            _fnModSink = fnModSink;
        }
        

        void Emit(IMod mod) {
            _fnModSink(mod);
        }


        protected override Expression VisitConstant(ConstantExpression node) {
            if(node.Value == _rootQueryable) {
                //...
            }

            return base.VisitConstant(node);
        }



        protected override Expression VisitMethodCall(MethodCallExpression node) 
        {
            Visit(node.Object);

            foreach(var arg in node.Arguments) {
                Visit(arg);
            }


            string methodName = node.Method.DeclaringType.FullName + "." + node.Method.Name;

            switch(methodName) {
                case "System.Linq.Queryable.First":
                case "System.Linq.Queryable.FirstOrDefault":
                case "System.Linq.Queryable.Last":
                case "System.Linq.Queryable.LastOrDefault":
                case "System.Linq.Queryable.Single":
                case "System.Linq.Queryable.SingleOrDefault":
                    Emit(new ImprovMod(
                                exSrcQuery => Expression.Call(exSrcQuery, node.Method)
                                ));
                    break;

                default:
                    //append to objTransform - simple translation to IEnumerable
                    break;


                //but we don't know what subclauses there may be, so we're quite wrong to naively
                //stack method-nodes up in a one-dimensional series. Should only further visit

                //should really have my own custom visitor that is only sensitive to MethodCalls and constants

            }

            return null;
        }

        //should really limit visiting to other expression nodes
        //but not entirely necessary at mo...

    }
}
