using Materialize.Reify2.Parsing2.Methods;
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
        public static IEnumerable<IOperation> Parse(ParseSubject subject) 
        {
            if(subject.IsMappingBase) {
                var handler = ParseHandler.Create<SourceHandler>(subject);
                return handler.Respond();
            }

            if(subject.SubjectExp is MethodCallExpression) {
                return MethodParser.Parse(subject);
            }

            throw new InvalidOperationException($"Can't parse non-method expression {subject.SubjectExp}!");
        }
                   

        public static LinkedList<IOperation> ParseAndPackage(ParseSubject subject) 
        {
            var llOps = new LinkedList<IOperation>(Parse(subject));
                                   
            foreach(var node in llOps.EnumerateNodes()) {
                node.Value.Site = node;
            }

            return llOps;
        }

    }
}
