﻿using Materialize.Reify;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize
{
    public static class QueryableExtensions
    {
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qySource) 
        {
            var reifiableFac = Services.Resolve<ReifiableFactory>();
            
            var reifiable = reifiableFac.CreateReifiable<TDest>(qySource);
            
            return new Materializable<TDest>(
                                reifiable.BaseReifyQuery);                                       
        }
    }
}
