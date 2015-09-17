using Materialize.Reify.Mapping;
using Materialize.SourceRegimes;
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
        public readonly MapContext MapContext;

        //---------------------------------------------------
        //Below fields not for keying: all derived from above

        public readonly Expression BaseExp;

        public readonly MethodCallExpression CallExp;
        public readonly MethodInfo Method;
        public readonly MethodInfo MethodDef;
        public readonly Type[] TypeArgs;

        public ParseContext(
            Expression exSubject, 
            Expression exBase, 
            MapContext mapContext) 
        {
            Debug.Assert(exSubject.Contains(exBase));
            Debug.Assert(exBase.Type.GetEnumerableElementType() == mapContext.TypeVector.DestType);

            SubjectExp = exSubject;
            BaseExp = exBase;

            MapContext = mapContext;

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
        
        public ParseContext Spawn(Expression exSubject) {
            return new ParseContext(exSubject, BaseExp, MapContext);
        }
        
    }



    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //THIS IS FOR THE MOMENT WORSE THAN USELESS!!!!!!!!!!!!!
    //equality on subject exps will almost always fail: need to parameterize and test via visitor
    class ParseContextEqualityComparer
        : IEqualityComparer<ParseContext>
    {
        public static readonly ParseContextEqualityComparer Default = new ParseContextEqualityComparer();
        static readonly MapContextEqualityComparer _mapContextComp = MapContextEqualityComparer.Default;

        public bool Equals(ParseContext x, ParseContext y) {
            return _mapContextComp.Equals(x.MapContext, y.MapContext)
                    && x.SubjectExp == y.SubjectExp;                    //exp matching will be more expensive surely
        }

        public int GetHashCode(ParseContext obj) {
            return obj.SubjectExp.GetHashCode()
                    ^ (_mapContextComp.GetHashCode(obj.MapContext) << 16);
        }
    }


}
