using Materialize.ExpressionComparison;
using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

namespace Materialize.Reify.Rebasing2
{
    partial class Rebaser : CustomExpressionVisitor<Rebased>
    {
        public IMemberRebaser MemberRebaser { get; private set; }
        public IDictionary<ParameterExpression, ParameterExpression> Roots { get; private set; }


        public Rebaser(IMemberRebaser memberRebaser) {
            MemberRebaser = memberRebaser;
            Roots = new Dictionary<ParameterExpression, ParameterExpression>();
        }

        private Rebaser(Rebaser parent) {
            MemberRebaser = parent.MemberRebaser;
            Roots = new Dictionary<ParameterExpression, ParameterExpression>(parent.Roots);
        }


        public Expression Rebase(Expression exSubject) {
            return Visit(exSubject).Expression;
        }
        
        //------------------------------------------------------------------------------------


        protected override Rebased VisitElementInitializer(ElementInit initializer) {
            throw new NotImplementedException();
        }
        

        protected override Rebased VisitTypeIs(TypeBinaryExpression type) {
            throw new NotImplementedException();
        }
        

        protected override Rebased VisitConditional(ConditionalExpression conditional) {
            throw new NotImplementedException();
        }


        protected override Rebased VisitList<T>(ReadOnlyCollection<T> list, Action<T> visitor) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitExpressionList<TExp>(ReadOnlyCollection<TExp> list) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitMemberAssignment(MemberAssignment assignment) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitMemberMemberBinding(MemberMemberBinding binding) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitMemberListBinding(MemberListBinding binding) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitBindingList<TBinding>(ReadOnlyCollection<TBinding> list) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitElementInitializerList(ReadOnlyCollection<ElementInit> list) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitNew(NewExpression nex) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitMemberInit(MemberInitExpression init) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitListInit(ListInitExpression init) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitNewArray(NewArrayExpression newArray) {
            throw new NotImplementedException();
        }

        protected override Rebased VisitInvocation(InvocationExpression invocation) {
            throw new NotImplementedException();
        }
    }
}
