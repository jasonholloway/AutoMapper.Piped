using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Types
{
    internal static class TypeArgMatcher
    {
        
        public static IEnumerable<ArgMatch> Match(Type tPattern, Type tSubject) 
        {
            if(tPattern.IsGenericParameter) {
                return new[] { new ArgMatch(tPattern, tSubject) };
            }

            if(tPattern.HasElementType) {
                if(tSubject.HasElementType) {
                    return Match(tPattern.GetElementType(), tSubject.GetElementType());
                }

                ThrowBadFormException();
            }

            if(tPattern.IsGenericType) {                
                var patternGenDef = tPattern.GetGenericTypeDefinition();

                var allSubjectTypes = new[] { tSubject }.Concat(tSubject.GetAllBasesAndInterfaces())
                                                            .Where(t => t.IsGenericType);

                foreach(var subjectType in allSubjectTypes) {
                    if(subjectType.GetGenericTypeDefinition() == patternGenDef) {
                        //collect all matches from gen args
                        var matches = tPattern.GetGenericArguments()
                                        .Zip(subjectType.GetGenericArguments(), (p, s) => Match(p, s))
                                        .SelectMany(x => x);

                        //ensure all matches are distinct and non-conflicting
                        matches = matches.Distinct();
                        
                        if(matches.GroupBy(m => m.ParamType).All(g => !g.Skip(1).Any())) {
                            return matches;
                        }
                    }
                }

                ThrowBadFormException();
            }

            return Enumerable.Empty<ArgMatch>();
        }


        static void ThrowBadFormException() {
            throw new InvalidOperationException("Subject type is not of same form as pattern!");
        }
                        
        
        public struct ArgMatch
        {
            public readonly Type ParamType;
            public readonly Type ArgType;

            public ArgMatch(Type tParam, Type tArg) {
                ParamType = tParam;
                ArgType = tArg;
            }
        }


    }
}
