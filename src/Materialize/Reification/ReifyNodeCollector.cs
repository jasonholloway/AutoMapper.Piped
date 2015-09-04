using Materialize.Reification.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reification
{
    class ReifyNodeCollector : ExpressionVisitor
    {
        public IQueryable RootQueryable { get; private set; }
        public IReifyNode RootReifyNode { get; private set; }
        public Stack<IReifyNode> ReifyNodes { get; private set; }
        

        public ReifyNodeCollector(
            IQueryable rootQueryable, 
            IReifyNode rootReifyNode) 
        {
            RootQueryable = rootQueryable;
            RootReifyNode = rootReifyNode;
            ReifyNodes = new Stack<IReifyNode>();
        }


        protected override Expression VisitConstant(ConstantExpression node) {
            if(node.Value == RootQueryable) {
                ReifyNodes.Push(RootReifyNode);
            }

            return base.VisitConstant(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node) 
        {
            string methodName = node.Method.DeclaringType.FullName + "." + node.Method.Name;

            switch(methodName) {
                case "System.Linq.Queryable.First":
                case "System.Linq.Queryable.FirstOrDefault":
                case "System.Linq.Queryable.Last":
                case "System.Linq.Queryable.LastOrDefault":
                case "System.Linq.Queryable.Single":
                case "System.Linq.Queryable.SingleOrDefault":
                    ReifyNodes.Push(new SimpleUnaryMod(node.Method));
                    break;

                default:
                    //append to objTransform - simple translation to IEnumerable
                    break;


                //but we don't know what subclauses there may be, so we're quite wrong to naively
                //stack method-nodes up in a one-dimensional series. Should only further visit

                //should really have my own custom visitor that is only sensitive to MethodCalls and constants

            }

            Visit(node.Object);
            return null;
        }

        //should really limit visiting to other expression nodes
        //but not entirely necessary at mo...

    }
}
