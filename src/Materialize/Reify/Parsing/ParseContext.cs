using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{
    struct ParseContext
    {
        public readonly MethodInfo Method;
        public readonly MethodInfo MethodDef;
        public readonly Type[] ArgTypes;
        
        public ParseContext(MethodInfo method) {
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
        : IEqualityComparer<ParseContext>
    {
        public static readonly ParseContextEqualityComparer Default = new ParseContextEqualityComparer();
        static TypeVectorEqualityComparer _vectorComparer = TypeVectorEqualityComparer.Default;

        public bool Equals(ParseContext x, ParseContext y) {
            return x.Method == y.Method;
        }

        public int GetHashCode(ParseContext obj) {
            return obj.Method.GetHashCode();
        }
    }


}
