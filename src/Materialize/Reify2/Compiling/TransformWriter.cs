﻿using Materialize.Reify2.Operations;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Compiling
{
    internal static class TransformWriter
    {

        public static Expression Write(Expression exInput, IEnumerable<IOperation> steps) {
            return steps.Aggregate(exInput, (acc, step) => WriteStep(acc, (dynamic)step));
        }
        
        
        static Expression WriteStep(Expression exPrev, ProjectorOp s) {
            return Expression.Call(
                            EnumerableMethods.Select.MakeGenericMethod(s.InElemType, s.OutElemType),
                            exPrev,
                            s.Projection);
        }


        static Expression WriteStep(Expression exPrev, FilterOp s) {
            return Expression.Call(
                            EnumerableMethods.Where.MakeGenericMethod(s.ElemType),
                            exPrev,
                            s.Predicate);
        }





    }
}
