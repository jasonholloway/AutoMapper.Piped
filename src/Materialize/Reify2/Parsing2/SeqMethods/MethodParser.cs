using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parsing2.SeqMethods
{
    static class MethodParser
    {
        static QyMethodParser _qyParser = new QyMethodParser();
        

        public static IEnumerable<ITransition> Parse(ParseSubject s) 
        {
            Debug.Assert(s.SubjectExp is MethodCallExpression);
            Debug.Assert(s.MethodDef.IsStatic);
            Debug.Assert(s.Method.GetParameters().First().ParameterType.IsQueryable());

            //pass upwards 
            var upstreamSubject = s.Spawn(s.CallExp.Arguments[0]);
            var upstreamTrans = Parser.Parse(upstreamSubject);

            IEnumerable<ITransition> result;

            if(s.Method.DeclaringType == typeof(Queryable)) {
                result = _qyParser.Parse(s);
            }
            else if(s.MethodDef == QyMethods.MapAs) {
                result = MapAsParser.Parse(new MethodParseSubject(s));
            }
            else {
                throw new InvalidOperationException();
            }

            return upstreamTrans.Concat(result);
        }
                
    }
}
