using Materialize.Reify2.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parse.Source
{
    static class SourceParser
    {
        public static IEnumerable<Transition> Parse(ParseSubject s) {
            var regime = s.ReifyContext.SourceRegime;
            yield return new SourceTransition(regime, s.SubjectExp);
        }
    }
}
