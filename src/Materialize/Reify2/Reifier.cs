using Materialize.Reify2.Compiling;
using Materialize.Reify2.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2
{
    internal class Reifier
    {
        public Expression CanonicalQuery { get; private set; }        
        
        protected ParamMap ParamMap { get; private set; }
        protected Func<Expression, object> Executor { get; private set; }


        public object Execute(Expression exQuery) 
        {
            //extract constant values, and feed in to Executor

            var argValues = ParamMap.Accessors
                                    .Select(ac => ((ConstantExpression)ac(exQuery)).Value);


            //get argmap

            throw new NotImplementedException();


            //return Executor(args);
        }



        public Reifier(Expression exCanonicalQuery, Func<Expression, object> fnExecutor) 
        {
            CanonicalQuery = exCanonicalQuery;
            Executor = fnExecutor;
        }




    }
}
