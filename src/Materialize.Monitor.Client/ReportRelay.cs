using Materialize.Monitor.Reporting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Materialize.Monitor.Client
{
    class ReportRelay : IObserver<Report>
    {
        public void OnCompleted() {
            throw new NotImplementedException();
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        public void OnNext(Report value) {
            using(var http = new HttpClient()) {
                //Newtonsoft.Json.JsonConvert.DefaultSettings().TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                //http.PostAsJsonAsync("http://localhost:50627/api/reports/submit", value).Wait();

                http.PostAsync(
                        "http://localhost.fiddler:50627/api/reports/submit",
                        value,
                        new JsonMediaTypeFormatter() {
                            SerializerSettings = new JsonSerializerSettings() {
                                NullValueHandling = NullValueHandling.Ignore,
                                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                                TypeNameHandling = TypeNameHandling.All
                            }
                        }
                        ).Wait();
            }            
        }
    }
}
