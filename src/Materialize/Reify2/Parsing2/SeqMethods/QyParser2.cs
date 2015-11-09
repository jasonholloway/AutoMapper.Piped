using Materialize.Reify2.Transitions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.SeqMethods
{
    static partial class QyParser
    {

        public static IEnumerable<Transition> Parse(ParseSubject s) {
            Debug.Assert(s.Method.DeclaringType == typeof(Queryable));

            Handler fn = null;
            var method = s.MethodDef != null ? s.MethodDef : s.Method;

            if(_dHandlers.TryGetValue(method, out fn)) {
                return new[] { fn(s.CallExp) };
            }

            throw new InvalidOperationException($"Can't find specialised parser delegate for method {s.Method}");
        }
        
    }
}
