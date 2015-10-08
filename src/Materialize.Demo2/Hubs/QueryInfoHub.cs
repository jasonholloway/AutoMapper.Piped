using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Materialize.Demo2.Hubs
{

    public interface IQueryInfoHub
    {
        void AnnounceNewQueryInfo(int queryID);
    }


    public class QueryInfoHub : Hub<IQueryInfoHub>
    {
        public override Task OnConnected() {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled) {
            return base.OnDisconnected(stopCalled);
        }

    }

}