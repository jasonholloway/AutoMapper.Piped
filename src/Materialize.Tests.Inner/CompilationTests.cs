using Materialize.Reify2;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Parameterize;
using Materialize.Reify2.Transitions;
using Materialize.SequenceMethods;
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

            var paramMap = Substitute.For<ParamMapFake>();
            paramMap.TryGetAccessor(Arg.Any<Expression>()).Returns((NodeAccessor)null);

            var scheme = Schematizer.Schematize(trans, paramMap);
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

            var paramMap = Substitute.For<ParamMapFake>();
            paramMap.TryGetAccessor(Arg.Any<Expression>()).Returns(null, e => e);

            var scheme = Schematizer.Schematize(trans, paramMap);
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

            var paramMap = Substitute.For<ParamMapFake>();
            paramMap.TryGetAccessor(Arg.Any<Expression>()).Returns(null, ex => ex);
            
            var scheme = Schematizer.Schematize(trans, paramMap);
            var fnExec = scheme.Compile();

            var argMap = Substitute.ForPartsOf<ArgMapFake>(qy); //slow, this!
            argMap.GetValueWith(Arg.Any<NodeAccessor>()).Returns(5F);

            var results = fnExec(qy.Provider, argMap);

            Assert.That(results, Is.InstanceOf<IEnumerable<float>>());
            Assert.That((IEnumerable<float>)results, Is.EquivalentTo(qy.Select(i => i + i + 5F))); //constant will be replaced with default if parameterization working!
        }



        [Test]
        public void CompilesServerFilter() {
            var qy = Enumerable.Range(-50, 100).AsQueryable();

            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new FilterTransition(Lambda((int i) => i > 40)),
                            new FetchTransition(new TolerantRegime()));

            var paramMap = Substitute.ForPartsOf<ParamMapFake>();
            paramMap.TryGetAccessor(Arg.Any<Expression>()).Returns(null, e => e);

            var scheme = Schematizer.Schematize(trans, paramMap);
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

            var paramMap = Substitute.For<ParamMapFake>();
            paramMap.TryGetAccessor(Arg.Any<Expression>()).Returns(null, ex => ex);

            var scheme = Schematizer.Schematize(trans, paramMap);
            var fnExec = scheme.Compile();
            
            var argMap = Substitute.ForPartsOf<ArgMapFake>(qy); //slow, this!
            argMap.GetValueWith(Arg.Any<NodeAccessor>()).Returns(default(int));

            var results = fnExec(qy.Provider, argMap);

            Assert.That(results, Is.InstanceOf<IEnumerable<int>>());
            Assert.That((IEnumerable<int>)results, Is.EquivalentTo(qy.Where(i => i > 0))); //constant will be replaced with default if parameterization working!
        }






        [Test]
        public void CompilesServerPartitions() {
            var qy = Enumerable.Range(-50, 100).AsQueryable();

            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new PartitionTransition(PartitionType.Skip, Expression.Constant(10)),
                            new PartitionTransition(PartitionType.Take, Expression.Constant(10)),
                            new FetchTransition(new TolerantRegime()));

            var paramMap = Substitute.For<ParamMapFake>();
            paramMap.TryGetAccessor(Arg.Any<Expression>()).Returns(null, e => e, e => e);

            var scheme = Schematizer.Schematize(trans, paramMap);
            var fnExec = scheme.Compile();

            var argMap = Substitute.ForPartsOf<ArgMapFake>(qy); //slow, this!
            argMap.GetIncidentalFor(Arg.Is<Expression>(x => x.Type == typeof(int)))
                        .Returns(Expression.Constant(5));

            var results = fnExec(qy.Provider, argMap);

            Assert.That(results, Is.InstanceOf<IEnumerable<int>>());
            Assert.That((IEnumerable<int>)results, Is.EquivalentTo(qy.Skip(5).Take(5)));
        }



        [Test]
        public void CompilesClientPartitions() {
            var qy = Enumerable.Range(-50, 100).AsQueryable();

            var trans = PrepTransitions(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new FetchTransition(new TolerantRegime()),
                            new PartitionTransition(PartitionType.Skip, Expression.Constant(10)),
                            new PartitionTransition(PartitionType.Take, Expression.Constant(10)));

            var paramMap = Substitute.For<ParamMapFake>();
            paramMap.TryGetAccessor(Arg.Any<Expression>()).Returns(null, e => e, e => e);

            var scheme = Schematizer.Schematize(trans, paramMap);
            var fnExec = scheme.Compile();

            var argMap = Substitute.ForPartsOf<ArgMapFake>(qy);            
            argMap.GetValueWith(Arg.Any<NodeAccessor>())
                        .Returns(5);
            
            var results = fnExec(qy.Provider, argMap);

            Assert.That(results, Is.InstanceOf<IEnumerable<int>>());
            Assert.That((IEnumerable<int>)results, Is.EquivalentTo(qy.Skip(5).Take(5)));
        }



        //want to avoid manually listing every testable compilation...
        //cos there will be one for every queryable method...
        //only thing I can think is to test the entire pipeline WITHOUT MapAs
        //and WITHOUT optimizations (or maybe with...)
        //templated tests could try passing each Queryable method through the pipeline,
        //and would test the result.









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
