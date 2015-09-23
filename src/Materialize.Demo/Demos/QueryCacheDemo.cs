using AutoMapper;
using Materialize.Reify.Parsing;
using Materialize.Tests.Infrastructure;
using Mono.Linq.Expressions;
using ObjectPrinter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Demo.Demos
{


    class QueryCacheDemo : Demo
    {
        public QueryCacheDemo() {
            Name = "Query cache performance";

            Description = @"
Don't quite know as yet...
";
        }
        
        



        abstract class QueryTest
        {
            public string Name { get; protected set; }
            public IEnumerable<TimeSpan> Timings { get; protected set; }

            public abstract void TimeExecution();
        }

        class QueryTest<TElem> : QueryTest
        {
            List<TimeSpan> _timings = new List<TimeSpan>();

            public IQueryable<TElem> Query { get; private set; }
            

            public QueryTest(string name, IQueryable<TElem> query) {
                Name = name;
                Query = query;
                Timings = _timings;
            }


            public override void TimeExecution() {
                var timer = new Stopwatch();

                timer.Restart();
                Query.Provider.Execute<IEnumerable<TElem>>(Query.Expression).ToArray();                
                timer.Stop();

                _timings.Add(timer.Elapsed);
            }
        }

        

        
        public override void Run() 
        {
            MaterializeServices.Init(x => {
                x.EmplaceIntolerantSourceRegime();
            });
            
            Mapper.Initialize(x => {
                x.CreateMap<Rabbit, RabbitModel>();
                x.CreateMap<RabbitVendor, RabbitVendorModel>();
                x.CreateMap<Town, TownModel>();

                x.CreateMap<RabbitBreed, RabbitBreedModel>()
                    .ProjectUsing(b => new RabbitBreedModel() { Name = b.Name + " Rabbit" });
                
                x.CreateMap<decimal, CurrencyAmount>()
                    .ProjectUsing(d => new CurrencyAmount(CurrencyContext.Default, d));
            });

            
            var data = new TestData();

            var qyRabbits = data.Rabbits.AsQueryable().MapAs<RabbitModel>();

            var qyVendors = data.Vendors.AsQueryable().MapAs<RabbitVendorModel>();
                        

            var queryTests = new QueryTest[] {
                new QueryTest<RabbitModel>(
                    "Query 1 - Very first query; much one-off static code to execute", 
                    qyRabbits.Skip(1).Take(3).Where(m => m.Name.Length < 10)),
                
                new QueryTest<RabbitModel>(
                    "Query 2 - New shape, though base mapping is same as #1, and static code is already in place", 
                    qyRabbits.Take(2).Where(m => m.Name.Length > 5)),

                new QueryTest<RabbitVendorModel>(
                    "Query 3 - Entirely new shape, and mapping is different too (child nodes of mapping reused form #1 however)", 
                    qyVendors.Where(m => m.Name.Length < 8)),

                new QueryTest<RabbitVendorModel>(
                    "Query 4 - Shares shape and mapping with #3, and so should reuse cache from the off", 
                    qyVendors.Where(m => m.Name.Length < 10)),
            };





            Console.WriteLine("************************************************************");
            Console.WriteLine("* Timings of assorted queries (in ticks)");
            Console.WriteLine();
            Console.WriteLine();


            for(int i = 0; i < 15; i++) {
                foreach(var test in queryTests) {
                    test.TimeExecution();
                }
            }


            var parseStrategies = MaterializeServices.Resolve<IParseStrategySource>();



            foreach(var test in queryTests) {
                Console.WriteLine("******************************************");
                Console.WriteLine("* {0}:", test.Name);
                Console.WriteLine();

                foreach(var timing in test.Timings) {
                    Console.WriteLine(timing.Ticks);
                }
                                
                Console.WriteLine();
                Console.WriteLine();
            }

            
        }
    }
}
