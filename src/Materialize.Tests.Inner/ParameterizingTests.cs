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
            public int[] Array = new int[0];
            public Class Nested = null;
        }



        [Test]
        public void SimplePathing() {
            TestPathingFor<Class>(c => c.Int == 89 ? c.ToString() : null);            
        }


        [Test]
        public void PathingWithBinding() {
            TestPathingFor<Class>(c => new Class() { Int = 12, String = "blah" }.Int);
        }
        





        void TestPathingFor<T>(Expression<Func<T, object>> exSubject) 
        {
            exSubject.ForEach((ex, path) => {
                            var exViaAccessor = path.GetAccessor()(exSubject);
                            Assert.That(exViaAccessor, Is.EqualTo(ex));
                        });            
        }
        

    }
}
