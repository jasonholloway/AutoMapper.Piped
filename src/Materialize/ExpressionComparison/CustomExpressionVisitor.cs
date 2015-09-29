using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Materialize.ExpressionComparison
{
    abstract class CustomExpressionVisitor<TResult>
    {
        protected virtual TResult Visit(Expression expression) {
            if(expression == null)
                return default(TResult);

            switch(expression.NodeType) {
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                case ExpressionType.UnaryPlus:
                    return VisitUnary((UnaryExpression)expression);

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
                    return VisitBinary((BinaryExpression)expression);

                case ExpressionType.TypeIs:
                    return VisitTypeIs((TypeBinaryExpression)expression);

                case ExpressionType.Conditional:
                    return VisitConditional((ConditionalExpression)expression);

                case ExpressionType.Constant:
                    return VisitConstant((ConstantExpression)expression);

                case ExpressionType.Parameter:
                    return VisitParameter((ParameterExpression)expression);

                case ExpressionType.MemberAccess:
                    return VisitMemberAccess((MemberExpression)expression);

                case ExpressionType.Call:
                    return VisitMethodCall((MethodCallExpression)expression);

                case ExpressionType.Lambda:
                    return VisitLambda((LambdaExpression)expression);

                case ExpressionType.New:
                    return VisitNew((NewExpression)expression);

                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return VisitNewArray((NewArrayExpression)expression);

                case ExpressionType.Invoke:
                    return VisitInvocation((InvocationExpression)expression);

                case ExpressionType.MemberInit:
                    return VisitMemberInit((MemberInitExpression)expression);

                case ExpressionType.ListInit:
                    return VisitListInit((ListInitExpression)expression);

                default:
                    throw new ArgumentException(string.Format("Unhandled expression type: '{0}'", expression.NodeType));
            }
        }

        protected virtual TResult VisitBinding(MemberBinding binding) {
            switch(binding.BindingType) {
                case MemberBindingType.Assignment:
                    return VisitMemberAssignment((MemberAssignment)binding);

                case MemberBindingType.MemberBinding:
                    return VisitMemberMemberBinding((MemberMemberBinding)binding);

                case MemberBindingType.ListBinding:
                    return VisitMemberListBinding((MemberListBinding)binding);

                default:
                    throw new ArgumentException(string.Format("Unhandled binding type '{0}'", binding.BindingType));
            }
        }

        protected abstract TResult VisitElementInitializer(ElementInit initializer);
        protected abstract TResult VisitUnary(UnaryExpression unary);
        protected abstract TResult VisitBinary(BinaryExpression binary);
        protected abstract TResult VisitTypeIs(TypeBinaryExpression type);
        protected abstract TResult VisitConstant(ConstantExpression constant);
        protected abstract TResult VisitConditional(ConditionalExpression conditional);
        protected abstract TResult VisitParameter(ParameterExpression parameter);
        protected abstract TResult VisitMemberAccess(MemberExpression member);
        protected abstract TResult VisitMethodCall(MethodCallExpression methodCall);
        protected abstract TResult VisitList<T>(ReadOnlyCollection<T> list, Action<T> visitor);
        protected abstract TResult VisitExpressionList<TExp>(ReadOnlyCollection<TExp> list) where TExp : Expression;
        protected abstract TResult VisitMemberAssignment(MemberAssignment assignment);
        protected abstract TResult VisitMemberMemberBinding(MemberMemberBinding binding);
        protected abstract TResult VisitMemberListBinding(MemberListBinding binding);
        protected abstract TResult VisitBindingList<TBinding>(ReadOnlyCollection<TBinding> list) where TBinding : MemberBinding;
        protected abstract TResult VisitElementInitializerList(ReadOnlyCollection<ElementInit> list);
        protected abstract TResult VisitLambda(LambdaExpression lambda);
        protected abstract TResult VisitNew(NewExpression nex);
        protected abstract TResult VisitMemberInit(MemberInitExpression init);
        protected abstract TResult VisitListInit(ListInitExpression init);
        protected abstract TResult VisitNewArray(NewArrayExpression newArray);
        protected abstract TResult VisitInvocation(InvocationExpression invocation);
    }
}




/*
        models.Where(dm => dm.Legs.First().Length > dm.Legs.Last().Length);

        Models->Dogs strategy would also provide for Model->Dog from its root

        Model->Dog would expand to rebase LegModels->Legs

        
    So idea is - as expressed before - to expose rebasing vectors from the root.
    Don't set them up for entire strategiser. 

    To find root in first place we need a visitor. But from then on, we must delegate to our RootedRebaseStrategy, if in place.

    RootedRebaseStrategy will, in the first place, return us a RootedRebaseStrategy. Target param is a bit up in the air once more.


*/