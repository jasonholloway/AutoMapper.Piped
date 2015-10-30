using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{

    class ProjectionTransition : TransitionBase
    {

        public LambdaExpression Projection { get; private set; }
        public Type InElemType { get; private set; }
        public Type OutElemType { get; private set; }


        public ProjectionTransition(LambdaExpression exProj) 
            : base(TransitionType.Projector) 
        {
            Debug.Assert(exProj.Parameters.Count == 1);
            Debug.Assert(exProj.ReturnType != typeof(void));
            
            Projection = exProj;
            InElemType = exProj.Parameters[0].Type;
            OutElemType = exProj.ReturnType;     
        }

        
        public override string ToString() {
            return $"Projection [{InElemType.GetNiceName()} -> {OutElemType.GetNiceName()}]";
        }        
    }

        
}
