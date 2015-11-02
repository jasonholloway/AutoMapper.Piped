using Materialize.Reify2.Transitions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.SeqMethods
{
    internal class QyMethodParser : QyMethodParserBase 
    {
        static QyMethodParser @this = new QyMethodParser();


        public static IEnumerable<ITransition> Parse(ParseSubject s) 
        {
            Debug.Assert(s.Method.DeclaringType == typeof(Queryable));

            Func<QyMethodParserBase, SubParser> fnSubParser = null;
            var method = s.MethodDef != null ? s.MethodDef : s.Method;

            if(@this._dSubParsers.TryGetValue(method, out fnSubParser)) {
                var subParser = fnSubParser(@this);
                return subParser(new MethodParseSubject(s));
            }

            throw new InvalidOperationException($"Can't find specialised parser delegate for method {s.Method}");
        }


                


        protected override IEnumerable<ITransition> ParseWhere(MethodParseSubject s) {
            var exPred = (LambdaExpression)((UnaryExpression)s.Args[1]).Operand;
            yield return new FilterTransition(exPred);
        }


                
        protected override IEnumerable<ITransition> ParseSelect(MethodParseSubject s) {
            var exProj = (LambdaExpression)((UnaryExpression)s.Args[1]).Operand;
            yield return new ProjectionTransition(exProj);
        }



        #region Partition operations

        protected override IEnumerable<ITransition> ParseSkip(MethodParseSubject s) {
            yield return new PartitionTransition(PartitionType.Skip, s.Args[1]);
        }

        protected override IEnumerable<ITransition> ParseTake(MethodParseSubject s) {
            yield return new PartitionTransition(PartitionType.Take, s.Args[1]);
        }

        #endregion


        #region Element operations
        
        protected override IEnumerable<ITransition> ParseFirst(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.First, false);
        }

        protected override IEnumerable<ITransition> ParseLast(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.Last, false);
        }

        protected override IEnumerable<ITransition> ParseSingle(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.Single, false);
        }


        protected override IEnumerable<ITransition> ParseFirst2(MethodParseSubject s) {
            yield return new FilterTransition((LambdaExpression)((UnaryExpression)s.Args[1]).Operand);
            yield return new ElementTransition(ElementTransitionType.First, false);
        }

        protected override IEnumerable<ITransition> ParseLast2(MethodParseSubject s) {
            yield return new FilterTransition((LambdaExpression)((UnaryExpression)s.Args[1]).Operand);
            yield return new ElementTransition(ElementTransitionType.Last, false);
        }

        protected override IEnumerable<ITransition> ParseSingle2(MethodParseSubject s) {
            yield return new FilterTransition((LambdaExpression)((UnaryExpression)s.Args[1]).Operand);
            yield return new ElementTransition(ElementTransitionType.Single, false);
        }



        protected override IEnumerable<ITransition> ParseElementAt(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.ElementAt, false, s.Args[1]);
        }

        protected override IEnumerable<ITransition> ParseFirstOrDefault(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.First, true);
        }

        protected override IEnumerable<ITransition> ParseLastOrDefault(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.Last, true);
        }

        protected override IEnumerable<ITransition> ParseSingleOrDefault(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.Single, true);
        }

        protected override IEnumerable<ITransition> ParseElementAtOrDefault(MethodParseSubject s) {
            yield return new ElementTransition(ElementTransitionType.ElementAt, true, s.Args[1]);
        }




        protected override IEnumerable<ITransition> ParseFirstOrDefault2(MethodParseSubject s) {
            yield return new FilterTransition((LambdaExpression)((UnaryExpression)s.Args[1]).Operand);
            yield return new ElementTransition(ElementTransitionType.First, true);
        }

        protected override IEnumerable<ITransition> ParseLastOrDefault2(MethodParseSubject s) {
            yield return new FilterTransition((LambdaExpression)((UnaryExpression)s.Args[1]).Operand);
            yield return new ElementTransition(ElementTransitionType.Last, true);
        }

        protected override IEnumerable<ITransition> ParseSingleOrDefault2(MethodParseSubject s) {
            yield return new FilterTransition((LambdaExpression)((UnaryExpression)s.Args[1]).Operand);
            yield return new ElementTransition(ElementTransitionType.Single, true);
        }


        #endregion





    }
}
