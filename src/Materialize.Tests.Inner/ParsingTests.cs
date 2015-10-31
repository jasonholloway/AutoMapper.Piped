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


        ParseSubject GetSubject<TElem>(Expression<Func<IQueryable<TElem>, object>> exLambda) 
        {
            var ex = exLambda.Body;

            if(ex.NodeType == ExpressionType.Convert
                && ((UnaryExpression)ex).Type == typeof(object)) 
                {
                    ex = ((UnaryExpression)ex).Operand;
                }

            ex = ex.Replace(
                    exLambda.Parameters.Single(),
                    Expression.Constant(null, typeof(IQueryable<TElem>)));

            return new ParseSubject(ex, _ctx);
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

            var partTrans = (PartitionTransition)steps[1];
            Assert.That(partTrans.PartitionType, Is.EqualTo(PartitionType.Take));
        }


        [Test]
        public void ParsesSkip() {
            var subject = GetSubject<int>(q => q.Skip(13));

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<PartitionTransition>());

            var partTrans = (PartitionTransition)steps[1];
            Assert.That(partTrans.PartitionType, Is.EqualTo(PartitionType.Skip));
        }



        [Test]
        public void ParsesFirst() {
            var subject = GetSubject<int>(q => q.First());

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());            
            Assert.That(steps[1], Is.InstanceOf<ElementTransition>());

            var elemTrans = (ElementTransition)steps[1];
            Assert.That(elemTrans.ElementTransitionType, Is.EqualTo(ElementTransitionType.First));
            Assert.That(elemTrans.ReturnsDefault, Is.False);
        }


        [Test]
        public void ParsesLast() {
            var subject = GetSubject<int>(q => q.Last());

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ElementTransition>());

            var elemTrans = (ElementTransition)steps[1];
            Assert.That(elemTrans.ElementTransitionType, Is.EqualTo(ElementTransitionType.Last));
            Assert.That(elemTrans.ReturnsDefault, Is.False);
        }


        [Test]
        public void ParsesSingle() {
            var subject = GetSubject<int>(q => q.Single());

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ElementTransition>());

            var elemTrans = (ElementTransition)steps[1];
            Assert.That(elemTrans.ElementTransitionType, Is.EqualTo(ElementTransitionType.Single));
            Assert.That(elemTrans.ReturnsDefault, Is.False);
        }


        [Test]
        public void ParsesElementAt() {
            var subject = GetSubject<int>(q => q.ElementAt(14));

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ElementTransition>());

            var elemTrans = (ElementTransition)steps[1];
            Assert.That(elemTrans.ElementTransitionType, Is.EqualTo(ElementTransitionType.ElementAt));
            Assert.That(elemTrans.ReturnsDefault, Is.False);
            Assert.That(elemTrans.IndexExpression is ConstantExpression);
            Assert.That(((ConstantExpression)elemTrans.IndexExpression).Value, Is.EqualTo(14));
        }


        [Test]
        public void ParsesFirstOrDefault() {
            var subject = GetSubject<int>(q => q.FirstOrDefault());

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ElementTransition>());

            var elemTrans = (ElementTransition)steps[1];
            Assert.That(elemTrans.ElementTransitionType, Is.EqualTo(ElementTransitionType.First));
            Assert.That(elemTrans.ReturnsDefault, Is.True);
        }


        [Test]
        public void ParsesLastOrDefault() {
            var subject = GetSubject<int>(q => q.LastOrDefault());

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ElementTransition>());

            var elemTrans = (ElementTransition)steps[1];
            Assert.That(elemTrans.ElementTransitionType, Is.EqualTo(ElementTransitionType.Last));
            Assert.That(elemTrans.ReturnsDefault, Is.True);
        }


        [Test]
        public void ParsesSingleOrDefault() {
            var subject = GetSubject<int>(q => q.SingleOrDefault());

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ElementTransition>());

            var elemTrans = (ElementTransition)steps[1];
            Assert.That(elemTrans.ElementTransitionType, Is.EqualTo(ElementTransitionType.Single));
            Assert.That(elemTrans.ReturnsDefault, Is.True);
        }


        [Test]
        public void ParsesElementAtOrDefault() {
            var subject = GetSubject<int>(q => q.ElementAtOrDefault(14));

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0], Is.InstanceOf<SourceTransition>());
            Assert.That(steps[1], Is.InstanceOf<ElementTransition>());

            var elemTrans = (ElementTransition)steps[1];
            Assert.That(elemTrans.ElementTransitionType, Is.EqualTo(ElementTransitionType.ElementAt));
            Assert.That(elemTrans.ReturnsDefault, Is.True);
            Assert.That(elemTrans.IndexExpression is ConstantExpression);
            Assert.That(((ConstantExpression)elemTrans.IndexExpression).Value, Is.EqualTo(14));
        }





    }
}
