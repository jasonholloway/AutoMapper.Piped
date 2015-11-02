using Materialize.Reify2.Parsing2.SeqMethods;
using Materialize.Reify2.Parsing2.Source;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parsing2
{   
    internal static class Parser
    {             
        public static IEnumerable<ITransition> Parse(ParseSubject subject) 
        {
            if(subject.SubjectExp is ConstantExpression 
                && subject.SubjectExp.Type.IsQueryable()) 
            {
                return SourceParser.Parse(subject);
            }
            
            if(subject.SubjectExp is MethodCallExpression) {
                return MethodParser.Parse(subject);
            }

            throw new InvalidOperationException($"Can't parse non-method expression {subject.SubjectExp}!");
        }
                   

        public static LinkedList<ITransition> ParseAndPackage(ParseSubject subject) 
        {
            var llOps = new LinkedList<ITransition>(Parse(subject));
                                   
            foreach(var node in llOps.EnumerateNodes()) {
                node.Value.Site = node;
            }

            return llOps;
        }

    }
}
