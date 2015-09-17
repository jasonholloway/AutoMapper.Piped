using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing
{
    struct ParseContext
    {
        public readonly Expression SubjectExp;

        //---------------------------------------------------
        //Below fields not for keying: all derived from above

        public readonly Expression BaseExp;

        public readonly MethodCallExpression CallExp;
        public readonly MethodInfo Method;
        public readonly MethodInfo MethodDef;
        public readonly Type[] TypeArgs;

        public ParseContext(Expression exSubject, Expression exBase) 
        {
            Debug.Assert(exSubject.Contains(exBase));

            SubjectExp = exSubject;
            BaseExp = exBase;

            CallExp = SubjectExp as MethodCallExpression;
            Method = CallExp?.Method;

            if(Method != null && Method.IsGenericMethod) {
                MethodDef = Method.GetGenericMethodDefinition();
                TypeArgs = Method.GetGenericArguments();
            }
            else {
                MethodDef = null;
                TypeArgs = Type.EmptyTypes;
            }
        }
    }



    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //THIS IS FOR THE MOMENT WORSE THAN USELESS!!!!!!!!!!!!!
    class ParseContextEqualityComparer
        : IEqualityComparer<ParseContext>
    {
        public static readonly ParseContextEqualityComparer Default = new ParseContextEqualityComparer();

        public bool Equals(ParseContext x, ParseContext y) {
            return x.SubjectExp == y.SubjectExp;
        }

        public int GetHashCode(ParseContext obj) {
            return obj.SubjectExp.GetHashCode();
        }
    }


}
