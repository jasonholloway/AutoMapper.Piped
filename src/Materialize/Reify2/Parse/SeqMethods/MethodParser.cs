﻿using Materialize.Reify2.Transitions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parse.SeqMethods
{
    static class MethodParser
    {
        public static IEnumerable<Transition> Parse(ParseSubject s) 
        {
            Debug.Assert(s.SubjectExp is MethodCallExpression);
            Debug.Assert(s.Method.IsStatic);
            Debug.Assert(s.Method.GetParameters().First().ParameterType.IsQueryable());

            //pass upwards 
            var upstreamSubject = s.Spawn(s.CallExp.Arguments[0]);
            var upstreamTrans = Parser.Parse(upstreamSubject);

            IEnumerable<Transition> result;

            if(s.Method.DeclaringType == typeof(Queryable)) {
                result = QyParser.Parse(s);
            }
            else if(s.MethodDef == QyMethods.MapAs) {
                result = MapAsParser.Parse(s);
            }
            else {
                throw new InvalidOperationException();
            }

            return upstreamTrans.Concat(result);
        }
                
    }
}
