using Materialize.Reify2.Parsing2.Methods.Handlers;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.Methods
{
    static class MethodParser
    {

        public static IEnumerable<ITransition> Parse(ParseSubject subject) 
        {
            Debug.Assert(subject.SubjectExp is MethodCallExpression);

            HandlerFactory factory = null;

            if(_dParsers.TryGetValue(subject.MethodDef, out factory)) {
                var handler = factory(subject);
                return handler.Respond();
            }

            throw new InvalidOperationException($"Can't find specialised parser delegate for method {subject.Method}");
        }


                
        delegate ParseHandler HandlerFactory(ParseSubject subject);

        static IDictionary<MethodInfo, HandlerFactory> _dParsers
            = new Dictionary<MethodInfo, HandlerFactory>() {
                { QueryableMethods.MapAs, s => ParseHandler.Create<MapAsHandler>(s) },
                { QueryableMethods.Where, s => ParseHandler.Create<WhereHandler>(s) },
                { QueryableMethods.Select, s => ParseHandler.Create<SelectHandler>(s) },
                { QueryableMethods.Skip, s => ParseHandler.Create<SkipHandler>(s) },
                { QueryableMethods.Take, s => ParseHandler.Create<TakeHandler>(s) },
                //{ QueryableMethods.First, null },
                //{ QueryableMethods.Single, null },
                //{ QueryableMethods.Last, null },
                //{ QueryableMethods.AnyPred, null },
                //{ QueryableMethods.All, null },
                //{ QueryableMethods.CountPred, null },
                //{ QueryableMethods.Count, null }
            };

        
    }
}
