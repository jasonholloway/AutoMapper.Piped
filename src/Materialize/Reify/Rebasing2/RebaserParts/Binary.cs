using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class Rebaser 
    {
        protected override Rebased VisitBinary(BinaryExpression binary) {  
            var exLeft = Visit(binary.Left).Expression;
            var exRight = Visit(binary.Right).Expression;

            return Rebased.Passive(
                            Expression.MakeBinary(binary.NodeType, exLeft, exRight)
                            );
        }
    }
}
