using Materialize.Reify2;
using Materialize.Reify2.Transitions;
using Materialize.Reify2.Mapping;
using Materialize.Reify2.Parsing2;
using Materialize.Tests.Inner.Fakes;
using Materialize.Types;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Expressions;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    public class ParsingTests
    {
        ReifyContext _ctx;

        public ParsingTests() {
            var mapperSource = new MapperSource(new MapStrategySourceFake());
            _ctx = new ReifyContext(null, null, mapperSource, true);
        }


        ParseSubject GetSubject<TElem>(Expression<Func<IQueryable<TElem>, object>> exLambda) {
            return new ParseSubject(
                            exLambda.Body.Replace(
                                            exLambda.Parameters.Single(), 
                                            Expression.Constant(null, typeof(IQueryable<TElem>))), 
                            _ctx);
        }

                

        [Test]
        public void ParsesSource() 
        {
            var subject = GetSubject<int>(q => q);

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(1));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
        }


        [Test]
        public void ParsesMapAs() 
        {
            var subject = GetSubject<int>(q => q.MapAs<float>());

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(4));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ProjectionTransition>());
            Assert.That(steps[2], Is.InstanceOf<FetchTransition>());
            Assert.That(steps[3], Is.InstanceOf<ProjectionTransition>());
        }
        

        [Test]
        public void ParsesWhere() 
        {
            var subject = GetSubject<int>(q => q.Where(i => true));

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<FilterTransition>());
        }


        [Test]
        public void ParsesSelect() {
            var subject = GetSubject<int>(q => q.Select(i => 13));

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ProjectionTransition>());
        }


        [Test]
        public void ParsesTake() {
            var subject = GetSubject<int>(q => q.Take(13));

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<PartitionTransition>());
            Assert.That(((PartitionTransition)steps[1]).PartitionType, Is.EqualTo(PartitionType.Take));
        }


        [Test]
        public void ParsesSkip() {
            var subject = GetSubject<int>(q => q.Skip(13));

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<PartitionTransition>());
            Assert.That(((PartitionTransition)steps[1]).PartitionType, Is.EqualTo(PartitionType.Skip));
        }

    }
}
