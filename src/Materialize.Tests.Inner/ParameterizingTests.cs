using Materialize.Reify2.Params;
using Materialize.Expressions;
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
        


        //[Test]
        //public void ConstantsParameterized() 
        //{
        //    var ex = GetExpression<Class>(c => new Class() { Int = 999 } != null 
        //                                                ? "HELLO!" 
        //                                                : new string(new char[] { 'b', 'a', 'h' }));
            

        //    var parameterized = Parameterizer.Parameterize(ex);
            
        //    Assert.That(
        //        parameterized.Expression.AsEnumerable().OfType<ConstantExpression>().Any(), Is.False);

        //    Assert.That(
        //        parameterized.Map.CanonicalExpressions.Select(p => p.Type), 
        //        Is.EquivalentTo(ex.AsEnumerable().OfType<ConstantExpression>().Select(c => c.Type)));            
        //}


        //[Test]
        //public void ParameterizedAccessorsWork() 
        //{
        //    var ex = GetExpression<Class>(c => new Class() { Int = 999 } != null
        //                                                ? "HELLO!"
        //                                                : new string(new char[] { 'b', 'a', 'h' }));

        //    var parameterized = Parameterizer.Parameterize(ex);

        //    var accessors = parameterized.Map.CanonicalExpressions.Select(p => parameterized.Map.TryGetAccessor(p));

        //    Assert.That(
        //        accessors.Select(a => ((ConstantExpression)a(ex)).Value),
        //        Is.EquivalentTo(ex.AsEnumerable().OfType<ConstantExpression>().Select(c => c.Value)));            
        //}





        LambdaExpression GetExpression<T>(Expression<Func<T, object>> fn) {
            return fn;
        }
        

        void TestPathingFor<T>(Expression<Func<T, object>> exSubject) 
        {
            exSubject.ForEach((ex, path) => {
                            var exViaAccessor = path.BuildAccessor()(exSubject);
                            Assert.That(exViaAccessor, Is.EqualTo(ex));
                        });            
        }
        

    }
}
