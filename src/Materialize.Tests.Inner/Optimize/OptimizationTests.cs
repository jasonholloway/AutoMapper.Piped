using Materialize.Reify2.Optimize;
using Materialize.Reify2.Transitions;
using Materialize.SourceRegimes;
using Materialize.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Tests.Inner.Optimize
{
    [TestFixture]
    class OptimizationTests
    {

        class Item
        {
            public int Int { get; set; }

            public Item(int i) {
                Int = i;
            }
        }


        static Random _rand = new Random(12345);

        static IQueryable<Item> _qyItems = Enumerable.Range(0, 50)
                                                .Select(_ => new Item(_rand.Next(1, 30)))
                                                .AsQueryable(); 
        

        static LinkedList<Transition> PrepTrans(params Transition[] trans) 
        {
            var llTrans = new LinkedList<Transition>(trans);

            foreach(var node in llTrans.EnumerateNodes()) {
                node.Value.Site = node;
            }

            return llTrans;
        }


        static Expression<Func<T, R>> Exp<T, R>(Expression<Func<T, R>> ex) {
            return ex;
        }

        static Expression<Func<T, T2, R>> Exp<T, T2, R>(Expression<Func<T, T2, R>> ex) {
            return ex;
        }








        [Test]
        public void WhereShiftsPastFetch() 
        {
            var trans = PrepTrans(
                new SourceTransition(new TolerantRegime(), _qyItems.Expression),
                new FetchTransition(new TolerantRegime()),
                new WhereTransition() {
                    Predicate = Exp((Item x) => x.Int % 2 == 0)
                }
            );
                        
            Optimizer.Optimize(trans);
            
            Assert.That(
                    trans.Select(t => t.GetType()),
                    Is.EquivalentTo(new[] {
                        typeof(SourceTransition),
                        typeof(WhereTransition),
                        typeof(FetchTransition)
                    }));
        }


        [Test]
        public void Where2ShiftsPastFetch() 
        {
            var trans = PrepTrans(
                new SourceTransition(new TolerantRegime(), _qyItems.Expression),
                new FetchTransition(new TolerantRegime()),
                new Where2Transition() {
                    Predicate = Exp((Item x, int i) => i % 2 == 0)
                }
            );

            Optimizer.Optimize(trans);

            Assert.That(
                    trans.Select(t => t.GetType()),
                    Is.EquivalentTo(new[] {
                        typeof(SourceTransition),
                        typeof(Where2Transition),
                        typeof(FetchTransition)
                    }));
        }


    }
}
