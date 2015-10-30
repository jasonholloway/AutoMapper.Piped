using Materialize.Reify2.Params;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{
    internal class SourceTransition : TransitionBase
    {
        public Expression CanonicalExpression { get; private set; }        
        public Type ElemType { get; private set; }

        public SourceTransition(ISourceRegime regime, Expression exCanonical)
            : base(TransitionType.Source) 
        {
            Debug.Assert(exCanonical.Type.IsQueryable());
            
            OutRegime = regime;
            ElemType = exCanonical.Type.GetEnumerableElementType();
            CanonicalExpression = exCanonical;
        }
        
                
        public override string ToString() {
            return $"Source [{ElemType.GetNiceName()}]";
        }
    }
    
}
