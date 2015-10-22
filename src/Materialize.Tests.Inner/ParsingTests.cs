using Materialize.Reify2;
using Materialize.Reify2.Elements;
using Materialize.Reify2.Parsing2;
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
        
        [Test]
        public void SourceIsParsedToElement() 
        {
            var subject = GetSubject<int>(s => s);

            var elements = Parser.Parse(subject).ToArray();

            Assert.That(elements, Has.Length.EqualTo(1));
            Assert.That(elements[0].ElementType, Is.EqualTo(ElementType.Source));
            Assert.That(elements.Last().OutType, Is.EqualTo(subject.SubjectExp.Type));
        }


        [Test]
        public void MapAsIsParsedToTwoElements() 
        {
            var subject = GetSubject<int>(s => s.MapAs<float>());

            var elements = Parser.Parse(subject).ToArray();

            Assert.That(elements, Has.Length.EqualTo(3));
            Assert.That(elements[0].ElementType, Is.EqualTo(ElementType.Source));
            Assert.That(elements[1].ElementType, Is.EqualTo(ElementType.Projector | ElementType.RegimeBoundary));
            Assert.That(elements[2].ElementType, Is.EqualTo(ElementType.Projector));
            Assert.That(elements.Last().OutType, Is.EqualTo(subject.SubjectExp.Type));
        }







        ParseSubject GetSubject<TSourceElem>(Expression<Func<IQueryable<TSourceElem>, object>> exLambda) 
        {
            var context = new ReifyContext(null, null, false);
            return new ParseSubject(exLambda.Body, exLambda.Parameters.Single(), context);
        }


        LambdaExpression GetLambda<TSource>(Expression<Func<TSource, object>> exLambda) {
            return exLambda;
        }



    }
}
