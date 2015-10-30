using Materialize.Reify2.Transitions;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify2.Parsing2.Source
{
    class SourceHandler : ParseHandler
    {
        public override IEnumerable<ITransition> Respond() 
        {   
            var regime = Subject.ReifyContext.SourceRegime;
            
            yield return new SourceTransition(regime, Subject.SubjectExp);
        }
    }
}
