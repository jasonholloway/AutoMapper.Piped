﻿using AutoMapper;
using Materialize.Tests.Infrastructure;
using ObjectPrinter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Mono.Linq.Expressions;

namespace Materialize.Demo
{
    class Program
    {
        //////////////////////////////////////////////////////////////////////////////////////
        // A small, contrived example to show what Materialize does behind the scenes.
        //
        // Different projections prompt different behaviours. 
        //
        // Details are written to the console of the underlying EF query; the object graph 
        // fetched from the server; and the object graph subsequently transformed by the client.
        //
        // *** Relies on SQL Server service running! ***
        //
        
        static void Main(string[] args) 
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
            using(var ctx = new Context()) 
            {
                Expression sourceQueryExp = null;
                IQueryable query = null;
                IEnumerable<object> fetched = null;
                IEnumerable<object> transformed = null;

                var vendorQuery = ctx.Vendors
                                        .Include(v => v.RabbitOnOffer.Breed)
                                        .Include(v => v.Town)
                                            .Snoop(e => sourceQueryExp = e); //the snoop extensions are simply utilities for testing

                var venderModels = vendorQuery
                                        .MaterializeAs<RabbitVendorModel>()
                                            .SnoopOnQuery(q => query = q) 
                                            .SnoopOnFetched(f => fetched = f)
                                            .SnoopOnTransformed(t => transformed = t)
                                        .Take(3)    //this is IMaterializable<T>.Take, which adds a modifier to the stack
                                        .ToArray(); //needed to trigger materialization


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

                Console.ReadLine();
            }
        }









    }
}
