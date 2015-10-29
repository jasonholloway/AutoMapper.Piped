using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

namespace Materialize.Reify2.Params
{    

    internal class ExpressionPather
    {
        Action<Expression, PathInfo> _fnAction;        
        Stack<Func<object, object>> _stAccessors;
                
        public ExpressionPather(Action<Expression, PathInfo> fnAction) {
            _fnAction = fnAction;
            _stAccessors = new Stack<Func<object, object>>();
        }
        
        
        public class PathInfo
        {
            IEnumerable<Func<object, object>> _subAccessors;

            public PathInfo(IEnumerable<Func<object, object>> subAccessors) {
                _subAccessors = subAccessors;
            }

            public Func<Expression, Expression> GetAccessor() {                
                var rSubAccessors = _subAccessors.ToArray();
                Array.Reverse(rSubAccessors);

                return (ex) => (Expression)rSubAccessors.Aggregate((object)ex, (e, fn) => fn(e));
            }
        }



        public void Path(Expression ex) {
            Visit(ex);
        }






        void Delve<TNode, TChild>(TNode node, Func<TNode, TChild> fnCrawl) {
            _stAccessors.Push(x => fnCrawl((TNode)x));

            var child = fnCrawl(node);

            if(child != null) {
                Visit((dynamic)child); //should type out special Visit(object) method to delegate correctly, instead of DLR
            }

            _stAccessors.Pop();
        }

        


        void Visit(Expression ex) {
            if(ex == null) return;
            
            _fnAction(ex, new PathInfo(_stAccessors));

            switch(ex.NodeType) {
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                case ExpressionType.UnaryPlus:
                    VisitUnary((UnaryExpression)ex);
                    break;
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Power:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                    VisitBinary((BinaryExpression)ex);
                    break;
                case ExpressionType.TypeIs:
                    VisitTypeIs((TypeBinaryExpression)ex);
                    break;
                case ExpressionType.Conditional:
                    VisitConditional((ConditionalExpression)ex);
                    break;
                case ExpressionType.Constant:
                    VisitConstant((ConstantExpression)ex);
                    break;
                case ExpressionType.Parameter:
                    VisitParameter((ParameterExpression)ex);
                    break;
                case ExpressionType.MemberAccess:
                    VisitMemberAccess((MemberExpression)ex);
                    break;
                case ExpressionType.Call:
                    VisitMethodCall((MethodCallExpression)ex);
                    break;
                case ExpressionType.Lambda:
                    VisitLambda((LambdaExpression)ex);
                    break;
                case ExpressionType.New:
                    VisitNew((NewExpression)ex);
                    break;
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    VisitNewArray((NewArrayExpression)ex);
                    break;
                case ExpressionType.Invoke:
                    VisitInvocation((InvocationExpression)ex);
                    break;
                case ExpressionType.MemberInit:
                    VisitMemberInit((MemberInitExpression)ex);
                    break;
                case ExpressionType.ListInit:
                    VisitListInit((ListInitExpression)ex);
                    break;
                default:
                    throw new ArgumentException(string.Format("Unhandled expression type: '{0}'", ex.NodeType));
            }

        }


        void Visit(MemberBinding binding) {
            switch(binding.BindingType) {
                case MemberBindingType.Assignment:
                    VisitMemberAssignment((MemberAssignment)binding);
                    break;
                case MemberBindingType.ListBinding:
                    VisitMemberListBinding((MemberListBinding)binding);
                    break;
                case MemberBindingType.MemberBinding:
                    VisitMemberMemberBinding((MemberMemberBinding)binding);
                    break;
            }
        }

        void Visit(ElementInit init) {
            VisitInitializer(init);
        }


        void Visit<T>(IList<T> list) {
            for(int i = 0; i < list.Count; i++) {
                int index = i;
                Delve(list, l => l[index]);
            }
        }
        
                
                


        void VisitMemberAssignment(MemberAssignment assign) {
            Delve(assign, a => a.Expression);
        }

        void VisitMemberListBinding(MemberListBinding bind) {
            Delve(bind, b => b.Initializers);
        }

        void VisitMemberMemberBinding(MemberMemberBinding bind) {
            Delve(bind, b => b.Bindings);
        }
        
        

        void VisitBinary(BinaryExpression binary) {
            Delve(binary, b => b.Conversion);
            Delve(binary, b => b.Left);
            Delve(binary, b => b.Right);
        }        

        void VisitConditional(ConditionalExpression conditional) {
            Delve(conditional, x => x.Test);
            Delve(conditional, x => x.IfFalse);
            Delve(conditional, x => x.IfTrue);
        }

        void VisitConstant(ConstantExpression constant) {
            //...
        }

        void VisitInitializer(ElementInit init) {
            Delve(init, i => i.Arguments);
        }
        
        void VisitInvocation(InvocationExpression invocation) {
            Delve(invocation, i => i.Arguments);
            Delve(invocation, i => i.Expression);
        }

        void VisitLambda(LambdaExpression lambda) {
            Delve(lambda, l => l.Parameters);
            Delve(lambda, l => l.Body);
        }
                        
        void VisitListInit(ListInitExpression init) {
            Delve(init, i => i.NewExpression);
            Delve(init, i => i.Initializers);
        }

        void VisitMemberAccess(MemberExpression member) {
            Delve(member, m => m.Expression);
        }

        void VisitMemberInit(MemberInitExpression init) {
            Delve(init, i => i.NewExpression);
            Delve(init, i => i.Bindings);
        }

        void VisitMethodCall(MethodCallExpression call) {
            Delve(call, c => c.Arguments);
            Delve(call, c => c.Object);
        }

        void VisitNew(NewExpression nex) {
            Delve(nex, n => n.Arguments);
        }

        void VisitNewArray(NewArrayExpression newArray) {
            Delve(newArray, n => n.Expressions);
        }

        void VisitParameter(ParameterExpression param) {
            //...
        }

        void VisitTypeIs(TypeBinaryExpression type) {
            Delve(type, t => t.Expression);
        }

        void VisitUnary(UnaryExpression unary) {
            Delve(unary, u => u.Operand);
        }
    }
}
