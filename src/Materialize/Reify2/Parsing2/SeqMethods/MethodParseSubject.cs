using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.SeqMethods
{
    class MethodParseSubject
    {
        public readonly Type[] TypeArgs;
        public readonly ReadOnlyCollection<Expression> Args;
        public readonly ReifyContext ReifyContext;

        public MethodParseSubject(ParseSubject parseSubject) {
            TypeArgs = parseSubject.MethodTypeArgs;
            Args = parseSubject.CallExp.Arguments;
            ReifyContext = parseSubject.ReifyContext;
        }
    }
}
