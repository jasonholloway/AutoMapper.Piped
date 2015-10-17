using Materialize.Demo2.DataStructures;
using Materialize.Demo2.Reporting;
using Materialize.Expressions;
using Materialize.Reify;
using Materialize.Types;
using Mono.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;

namespace Materialize.Demo2.QueryInfo
{
    internal class Snooper : ISnooper
    {
        IObserver<QueryReport> _reports;

        Expression _exQueryFromClient;
        Expression _exQueryToServer;
        IReifyStrategy _strategy;


        public Snooper(IObserver<QueryReport> reports) {
            _reports = reports;
        }

        
        void ISnooper.OnQueryFromClient(Expression exQuery) {
            _exQueryFromClient = exQuery;
        }

        void ISnooper.OnStrategized(IReifyStrategy strategy) {
            _strategy = strategy;
        }

        void ISnooper.OnQueryToServer(IQueryable query) {
            _exQueryToServer = query.Expression;
        }

        void ISnooper.OnFetched(IEnumerable enFetched) {
            //...
        }

        void ISnooper.OnTransformed(IEnumerable enTransformed) {
            _reports.OnNext(RenderReport());
        }
        

        QueryReport RenderReport() 
        {
            return new QueryReport(
                            null,
                            _exQueryFromClient?.Simplify().ToCSharpCode(),
                            _exQueryToServer?.Simplify().ToCSharpCode(),
                            Tree.BuildFromCrawl(_strategy, s => s.UpstreamStrategies)
                                    .Project(s => new StrategyReport(
                                                            s.GetType().GetNiceName(), 
                                                            "Description..."))
                            );
        }
        
    }
}