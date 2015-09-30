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

    partial class RebaseStrategizer 
        : CustomExpressionVisitor<IRebaseStrategy>
    {

        public IReadOnlyDictionary<Expression, IRebaseStrategy> RootStrategies { get; private set; }
        

        public RebaseStrategizer(
            Action<IRootStrategyRegistrar> fnRegister)
        {
            var dRootStrats = new Dictionary<Expression, IRebaseStrategy>();

            fnRegister(new RootStrategyRegistrar(dRootStrats));

            RootStrategies = dRootStrats;
        }
                      

        RebaseStrategizer SpawnStrategizer(
            Action<IRootStrategyRegistrar> fnRegister)
        {
            return new RebaseStrategizer(
                                    x => {
                                        foreach(var kv in RootStrategies) {
                                            x.AddRootStrategy(kv.Key, kv.Value);
                                        }

                                        fnRegister(x);
                                    });
        }
            
                    

        public IRebaseStrategy Strategize(Expression exSubject) {
            return Visit(exSubject);
        }



        protected override IRebaseStrategy Visit(Expression expression) {
            IRebaseStrategy strategy = null;

            if(RootStrategies.TryGetValue(expression, out strategy)) {
                return strategy;
            }

            return base.Visit(expression);
        }








        public interface IRootStrategyRegistrar
        {
            void AddRootStrategy(Expression exRoot, IRebaseStrategy strategy);
        }


        class RootStrategyRegistrar
            : IRootStrategyRegistrar
        {
            IDictionary<Expression, IRebaseStrategy> _dRootStrats;

            public RootStrategyRegistrar(IDictionary<Expression, IRebaseStrategy> dRootStrats) {
                _dRootStrats = dRootStrats;
            }

            public void AddRootStrategy(Expression exRoot, IRebaseStrategy strategy) {
                _dRootStrats[exRoot] = strategy;
            }
        }




                

        IRebaseStrategy PassiveStrategy(Type type) {
            return new PassiveRebaseStrategy(type);
        }
        
        
        IRebaseStrategy RootedStrategy<TExp>(IRebaseStrategy upstreamStrategy, Func<TExp, TExp> fnRebase)
            where TExp : Expression
        {
            return new RebaseStrategy<TExp>(upstreamStrategy, fnRebase);
        }


        IRebaseStrategy RootedStrategy<TExp>(TypeVector typeVector, IRebaseStrategy upstreamStrategy, Func<TExp, TExp> fnRebase)
            where TExp : Expression 
        {
            return new RebaseStrategy<TExp>(typeVector, upstreamStrategy, fnRebase);
        }



        IRebaseStrategy UnrootedStrategy<TExp>(TypeVector typeVector, Func<TExp, TExp> fnRebase)
            where TExp : Expression 
        {
            return new RebaseStrategy<TExp>(typeVector, null, fnRebase);
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
