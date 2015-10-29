using Materialize.Expressions;
using Materialize.Reify2;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Operations;
using Materialize.Reify2.Parsing2;
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
        public void SourceStepWrittenAsBaseQuery() 
        {
            var steps = new IOperation[] {
                            new SourceOp<int>(null)
                            };

            var exBase = Expression.Parameter(typeof(IQueryable<int>));

            var exQuery = QueryWriter.Write(exBase, steps);

            Assert.That(exQuery, Is.EqualTo(exBase));            
        }



        [Test]
        public void FilterStepWritten() 
        {
            var exLambda = GetLambda<IQueryable<int>>(q => q.Where(i => i % 2 == 1));
            
            var steps = new IOperation[] {
                                new SourceOp<int>(null),
                                new FilterOp<int>(i => i % 2 == 1)
                                };

            var exQuery = QueryWriter.Write(
                                        exLambda.Parameters.Single(),
                                        steps);

            Assert.That(exQuery.IsFormallyEquivalentTo(exLambda.Body));
        }


        [Test]
        public void ProjectorStepWritten() 
        {
            var exLambda = GetLambda<IQueryable<int>>(q => q.Select(i => 15F * i));

            var steps = new IOperation[] {
                                new SourceOp<int>(null),
                                new ProjectorOp<int, float>(i => 15F * i)
                                };

            var exQuery = QueryWriter.Write(
                                        exLambda.Parameters.Single(),
                                        steps);

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
