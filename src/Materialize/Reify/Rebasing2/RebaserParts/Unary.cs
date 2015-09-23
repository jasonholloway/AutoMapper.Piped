using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class Rebaser 
    {
        protected override Rebased VisitUnary(UnaryExpression unary) 
        {
            var exOperand = Visit(unary.Operand).Expression;

            return Rebased.Passive(
                            Expression.MakeUnary(unary.NodeType, exOperand, unary.Type)
                            );
        }
    }
}
