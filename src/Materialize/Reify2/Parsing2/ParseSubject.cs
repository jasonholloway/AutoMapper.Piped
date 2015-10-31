using Materialize.Expressions;
using Materialize.Reify2.Mapping;
using Materialize.Reify2.Parameterize;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2.Parsing2
{
    struct ParseSubject
    {
        public readonly Expression SubjectExp;
        public readonly ReifyContext ReifyContext;        
        
        //---------------------------------------------------
        //Below fields not for keying: all derived from above
        
        public readonly MethodCallExpression CallExp;
        public readonly MethodInfo Method;
        public readonly MethodInfo MethodDef;
        public readonly Type[] MethodTypeArgs;
         

        public ParseSubject(
            Expression exSubject,
            ReifyContext reifyContext) 
        {
            SubjectExp = exSubject;
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
        
        public ParseSubject Spawn(Expression exSubject) {
            return new ParseSubject(exSubject, ReifyContext);
        }
        
    }

    

    //class ParseSubjectEqualityComparer
    //    : IEqualityComparer<ParseSubject>
    //{
    //    public static readonly ParseSubjectEqualityComparer Default = new ParseSubjectEqualityComparer();
        
    //    static readonly ReifyContextEqualityComparer _reifyContextComp = ReifyContextEqualityComparer.Default;

    //    public bool Equals(ParseSubject x, ParseSubject y) {
    //        return _reifyContextComp.Equals(x.ReifyContext, y.ReifyContext)
    //                && x.IsMappingBase == y.IsMappingBase
    //                && x.SubjectExp.IsFormallyEquivalentTo(y.SubjectExp);
    //    }

    //    public int GetHashCode(ParseSubject obj) {
    //        return obj.SubjectExp.GetFormalHashCode()
    //                ^ (_reifyContextComp.GetHashCode(obj.ReifyContext) << 16);
    //    }
    //}


}
