﻿using Materialize.Tests.Infrastructure;
using NUnit.Framework;
using Should;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Tests2
{
    [TestFixture]    
    class ParsingMethods : TestClassBase
    {
        private object f;

        public ParsingMethods() 
        {
            InitServices(x => x.EmplaceIntolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<int, string>()
                    .ProjectUsing(i => i.ToString());
            });

            Fetched = Enumerable.Empty<object>();
        }


        IEnumerable<object> Fetched { get; set; }


        IQueryable<string> Range(int start, int count) {
            var snooper = new EventSnooper();
            snooper.Fetched += (f => Fetched = f is IEnumerable ? (IEnumerable<object>)f : new[] { f });
                        
            var ints = Enumerable.Range(start, count);
            return ints.AsQueryable().MapAs<string>(snooper);
        }






        [Test]
        public void First() {
            var first = Range(50, 100)
                            .First();

            first.ShouldEqual("50");
            Fetched.Count().ShouldEqual(1);     
        }
         
        [Test]
        public void FirstThrows() {
            Assert.Throws<InvalidOperationException>(() => Range(199, 0).First());
        }
        
        


        [Test]
        public void FirstOrDefault() {
            throw new NotImplementedException();
        }


        [Test]
        public void Single() {
            var single = Range(10, 1)
                            .Single();

            single.ShouldEqual("10");
            Fetched.Count().ShouldEqual(1);
        }


        [Test]
        public void SingleThrows() 
        {            
            Assert.Throws<InvalidOperationException>(() => Range(0, 10).Single());
        }


        [Test]
        public void SingleOrDefault() 
        {
            var single = Range(1, 1)
                            .SingleOrDefault();

            single.ShouldEqual("1");
            Fetched.Count().ShouldEqual(1);
        }



        [Test]
        public void SingleOrDefaultReturnsDefault() 
        {
            var result = Range(1, 0)
                            .SingleOrDefault();

            result.ShouldEqual(default(string));
            Fetched.Count().ShouldEqual(0);
        }


    

        [Test]
        public void Last() {
            var last = Range(50, 100)
                            .Last();

            last.ShouldEqual("149");
            Fetched.Count().ShouldEqual(1);
        }

        [Test]
        public void LastThrows() {
            Assert.Throws<InvalidOperationException>(() => Range(20, 0).Last());
        }

        [Test]
        public void LastOrDefault() {
            throw new NotImplementedException();
        }

        

        [Test]
        public void Count() {
            var count = Range(50, 100)
                            .Count();

            count.ShouldEqual(100);
        }


        



    }
}
