using Materialize.Expressions;
using Materialize.Reify2;
using Materialize.Reify2.Elements;
using Materialize.Reify2.Parsing2;
using Materialize.Reify2.QueryWriting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    public class QueryWritingTests
    {
        
        [Test]
        public void SourceElementWrittenAsBaseQuery() 
        {
            var elements = new IElement[] {
                                    new SourceElement<int>(null)
                                    };

            var exBase = Expression.Parameter(typeof(IQueryable<int>));

            var exQuery = QueryWriter.Write(exBase, elements);

            Assert.That(exQuery, Is.EqualTo(exBase));            
        }



        [Test]
        public void FilterElementWritten() 
        {
            var exLambda = GetLambda<IQueryable<int>>(q => q.Where(i => i % 2 == 1));
            
            var elements = new IElement[] {
                                    new SourceElement<int>(null),
                                    new FilterElement<int>(i => i % 2 == 1)
                                    };

            var exQuery = QueryWriter.Write(
                                        exLambda.Parameters.Single(),
                                        elements);

            Assert.That(exQuery.IsFormallyEquivalentTo(exLambda.Body));
        }


        [Test]
        public void ProjectorElementWritten() 
        {
            var exLambda = GetLambda<IQueryable<int>>(q => q.Select(i => 15F * i));

            var elements = new IElement[] {
                                    new SourceElement<int>(null),
                                    new ProjectorElement<int, float>(i => 15F * i)
                                    };

            var exQuery = QueryWriter.Write(
                                        exLambda.Parameters.Single(),
                                        elements);

            Assert.That(exQuery.IsFormallyEquivalentTo(exLambda.Body));
        }










        LambdaExpression GetLambda<TIn>(Expression<Func<TIn, object>> exFn) {
            return exFn;
        }


        ParseSubject GetSubject<TSourceElem>(Expression<Func<IQueryable<TSourceElem>, object>> exLambda) 
        {
            var context = new ReifyContext(null, null, null, false);
            return new ParseSubject(exLambda.Body, exLambda.Parameters.Single(), context);
        }
        

    }
}
