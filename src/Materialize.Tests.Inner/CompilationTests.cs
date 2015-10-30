using Materialize.Reify2;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Params;
using Materialize.Reify2.Transitions;
using Materialize.SourceRegimes;
using Materialize.Tests.Inner.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    class CompilationTests
    {

        [Test]
        public void CompilesSource() 
        {
            var qy = Enumerable.Range(100, 40).AsQueryable();
            
            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)));

            var scheme = Schematizer.Schematize(trans, new ParamMapFake());
            var fnExec = scheme.Compile();

            var results = fnExec(qy.Provider, new ArgMapFake(qy));

            Assert.That(results, Is.InstanceOf<IQueryable<int>>());
            Assert.That((IQueryable<int>)results, Is.EquivalentTo(qy));
        }



        [Test]
        public void CompilesFetch() 
        {
            var qy = Enumerable.Range(100, 40).AsQueryable();

            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new FetchTransition(new TolerantRegime()));

            var scheme = Schematizer.Schematize(trans, new ParamMapFake());
            var fnExec = scheme.Compile();

            var results = fnExec(qy.Provider, new ArgMapFake(qy));

            Assert.That(results, Is.InstanceOf<IEnumerable<int>>());
            Assert.That((IEnumerable<int>)results, Is.EquivalentTo(qy));
        }



        [Test]
        public void CompilesServerProjection() {
            var qy = Enumerable.Range(100, 40).AsQueryable();

            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new ProjectionTransition(Lambda((int i) => i + i + 4F)),
                            new FetchTransition(new TolerantRegime()));

            var scheme = Schematizer.Schematize(trans, new ParamMapFake());
            var fnExec = scheme.Compile();

            var results = fnExec(qy.Provider, new ArgMapFake(qy));

            Assert.That(results, Is.InstanceOf<IEnumerable<float>>());
            Assert.That((IEnumerable<float>)results, Is.EquivalentTo(qy.Select(i => i + i + 0F))); //constant will be replaced with default if parameterization working!
        }



        [Test]
        public void CompilesClientProjection() 
        {
            var qy = Enumerable.Range(100, 40).AsQueryable();

            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new FetchTransition(new TolerantRegime()),
                            new ProjectionTransition(Lambda((int i) => i + i + 7F)));

            var scheme = Schematizer.Schematize(trans, new ParamMapFake());
            var fnExec = scheme.Compile();

            var argMap = Substitute.ForPartsOf<ArgMapFake>(qy); //slow, this!
            argMap.GetValueWith(Arg.Any<NodeAccessor>()).Returns(default(float));

            var results = fnExec(qy.Provider, argMap);

            Assert.That(results, Is.InstanceOf<IEnumerable<float>>());
            Assert.That((IEnumerable<float>)results, Is.EquivalentTo(qy.Select(i => i + i + 0F))); //constant will be replaced with default if parameterization working!
        }



        [Test]
        public void CompilesServerFilter() {
            var qy = Enumerable.Range(-50, 100).AsQueryable();

            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new FilterTransition(Lambda((int i) => i > 40)),
                            new FetchTransition(new TolerantRegime()));

            var scheme = Schematizer.Schematize(trans, new ParamMapFake());
            var fnExec = scheme.Compile();
            
            var results = fnExec(qy.Provider, new ArgMapFake(qy));

            Assert.That(results, Is.InstanceOf<IEnumerable<int>>());
            Assert.That((IEnumerable<int>)results, Is.EquivalentTo(qy.Where(i => i > 0))); //constant will be replaced with default if parameterization working!
        }


        [Test]
        public void CompilesClientFilter() {
            var qy = Enumerable.Range(-50, 100).AsQueryable();

            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new FetchTransition(new TolerantRegime()),
                            new FilterTransition(Lambda((int i) => i > 40)));

            var scheme = Schematizer.Schematize(trans, new ParamMapFake());
            var fnExec = scheme.Compile();
            
            var argMap = Substitute.ForPartsOf<ArgMapFake>(qy); //slow, this!
            argMap.GetValueWith(Arg.Any<NodeAccessor>()).Returns(default(int));

            var results = fnExec(qy.Provider, argMap);

            Assert.That(results, Is.InstanceOf<IEnumerable<int>>());
            Assert.That((IEnumerable<int>)results, Is.EquivalentTo(qy.Where(i => i > 0))); //constant will be replaced with default if parameterization working!
        }






        IEnumerable<ITransition> PrepTransitions(params ITransition[] transitions) 
        {
            var list = new LinkedList<ITransition>(transitions);

            var node = list.First;

            while(node != null) {
                node.Value.Site = node;
                node = node.Next;
            }

            return list;
        }



        LambdaExpression Lambda<TIn, TOut>(Expression<Func<TIn, TOut>> fn) {
            return fn;
        }



    }
}
