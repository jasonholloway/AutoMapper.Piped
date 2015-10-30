using Materialize.Reify2;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Transitions;
using Materialize.SourceRegimes;
using Materialize.Tests.Inner.Fakes;
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
            
            var trans = ArrangeTrans(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)));

            var scheme = Schematizer.Schematize(trans);
            var fnExec = scheme.Compile();

            var results = fnExec(new ArgMapFake(qy));

            Assert.That(results, Is.TypeOf<IQueryable<int>>());
            Assert.That((IQueryable<int>)results, Is.EquivalentTo(qy));
        }



        [Test]
        public void CompilesFetch() {
            var qy = Enumerable.Range(100, 40).AsQueryable();

            var trans = ArrangeTrans(
                            new SourceTransition(new TolerantRegime(), Expression.Constant(qy)),
                            new FetchTransition(new TolerantRegime()));

            var scheme = Schematizer.Schematize(trans);
            var fnExec = scheme.Compile();

            var results = fnExec(new ArgMapFake(qy));

            Assert.That(results, Is.TypeOf<IEnumerable<int>>());
            Assert.That(results, Is.Not.TypeOf<IQueryable>());
            Assert.That((IEnumerable<int>)results, Is.EquivalentTo(qy));
        }






        ITransition ArrangeTrans(params ITransition[] transitions) {
            var list = new LinkedList<ITransition>(transitions);

            var node = list.First;

            while(node != null) {
                node.Value.Site = node;
                node = node.Next;
            }

            return list.FirstOrDefault();
        }




    }
}
