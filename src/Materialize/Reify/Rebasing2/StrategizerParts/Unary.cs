﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer 
    {
        protected override IRebaseStrategy VisitUnary(UnaryExpression exUnary) 
        {
            var strOperand = Visit(exUnary.Operand);

            if(strOperand is PassiveRebaseStrategy) {
                return PassiveStrategy(exUnary.Type);
            }
            
            return Strategy(
                        strOperand.TypeVector,
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
