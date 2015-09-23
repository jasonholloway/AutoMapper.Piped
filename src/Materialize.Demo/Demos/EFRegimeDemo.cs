using AutoMapper;
using Materialize.Reify.Parsing;
using Materialize.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Demo.Demos
{


    class EFRegimeDemo : Demo
    {
        public EFRegimeDemo() {
            Name = "EF regime behaviour";
        }
        
        
        public override void Run() 
        {
            using(var ctx = new Context()) {
                var res = ctx.Towns
                                .Include(t => t.Vendors)
                                .Where(t => t.Vendors.FirstOrDefault().Name.Length > 3)
                                .ToArray();
            }
           
        }
    }
}
