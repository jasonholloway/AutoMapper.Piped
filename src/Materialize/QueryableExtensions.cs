﻿using Materialize.Reify;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize
{
    public static class QueryableExtensions
    {
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qySource) 
        {
            var reifiableFac = MaterializeServices.Resolve<ReifiableFactory>();
            
            var reifiable = reifiableFac.CreateReifiable<TDest>(qySource);
            
            return new Materializable<TDest>(
                                reifiable.BaseReifyQuery);                                       
        }





        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source) {
            return source.MapAs<TDest>(null);
        }


        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source, ISnooper snooper) 
        {
            var reifiableFac = MaterializeServices.Resolve<ReifiableFactory>();

            var reifiable = reifiableFac.CreateReifiable<TDest>(source);
            
            if(snooper != null) {
                reifiable.QueryFromClient += new EventHandler<Expression>((o, ex) => snooper.OnQueryFromClient(ex));
                reifiable.QueryToServer += new EventHandler<IQueryable>((o, qy) => snooper.OnQueryToServer(qy));
                reifiable.Fetched += new EventHandler<IEnumerable>((o, en) => snooper.OnFetched(en));
                reifiable.Transformed += new EventHandler<IEnumerable>((o, en) => snooper.OnTransformed(en));
            }
            
            return reifiable.BaseReifyQuery;
        }



    }
}
