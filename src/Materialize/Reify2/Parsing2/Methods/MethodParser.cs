using Materialize.Reify2.Parsing2.Methods.Handlers;
using Materialize.Reify2.Transitions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.Methods
{
    static partial class MethodParser
    {

        public static IEnumerable<ITransition> Parse(ParseSubject subject) 
        {
            Debug.Assert(subject.SubjectExp is MethodCallExpression);
            Debug.Assert(subject.MethodDef.IsStatic);
            Debug.Assert(subject.Method.GetParameters().First().ParameterType.IsQueryable());

            //pass upwards 
            var upstreamSubject = subject.Spawn(subject.CallExp.Arguments[0]);
            var upstreamTrans = Parser.Parse(upstreamSubject);
            

            MethodParseHandler fnHandler = null;

            if(_dHandlers.TryGetValue(subject.MethodDef, out fnHandler)) {                
                return upstreamTrans.Concat(
                                fnHandler(new MethodParseSubject(subject))
                                );
            }

            throw new InvalidOperationException($"Can't find specialised parser delegate for method {subject.Method}");
        }




        class MethodParseSubject
        {
            public readonly Type[] TypeArgs;
            public readonly ReadOnlyCollection<Expression> Args;
            public readonly ReifyContext ReifyContext;

            public MethodParseSubject(ParseSubject parseSubject) {
                TypeArgs = parseSubject.MethodTypeArgs;
                Args = parseSubject.CallExp.Arguments;
                ReifyContext = parseSubject.ReifyContext;
            }
        }



        delegate IEnumerable<ITransition> MethodParseHandler(MethodParseSubject subject);



        static IDictionary<MethodInfo, MethodParseHandler> _dHandlers
            = new Dictionary<MethodInfo, MethodParseHandler>() {
                { QueryableMethods.MapAs, ParseMapAs },
                { QueryableMethods.Where, ParseWhere },
                { QueryableMethods.Select, ParseSelect },
                { QueryableMethods.Skip, ParseSkip },
                { QueryableMethods.Take, ParseTake },
                { QueryableMethods.First, ParseFirst },
                { QueryableMethods.Single, ParseSingle },
                { QueryableMethods.Last, ParseLast },
                { QueryableMethods.ElementAt, ParseElementAt },
                { QueryableMethods.FirstOrDefault, ParseFirstOrDefault },
                { QueryableMethods.SingleOrDefault, ParseSingleOrDefault },
                { QueryableMethods.LastOrDefault, ParseLastOrDefault },
                { QueryableMethods.ElementAtOrDefault, ParseElementAtOrDefault }
                //{ QueryableMethods.AnyPred, null },
                //{ QueryableMethods.All, null },
                //{ QueryableMethods.CountPred, null },
                //{ QueryableMethods.Count, null }
            };


               

        static IEnumerable<ITransition> ParseWhere(MethodParseSubject s) {
            var exPred = (LambdaExpression)((UnaryExpression)s.Args[1]).Operand;
            yield return new FilterTransition(exPred);
        }


        static IEnumerable<ITransition> ParseSelect(MethodParseSubject s) {
            var exProj = (LambdaExpression)((UnaryExpression)s.Args[1]).Operand;
            yield return new ProjectionTransition(exProj);
        }
        

        static IEnumerable<ITransition> ParseSkip(MethodParseSubject s) {
            yield return new PartitionTransition(PartitionType.Skip, s.Args[1]);
        }


        static IEnumerable<ITransition> ParseTake(MethodParseSubject s) {
            yield return new PartitionTransition(PartitionType.Take, s.Args[1]);
        }


        static IEnumerable<ITransition> ParseFirst(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.First, false);
        }
        
        static IEnumerable<ITransition> ParseLast(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.Last, false);
        }

        static IEnumerable<ITransition> ParseSingle(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.Single, false);
        }

        static IEnumerable<ITransition> ParseElementAt(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.ElementAt, false, s.Args[1]);
        }

        static IEnumerable<ITransition> ParseFirstOrDefault(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.First, true);
        }

        static IEnumerable<ITransition> ParseLastOrDefault(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.Last, true);
        }

        static IEnumerable<ITransition> ParseSingleOrDefault(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.Single, true);
        }

        static IEnumerable<ITransition> ParseElementAtOrDefault(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.ElementAt, true, s.Args[1]);
        }



    }
}
