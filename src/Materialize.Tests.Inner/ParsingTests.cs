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
using Materialize.Reify2.Params;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    public class ParsingTests
    {
        ReifyContext _reifyContext;

        public ParsingTests() {
            var mapperWriterSource = new MapperSource(new MapStrategySourceFake());
            _reifyContext = new ReifyContext(null, null, mapperWriterSource, true);
        }


        ParseSubject GetSubject<TSourceElem>(Expression<Func<IQueryable<TSourceElem>, object>> exLambda) {
            return new ParseSubject(
                            exLambda.Body, 
                            //ArgMap.Create(new ParamMap(Enumerable.Empty<ParamMap.Param>()), exLambda), 
                            _reifyContext);
        }







        [Test]
        public void SourceIsParsedToSourceStep() 
        {
            var subject = GetSubject<int>(s => s);

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(1));
            Assert.That(steps[0].TransitionType, Is.EqualTo(TransitionType.Source));
        }


        [Test]
        public void MapAsIsParsedToProjectionsAndTransition() 
        {
            var subject = GetSubject<int>(s => s.MapAs<float>());

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(4));
            Assert.That(steps[0].TransitionType, Is.EqualTo(TransitionType.Source));
            Assert.That(steps[1].TransitionType, Is.EqualTo(TransitionType.Projector));
            Assert.That(steps[2].TransitionType, Is.EqualTo(TransitionType.RegimeBoundary));
            Assert.That(steps[3].TransitionType, Is.EqualTo(TransitionType.Projector));
        }

        


        [Test]
        public void WhereIsParsedToFilterStep() 
        {
            var subject = GetSubject<int>(s => s.Where(i => true));

            var steps = Parser.Parse(subject).ToArray();

            Assert.That(steps, Has.Length.EqualTo(2));
            Assert.That(steps[0].TransitionType, Is.EqualTo(TransitionType.Source));
            Assert.That(steps[1].TransitionType, Is.EqualTo(TransitionType.Filter));
        }
        

    }
}
