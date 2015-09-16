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
        public readonly bool FilterOnClient;
        
        public CallParseContext(MethodInfo method, bool filterOnClient = false) {
            Method = method;
            
            if(method.IsGenericMethod) {
                MethodDef = method.GetGenericMethodDefinition();
                ArgTypes = method.GetGenericArguments();
            }
            else {
                MethodDef = null;
                ArgTypes = Type.EmptyTypes;
            }

            FilterOnClient = filterOnClient;
        }
    }


    class ParseContextEqualityComparer
        : IEqualityComparer<CallParseContext>
    {
        public static readonly ParseContextEqualityComparer Default = new ParseContextEqualityComparer();

        public bool Equals(CallParseContext x, CallParseContext y) {
            return x.Method == y.Method 
                    && x.FilterOnClient == y.FilterOnClient;
        }

        public int GetHashCode(CallParseContext obj) {
            return obj.Method.GetHashCode() 
                    ^ obj.FilterOnClient.GetHashCode();
        }
    }


}
