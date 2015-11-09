using Materialize.Monitor.DataStructures;
using Materialize.Monitor.Reporting;
using Materialize.Expressions;
using Materialize.Reify;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Transitions;
using Materialize.Types;
using Mono.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;

namespace Materialize.Monitor.QueryInfo
{
    internal class Snooper : ISnooper
    {
        Guid _guid = Guid.NewGuid();
        IDSource _idSource = new IDSource();
        IObserver<Report> _reports;
        
        public Snooper(IObserver<Report> reports) {
            _reports = reports;
        }

        void ISnooper.OnEvent(SnoopEvent ev) {
            OnEvent((dynamic)ev);
        }
        


        void OnEvent(SnoopEvent ev) {
            //nothing...
        }


        void OnEvent(SnoopEvent<IEnumerable<Transition>> ev) {
            //arrangements
        }

        void OnEvent(SnoopEvent<Scheme> ev) {
            _reports.OnNext(new ExpressionReport(
                                    _guid, 
                                    _idSource.GetNextID(), 
                                    ev.Name, 
                                    ev.Object.Exp.Simplify().ToCSharpCode()));
        }

        void OnEvent(SnoopEvent<IEnumerable> ev) {
            //reifications
        }







        //void ISnooper.OnQuery(Expression exQuery) {
        //    _exQueryFromClient = exQuery;
        //}


        //void ISnooper.OnFetch(Expression exQuery) {
        //    _exFetch = exQuery;
        //}

        //void ISnooper.OnFetched(object fetched) {
        //    //...
        //}


        //public void OnTransform(Expression exTransform) {
        //    _exTransform = exTransform;
        //}


        //void ISnooper.OnTransformed(object transformed) {
        //    _reports.OnNext(RenderReport());
        //}


        Report RenderReport() 
        {
            throw new NotImplementedException();

            //return new Report(
            //                null,
            //                _exQueryFromClient?.Simplify().ToCSharpCode(),
            //                _exFetch?.Simplify().ToCSharpCode(),
            //                _exTransform?.Simplify().ToCSharpCode(),
            //                null);
        }

    }
}