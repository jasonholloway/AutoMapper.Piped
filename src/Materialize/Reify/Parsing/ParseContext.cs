using Materialize.Expressions;
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

        public readonly Expression BaseExp; //even though variable, will never be mistaken for anything else...

        public readonly MethodCallExpression CallExp;
        public readonly MethodInfo Method;
        public readonly MethodInfo MethodDef;
        public readonly Type[] TypeArgs;
                
        public bool IsMappingBase {
            get { return SubjectExp == BaseExp; }
        }

        public ParseContext(
            Expression exSubject, 
            Expression exBase, 
            MapContext mapContext) 
        {
            Debug.Assert(exSubject.Contains(exBase));
            Debug.Assert(exBase.Type.GetEnumerableElementType() == mapContext.TypeVector.DestType.GetEnumerableElementType());

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





    //There is a problem with the cache: the MappedBase is a constant, and will only 
    //be compared by its type, which should be pretty unique in the query expression,
    //but isn't guaranteed to be so. The fact that it's the base expression should be part of the
    //comparison. 

    //i subject is baseexp is another part of the comparison then




    class ParseContextEqualityComparer
        : IEqualityComparer<ParseContext>
    {
        public static readonly ParseContextEqualityComparer Default = new ParseContextEqualityComparer();

        static readonly MapContextEqualityComparer _mapContextComp = MapContextEqualityComparer.Default;
        static readonly IEqualityComparer<Expression> _subjectExpComparer = new QueryExpressionComparer();

        public bool Equals(ParseContext x, ParseContext y) {
            return _mapContextComp.Equals(x.MapContext, y.MapContext)
                    && x.IsMappingBase == y.IsMappingBase
                    && _subjectExpComparer.Equals(x.SubjectExp, y.SubjectExp);
        }

        public int GetHashCode(ParseContext obj) {
            return _subjectExpComparer.GetHashCode(obj.SubjectExp)
                    ^ (_mapContextComp.GetHashCode(obj.MapContext) << 16);
        }
    }


}
