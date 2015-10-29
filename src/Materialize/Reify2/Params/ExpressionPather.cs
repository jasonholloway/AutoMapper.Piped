using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

namespace Materialize.Reify2.Params
{

    internal class ExpressionPather : VoidExpressionVisitor
    {
        Action<Expression, Path> _fn;        
        Stack<Func<Expression, Expression>> _stAccessors;
                
        public ExpressionPather(Action<Expression, Path> fn) {
            _fn = fn;
            _stAccessors = new Stack<Func<Expression, Expression>>();
        }


        
        public class Path
        {
            IEnumerable<Func<Expression, Expression>> _subAccessors;

            public Path(IEnumerable<Func<Expression, Expression>> subAccessors) {
                _subAccessors = subAccessors;
            }

            public Func<Expression, Expression> GetAccessor() {
                var rSubAccessors = _subAccessors.Reverse().ToArray();
                return (ex) => rSubAccessors.Aggregate(ex, (e, fn) => fn(e));
            }
        }





        



        public void Run(Expression ex) {
            base.Visit(ex);
        }



        protected override void Visit(Expression expression) {
            _fn(expression, new Path(_stAccessors));
            base.Visit(expression);
        }




        void Delve<TExp>(TExp node, Func<TExp, Expression> fnPath) where TExp : Expression 
        {
            _stAccessors.Push(x => fnPath((TExp)x));
            
            Visit(fnPath(node));
            
            _stAccessors.Pop();
        }



        protected override void VisitBinary(BinaryExpression binary) {
            Delve(binary, b => b.Conversion);
            Delve(binary, b => b.Left);
            Delve(binary, b => b.Right);
        }


        protected override void VisitBindingList<TBinding>(ReadOnlyCollection<TBinding> list) {
            base.VisitBindingList<TBinding>(list);
        }

        protected override void VisitConditional(ConditionalExpression conditional) {
            Delve(conditional, x => x.IfFalse);
            Delve(conditional, x => x.IfTrue);
            Delve(conditional, x => x.Test);
        }

        protected override void VisitConstant(ConstantExpression constant) {
            //...
        }

        protected override void VisitElementInitializer(ElementInit initializer) {
            throw new NotImplementedException();
        }

        protected override void VisitElementInitializerList(ReadOnlyCollection<ElementInit> list) {
            throw new NotImplementedException();
            base.VisitElementInitializerList(list);
        }

        protected override void VisitExpressionList<TExp>(ReadOnlyCollection<TExp> list) {
            throw new NotImplementedException();
            base.VisitExpressionList<TExp>(list);
        }

        protected override void VisitInvocation(InvocationExpression invocation) {
            throw new NotImplementedException();
        }

        protected override void VisitLambda(LambdaExpression lambda) {
            Delve(lambda, l => l.Body);

            //AND ARGS!!!?
        }


        void VisitList<T>(IList<T> list) {
            var length = list.Count();

            for(int i = 0; i < length; i++) {
                //Visit()
                //list[i]
            }
        }



        protected override void VisitList<T>(ReadOnlyCollection<T> list, Action<T> visitor) {
            throw new NotImplementedException();
            base.VisitList<T>(list, visitor);
        }

        protected override void VisitListInit(ListInitExpression init) {
            throw new NotImplementedException();
            base.VisitListInit(init);
        }

        protected override void VisitMemberAccess(MemberExpression member) {
            Delve(member, m => m.Expression);
        }

        protected override void VisitMemberAssignment(MemberAssignment assignment) {
            throw new NotImplementedException();
            base.VisitMemberAssignment(assignment);
        }

        protected override void VisitMemberInit(MemberInitExpression init) {
            throw new NotImplementedException();
            base.VisitMemberInit(init);
        }

        protected override void VisitMemberListBinding(MemberListBinding binding) {
            throw new NotImplementedException();
            base.VisitMemberListBinding(binding);
        }

        protected override void VisitMemberMemberBinding(MemberMemberBinding binding) {
            throw new NotImplementedException();
            base.VisitMemberMemberBinding(binding);
        }

        protected override void VisitMethodCall(MethodCallExpression methodCall) {
            throw new NotImplementedException();
            base.VisitMethodCall(methodCall);
        }

        protected override void VisitNew(NewExpression nex) {
            throw new NotImplementedException();
            base.VisitNew(nex);
        }

        protected override void VisitNewArray(NewArrayExpression newArray) {
            throw new NotImplementedException();
            base.VisitNewArray(newArray);
        }

        protected override void VisitParameter(ParameterExpression parameter) {
            //...
        }

        protected override void VisitTypeIs(TypeBinaryExpression type) {
            throw new NotImplementedException();
            base.VisitTypeIs(type);
        }

        protected override void VisitUnary(UnaryExpression unary) {
            Delve(unary, u => u.Operand);
        }
    }
}
