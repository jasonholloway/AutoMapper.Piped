using Materialize.Reify2.Parse.SeqMethods;
using Materialize.Reify2.Parse.Source;
using Materialize.Reify2.Transitions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parse
{   
    internal static class Parser
    {             
        public static IEnumerable<Transition> Parse(ParseSubject subject) 
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
                   

        public static LinkedList<Transition> ParseAndPackage(ParseSubject subject) 
        {
            var llTrans = new LinkedList<Transition>(Parse(subject));
                                   
            foreach(var node in llTrans.EnumerateNodes()) {
                node.Value.Site = node;
            }

            return llTrans;
        }

    }
}
