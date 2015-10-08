using Materialize.Demo2.Hubs;
using Materialize.Demo2.QueryInfo;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Demo2
{
    public class Application
    {
        QueryInfoSource _queryInfoSource;
        IHubContext<QueryInfoHub> _queryInfoHubContext;

        public Application(
            QueryInfoSource queryInfoSource,
            IHubContext<QueryInfoHub> queryInfoHubContext) 
        {
            _queryInfoSource = queryInfoSource;
            _queryInfoHubContext = queryInfoHubContext;
        }


        public void Run() {
        }       

    }
}