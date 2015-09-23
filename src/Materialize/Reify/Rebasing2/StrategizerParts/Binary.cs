﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer 
    {
        protected override IRebaseStrategy VisitBinary(BinaryExpression exBinary) 
        {
            var strLeft = Visit(exBinary.Left);
            var strRight = Visit(exBinary.Right);

            if(strLeft.IsActive || strRight.IsActive) 
            {
                return ActiveStrategy(
                            new TypeVector(exBinary.Type, exBinary.Type),
                            (BinaryExpression x) => {
                                return Expression.MakeBinary(
                                                    x.NodeType,
                                                    strLeft.Rebase(x.Left),
                                                    strRight.Rebase(x.Right));
                            });
            }

            return PassiveStrategy(exBinary.Type);
        }
    }
}
