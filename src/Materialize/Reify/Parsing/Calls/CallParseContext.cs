using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.CallParsing
{
    struct CallParseContext
    {
        public readonly MethodInfo Method;
        public readonly MethodInfo MethodDef;
        public readonly Type[] ArgTypes;
        
        public CallParseContext(MethodInfo method) {
            Method = method;
            
            if(method.IsGenericMethod) {
                MethodDef = method.GetGenericMethodDefinition();
                ArgTypes = method.GetGenericArguments();
            }
            else {
                MethodDef = null;
                ArgTypes = Type.EmptyTypes;
            }
        }
    }


    class ParseContextEqualityComparer
        : IEqualityComparer<CallParseContext>
    {
        public static readonly ParseContextEqualityComparer Default = new ParseContextEqualityComparer();
        static TypeVectorEqualityComparer _vectorComparer = TypeVectorEqualityComparer.Default;

        public bool Equals(CallParseContext x, CallParseContext y) {
            return x.Method == y.Method;
        }

        public int GetHashCode(CallParseContext obj) {
            return obj.Method.GetHashCode();
        }
    }


}
