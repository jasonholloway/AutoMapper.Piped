using Materialize.Expressions;
using Materialize.Reify.Mapping;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing
{
    struct ParseContext
    {
        public readonly Expression SubjectExp;
        public readonly ReifyContext ReifyContext;        
        
        //---------------------------------------------------
        //Below fields not for keying: all derived from above

        public readonly Expression BaseExp; //even though variable, will never be mistaken for anything else...

        public readonly Type SourceType;

        public readonly MethodCallExpression CallExp;
        public readonly MethodInfo Method;
        public readonly MethodInfo MethodDef;
        public readonly Type[] MethodTypeArgs;
                
        public bool IsMappingBase {
            get { return SubjectExp == BaseExp; }
        }

        public ParseContext(
            Expression exSubject, 
            Expression exBase, 
            Type sourceType,
            ReifyContext reifyContext) 
        {
            Debug.Assert(exSubject.Contains(exBase));

            SubjectExp = exSubject;
            BaseExp = exBase;
            SourceType = sourceType;
            ReifyContext = reifyContext;
            
            CallExp = SubjectExp as MethodCallExpression;
            Method = CallExp?.Method;

            if(Method != null && Method.IsGenericMethod) {
                MethodDef = Method.GetGenericMethodDefinition();
                MethodTypeArgs = Method.GetGenericArguments();
            }
            else {
                MethodDef = null;
                MethodTypeArgs = Type.EmptyTypes;
            }
        }
        
        public ParseContext Spawn(Expression exSubject, Type sourceType) {
            return new ParseContext(exSubject, BaseExp, sourceType, ReifyContext);
        }
        
    }

    

    class ParseContextEqualityComparer
        : IEqualityComparer<ParseContext>
    {
        public static readonly ParseContextEqualityComparer Default = new ParseContextEqualityComparer();
        
        static readonly ReifyContextEqualityComparer _reifyContextComp = ReifyContextEqualityComparer.Default;
        static readonly IEqualityComparer<Expression> _subjectExpComparer = new CacheableQueryComparer();

        public bool Equals(ParseContext x, ParseContext y) {
            return _reifyContextComp.Equals(x.ReifyContext, y.ReifyContext)
                    && x.SourceType.Equals(y.SourceType)
                    && x.IsMappingBase == y.IsMappingBase
                    && _subjectExpComparer.Equals(x.SubjectExp, y.SubjectExp);
        }

        public int GetHashCode(ParseContext obj) {
            return _subjectExpComparer.GetHashCode(obj.SubjectExp)
                    ^ (obj.SourceType.GetHashCode() << 7)
                    ^ (_reifyContextComp.GetHashCode(obj.ReifyContext) << 16);
        }
    }


}
