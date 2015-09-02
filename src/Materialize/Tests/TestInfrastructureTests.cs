using AutoMapper;
using FizzWare.NBuilder;
using Should;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoMapper.QueryableExtensions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Materialize.Tests
{
    public class TestInfrastructureTests
    {        
        [Fact]
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


        [Fact]
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
