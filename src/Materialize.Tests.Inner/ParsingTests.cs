using Materialize.Reify2;
using Materialize.Reify2.Elements;
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

namespace Materialize.Tests.Inner
{
    [TestFixture]
    public class ParsingTests
    {
        ReifyContext _reifyContext;

        public ParsingTests() {
            var mapperWriterSource = new MapperWriterSource(new MapStrategySourceFake());
            _reifyContext = new ReifyContext(null, null, mapperWriterSource, true);
        }


        ParseSubject GetSubject<TSourceElem>(Expression<Func<IQueryable<TSourceElem>, object>> exLambda) {
            return new ParseSubject(exLambda.Body, exLambda.Parameters.Single(), _reifyContext);
        }







        [Test]
        public void SourceIsParsedToSourceElement() 
        {
            var subject = GetSubject<int>(s => s);

            var elements = Parser.Parse(subject).ToArray();

            Assert.That(elements, Has.Length.EqualTo(1));
            Assert.That(elements[0].ElementType, Is.EqualTo(ElementType.Source));
            Assert.That(elements.Last().OutType, Is.EqualTo(subject.SubjectExp.Type));
        }


        [Test]
        public void MapAsIsParsedToTwoProjectorElements() 
        {
            var subject = GetSubject<int>(s => s.MapAs<float>());

            var elements = Parser.Parse(subject).ToArray();

            Assert.That(elements, Has.Length.EqualTo(3));
            Assert.That(elements[0].ElementType, Is.EqualTo(ElementType.Source));
            Assert.That(elements[1].ElementType, Is.EqualTo(ElementType.Projector | ElementType.RegimeBoundary));
            Assert.That(elements[2].ElementType, Is.EqualTo(ElementType.Projector));
            Assert.That(elements.Last().OutType, Is.EqualTo(subject.SubjectExp.Type));
        }

        


        [Test]
        public void WhereIsParsedToFilterElement() 
        {
            var subject = GetSubject<int>(s => s.Where(i => true));

            var elements = Parser.Parse(subject).ToArray();

            Assert.That(elements, Has.Length.EqualTo(2));
            Assert.That(elements[0].ElementType, Is.EqualTo(ElementType.Source));
            Assert.That(elements[1].ElementType, Is.EqualTo(ElementType.Filter));
            Assert.That(elements.Last().OutType, Is.EqualTo(subject.SubjectExp.Type));
        }
        

    }
}
