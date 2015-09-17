using AutoMapper;
using Materialize.Tests.Infrastructure;
using ObjectPrinter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Mono.Linq.Expressions;
using Materialize.Reify.Parsing;
using System.Reflection;

namespace Materialize.Demo
{
    class Program
    {        
        static void Main(string[] args) 
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            var demoTypes = types.Where(t => !t.IsAbstract 
                                               && typeof(Demo).IsAssignableFrom(t));

            var demos = demoTypes.Select(t => (Demo)Activator.CreateInstance(t)).ToArray();
                        
            while(true) {
                DemoMenu(demos);
            }
        }




        static void DemoMenu(Demo[] demos) 
        {
            Console.WriteLine("*********************************************************");

            Console.WriteLine("* Available demos:");
            Console.WriteLine("*");

            for(int i = 1; i <= demos.Length; i++) {
                var demo = demos[i - 1];
                Console.WriteLine("* {0}: {1}", i, demo.Name);            
            }

            Console.WriteLine("*");
            Console.WriteLine("* Enter a number and hit return...");

            while(true) {
                string s = Console.ReadLine();

                int demoID = 0;

                if(int.TryParse(s, out demoID)) {
                    if(demoID > 0 && demoID <= demos.Length) {
                        var demo = demos[demoID - 1];
                        RunDemo(demo);
                        break;
                    }
                }
            }
        }

        static void RunDemo(Demo demo) {
            Console.Clear();

            demo.Run();

            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();

            Console.Clear();
        }







    }
}
