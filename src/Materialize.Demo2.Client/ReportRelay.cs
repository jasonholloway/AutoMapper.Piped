using Materialize.Demo2.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo2.Client
{
    class ReportRelay : IObserver<QueryReport>
    {
        public void OnCompleted() {
            throw new NotImplementedException();
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        public void OnNext(QueryReport value) {
            using(var http = new HttpClient()) {
                http.PostAsJsonAsync("http://localhost:50627/api/reports/submit", value).Wait();
            }            
        }
    }
}
