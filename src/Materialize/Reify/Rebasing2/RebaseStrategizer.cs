using Materialize.ExpressionComparison;
using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer : CustomExpressionVisitor<IRebaseStrategy>
    {
        public IMemberRebaseStrategizer MemberStrategizer { get; private set; }
        public IReadOnlyDictionary<ParameterExpression, ParameterExpression> Roots { get; private set; }


        public RebaseStrategizer(
            IMemberRebaseStrategizer memberStrategizer, 
            Action<IRoots> fnAddRoots) 
        {
            MemberStrategizer = memberStrategizer;

            var dRoots = new Dictionary<ParameterExpression, ParameterExpression>();

            fnAddRoots(new RootsAdaptor(dRoots));

            if(!dRoots.Any()) {
                throw new InvalidOperationException("No roots have been added to RebaseStrategizer!");
            }

            Roots = dRoots;
        }


        private RebaseStrategizer(
            RebaseStrategizer parent,
            Action<IRoots> fnAddRoots) 
        {
            MemberStrategizer = parent.MemberStrategizer;

            var dRoots = new Dictionary<ParameterExpression, ParameterExpression>(
                            (IDictionary<ParameterExpression, ParameterExpression>)parent.Roots);

            fnAddRoots(new RootsAdaptor(dRoots));

            Roots = dRoots;
        }




        public IRebaseStrategy GetStrategy(Expression exSubject) 
        {
            return Visit(exSubject);
        }
        

        private IRebaseStrategy PassiveStrategy(Type type) {
            return new RebaseStrategy<Expression>(new TypeVector(type, type));
        }
        
                
        private IRebaseStrategy<TExp> RootedStrategy<TExp>(TypeVector typeVector, Func<TExp, TExp> fnRebase)
            where TExp : Expression 
        {
            return new RebaseStrategy<TExp>(typeVector, Roots, fnRebase);
        }

        
        private IRebaseStrategy<TExp> ActiveStrategy<TExp>(TypeVector typeVector, Func<TExp, TExp> fnRebase)
            where TExp : Expression 
        {
            return new RebaseStrategy<TExp>(typeVector, null, fnRebase);
        }




        class RootsAdaptor : IRoots
        {
            IDictionary<ParameterExpression, ParameterExpression> _dRoots;

            public RootsAdaptor(IDictionary<ParameterExpression, ParameterExpression> dRoots) {
                _dRoots = dRoots;
            }

            public void AddRoot(ParameterExpression exSubject, ParameterExpression exRebased) {
                _dRoots[exSubject] = exRebased;
            }
        }

        public interface IRoots
        {
            void AddRoot(ParameterExpression exSubject, ParameterExpression exRebased);
        }





        //------------------------------------------------------------------------------------


        protected override IRebaseStrategy VisitElementInitializer(ElementInit initializer) {
            throw new NotImplementedException();
        }
        

        protected override IRebaseStrategy VisitTypeIs(TypeBinaryExpression type) {
            throw new NotImplementedException();
        }
        

        protected override IRebaseStrategy VisitConditional(ConditionalExpression conditional) {
            throw new NotImplementedException();
        }


        protected override IRebaseStrategy VisitList<T>(ReadOnlyCollection<T> list, Action<T> visitor) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitExpressionList<TExp>(ReadOnlyCollection<TExp> list) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitMemberAssignment(MemberAssignment assignment) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitMemberMemberBinding(MemberMemberBinding binding) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitMemberListBinding(MemberListBinding binding) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitBindingList<TBinding>(ReadOnlyCollection<TBinding> list) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitElementInitializerList(ReadOnlyCollection<ElementInit> list) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitNew(NewExpression nex) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitMemberInit(MemberInitExpression init) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitListInit(ListInitExpression init) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitNewArray(NewArrayExpression newArray) {
            throw new NotImplementedException();
        }

        protected override IRebaseStrategy VisitInvocation(InvocationExpression invocation) {
            throw new NotImplementedException();
        }
    }
}
