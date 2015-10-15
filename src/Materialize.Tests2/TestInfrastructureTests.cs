using Materialize.Tests.Infrastructure;
using NUnit.Framework;
using Should;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Tests2
{
    [TestFixture]
    class TestInfrastructureTests
    {        
        [Test]
        public void CanSnoopObjectQueries() {
            int snoopCount = 0;
            Expression snoopedExp = null;

            var qySource = Enumerable.Range(0, 200).AsQueryable();

            var qySnooped = qySource.Snoop(exp => {
                                            snoopCount++;
                                            snoopedExp = exp;
                                        })
                                       .Where(i => i % 2 == 1);

            var enSnooped = qySnooped.ToArray();

            var enSnoopFree = qySource.Where(i => i % 2 == 1)
                                    .ToArray();

            snoopCount.ShouldEqual(1);
            enSnooped.SequenceEqual(enSnoopFree).ShouldBeTrue();
            snoopedExp.ShouldEqual(qySnooped.Expression);
        }


        [Test]
        public void CanSnoopEFQueries() {
            using(var ctx = new Context()) {
                int snoopCount = 0;
                Expression snoopedExp = null;

                var qyDogs = ctx.Dogs;

                var qySnooped = qyDogs.Snoop(exp => {
                                                snoopCount++;
                                                snoopedExp = exp;
                                            })
                                           .Where(d => d.Name.Length > 5);

                var enSnooped = qySnooped.ToArray();

                var enSnoopFree = qyDogs.Where(d => d.Name.Length > 5)
                                        .ToArray();

                snoopCount.ShouldEqual(1);
                enSnooped.SequenceEqual(enSnoopFree).ShouldBeTrue();
                snoopedExp.ShouldEqual(qySnooped.Expression);
            }
        }


        //...
        
    }
}
