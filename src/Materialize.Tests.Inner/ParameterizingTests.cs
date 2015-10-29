using Materialize.Reify2.Params;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    public class ParameterizingTests
    {


        class Class
        {
            public int Int = 99;
            public string String = "hello";
        }



        [Test]
        public void SimplePathing() {
            TestPathingFor<Class>(c => c.Int == 89);            
        }


        [Test]
        public void PathingWithBinding() {
            TestPathingFor<Class>(c => new Class() { Int = 12, String = "blah" });
        }








        void TestPathingFor<T>(Expression<Func<T, object>> exSubject) 
        {
            var pather = new ExpressionPather((ex, p) => {
                var exViaPather = p.GetAccessor()(exSubject);
                Assert.That(exViaPather, Is.EqualTo(ex));
            });

            pather.Run(exSubject);
        }
        

    }
}
