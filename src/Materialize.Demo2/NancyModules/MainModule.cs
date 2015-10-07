using Materialize.Demo2.QueryInfo;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Demo2.NancyModules
{
    public class MainModule : NancyModule
    {
        public MainModule(QueryInfoSource queryInfoSource) {
            Get[""] = _ => View["Index.cshtml"];

            Get["/query/{id}"] = p => "QueryID: " + p.id;
        }
    }
}