using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Types
{
    internal static class TypeMatcher
    {
        
        //Instead of throwing 'bad form' exception, should return a positive 'no match' value


        public static Result Match(Type tPattern, Type tSubject) 
        {
            var matches = InnerMatch(tPattern, tSubject);

            return matches != null
                    ? new Result(true, matches.ToList())
                    : new Result(false, new List<TypeArg>(0));
        }


        static IEnumerable<TypeArg> InnerMatch(Type tPattern, Type tSubject) 
        {
            if(tPattern == null || tSubject == null) {
                throw new ArgumentNullException();
            }

            if(tPattern == tSubject) {
                return Enumerable.Empty<TypeArg>();
            }

            if(tPattern.IsGenericParameter) {
                return new[] { new TypeArg(tPattern, tSubject) };
            }

            if(tPattern.HasElementType) {
                if(tSubject.HasElementType) {
                    return InnerMatch(tPattern.GetElementType(), tSubject.GetElementType());
                }
            }

            if(tPattern.IsGenericType) {                
                var patternGenDef = tPattern.GetGenericTypeDefinition();

                var allSubjectTypes = new[] { tSubject }.Concat(tSubject.GetAllBasesAndInterfaces())
                                                            .Where(t => t.IsGenericType);

                foreach(var subjectType in allSubjectTypes) {
                    if(subjectType.GetGenericTypeDefinition() == patternGenDef) {
                        //collect all matches from gen args
                        var matchColls = tPattern.GetGenericArguments()
                                            .Zip(subjectType.GetGenericArguments(), (p, s) => InnerMatch(p, s));

                        if(matchColls.Any(z => z == null)) {
                            return null;
                        }

                        var matches = matchColls.SelectMany(x => x)
                                                .Distinct();

                        //ensure no double-matches!                        
                        if(matches.GroupBy(m => m.ParamType).All(g => !g.Skip(1).Any())) {
                            return matches;
                        }
                    }
                }
            }

            if(tSubject.GetAllBasesAndInterfaces().Contains(tPattern)) {
                return Enumerable.Empty<TypeArg>();
            }

            return null;
        }


        static void ThrowBadFormException() {
            throw new InvalidOperationException("Subject type is not of same form as pattern!");
        }
                        
        


        public struct Result
        {
            public readonly bool Success;
            public readonly IReadOnlyList<TypeArg> TypeArgs;

            public Result(bool success, IReadOnlyList<TypeArg> typeArgs) {
                Success = success;
                TypeArgs = typeArgs;
            }
        }

    }
}
