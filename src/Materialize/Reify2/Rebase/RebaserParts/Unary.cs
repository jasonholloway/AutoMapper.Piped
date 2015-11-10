using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Rebase
{
    partial class Rebaser 
    {
        protected override IRebaseStrategy VisitUnary(UnaryExpression exUnary) 
        {
            var strOperand = Visit(exUnary.Operand);
            
            return UnrootedStrategy(
                        strOperand.TypeVector, //does it make sense for unrooted strat to have type vector???
                        (UnaryExpression x) => {
                            var exRebasedOperand = strOperand.Rebase(x.Operand);

                            return Expression.MakeUnary(
                                                exUnary.NodeType,
                                                exRebasedOperand,
                                                exRebasedOperand.Type);
                        });
        }
    }
}
