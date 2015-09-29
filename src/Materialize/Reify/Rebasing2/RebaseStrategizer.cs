using Materialize.ExpressionComparison;
using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using Materialize.Reify.Parsing;

namespace Materialize.Reify.Rebasing2
{
    delegate IRebaseStrategy RootRebaseStrategyProvider(TypeVector typeVector, ParameterExpression exRebasedRoot);
    


    partial class RebaseStrategizer 
        : CustomExpressionVisitor<IRebaseStrategy>
    {
        RootRebaseStrategyProvider _rootStrategyProvider;
        IDictionary<ParameterExpression, ParameterExpression> _dRootVectors;
       

        public RebaseStrategizer(
            RootRebaseStrategyProvider rootStrategyProvider,
            params RootVector[] rootVectors) 
        {
            _rootStrategyProvider = rootStrategyProvider;

            _dRootVectors = rootVectors
                                .ToDictionary(v => v.OrigRoot, v => v.RebasedRoot);
        }
                      

        private RebaseStrategizer SpawnChildStrategizer(
            RootRebaseStrategyProvider rootStrategyProvider,
            params RootVector[] rootVectors) 
        {
            var child = new RebaseStrategizer(
                                (tv, r) => rootStrategyProvider(tv, r) 
                                                ?? this._rootStrategyProvider(tv, r));

            child._dRootVectors = new Dictionary<ParameterExpression, ParameterExpression>(this._dRootVectors);

            foreach(var rootVector in rootVectors) {
                child._dRootVectors[rootVector.OrigRoot] = rootVector.RebasedRoot;
            }

            return child;
        }
                        

        public IRebaseStrategy Strategize(Expression exSubject) {
            return Visit(exSubject);
        }
        
                        



        private IRebaseStrategy PassiveStrategy(Type type) {
            return new PassiveRebaseStrategy(type);
        }
        
        
        private IRebaseStrategy<TExp> Strategy<TExp>(TypeVector typeVector, Func<TExp, TExp> fnRebase)
            where TExp : Expression 
        {
            return new RebaseStrategy<TExp>(typeVector, /*null,*/ fnRebase);
        }




        class RootVectorsAdaptor : IRootVectors
        {
            IDictionary<ParameterExpression, ParameterExpression> _dRootVectors;

            public RootVectorsAdaptor(IDictionary<ParameterExpression, ParameterExpression> dRootVectors) {
                _dRootVectors = dRootVectors;
            }

            public void AddRootVector(ParameterExpression exOriginal, ParameterExpression exRebased) {
                _dRootVectors[exOriginal] = exRebased;
            }
        }

        public interface IRootVectors
        {
            void AddRootVector(ParameterExpression exOriginal, ParameterExpression exRebased);
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
