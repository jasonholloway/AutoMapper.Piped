using Materialize.Reify2.Compiling;
using Materialize.Reify2.Parameterize;
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
        protected ReifyExecutor Executor { get; private set; }


        public object Execute(IQueryProvider provider, Expression exQuery) 
        {            
            var argMap = ParamMap.CreateArgMap(exQuery);
            
            return Executor.Invoke(provider, argMap);
        }



        public Reifier(Expression exCanonicalQuery, ParamMap paramMap, ReifyExecutor executor) 
        {
            CanonicalQuery = exCanonicalQuery;
            ParamMap = paramMap;
            Executor = executor;
        }




    }
}
