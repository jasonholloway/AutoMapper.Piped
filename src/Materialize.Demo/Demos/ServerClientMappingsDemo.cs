using AutoMapper;
using Materialize.Tests.Infrastructure;
using Mono.Linq.Expressions;
using ObjectPrinter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Demo.Demos
{

    class ServerClientMappingsDemo : Demo
    {
        public ServerClientMappingsDemo() {
            Name = "Server-client distribution of custom projections";

            Description = @"
Different projections prompt different behaviours.

Relies on running SqlServer service.
";
        }
        
        public override void Run() 
        {
            var currencyContext = new CurrencyContext();
            currencyContext.SetActiveCurrency(new Currency("Pound", "£{0:N}", 0.65M));


            //The below just customises sourge regime behaviour for this demo
            //Usually this is determined by the pre-provided ISourceRegime classes (yet to be written for EF!)
            //In this instance, projections with paramterised ctors are rejected 
            //For fun, you could change this to always return false (setting to true would raise EF exceptions)
            MaterializeServices.Init(x => {
                x.EmplaceCustomSourceRegime(
                        exProj => !exProj.Contains(ex => ex is NewExpression
                                                            && ((NewExpression)ex).Arguments.Any()));
            });


            Mapper.Initialize(x => {
                x.CreateMap<Rabbit, RabbitModel>();
                x.CreateMap<RabbitVendor, RabbitVendorModel>();
                x.CreateMap<Town, TownModel>();

                x.CreateMap<RabbitBreed, RabbitBreedModel>()   //to be done server-side!
                    .ProjectUsing(b => new RabbitBreedModel() { Name = b.Name + " Rabbit" });

                x.CreateMap<decimal, CurrencyAmount>()          //to be done client-side, as has parameterised ctor!
                    .ProjectUsing(d => new CurrencyAmount(currencyContext, d));
            });


            //Make sure SQLServer service is running!
            using(var ctx = new Context()) {
                Expression sourceQueryExp = null;
                IQueryable query = null;
                IEnumerable<object> fetched = null;
                IEnumerable<object> transformed = null;

                var vendorQuery = ctx.Vendors
                                        .Include(v => v.RabbitOnOffer.Breed)
                                        .Include(v => v.Town)
                                            .Snoop(e => sourceQueryExp = e); //the snoop extensions are simply utilities for testing
                
                var snooper = new Snooper();
                snooper.QueryToServer += (qy => query = qy);
                snooper.Fetched += (f => fetched = f.ToArray());
                snooper.Transformed += (t => transformed = t.ToArray());

                var vendorModels = vendorQuery.MapAs<RabbitVendorModel>(snooper)
                                                .Take(3)    
                                                .ToArray();
                

                Console.WriteLine("***************************************************");
                Console.WriteLine("* Underlying source query sent to EF: \r\n");
                Console.WriteLine(sourceQueryExp.ToCSharpCode());
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("***************************************************");
                Console.WriteLine("* SQL query: \r\n");
                Console.WriteLine(query.ToString());
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("***************************************************");
                Console.WriteLine("* Object graph fetched from server: \r\n");
                Console.WriteLine(fetched.DumpToString());
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("***************************************************");
                Console.WriteLine("* Object graph transformed by client: \r\n");
                Console.WriteLine(transformed.DumpToString());
                Console.WriteLine();        
            }

        }
    }
}
