using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Rebase
{
    partial class Rebaser 
    {
        protected override IRebaseStrategy VisitBinary(BinaryExpression exBinary) 
        {
            var strLeft = Visit(exBinary.Left);
            var strRight = Visit(exBinary.Right);
            
            switch(exBinary.NodeType) {
                case ExpressionType.Coalesce:
                    throw new NotImplementedException();

                case ExpressionType.ArrayIndex:
                    throw new NotImplementedException();

                default:
                    return UnrootedStrategy(
                                new TypeVector(exBinary.Type, exBinary.Type),
                                (BinaryExpression x) => {
                                    return Expression.MakeBinary(
                                                        x.NodeType,
                                                        strLeft.Rebase(x.Left),
                                                        strRight.Rebase(x.Right));
                                });
            }
                        
        }
    }
}
