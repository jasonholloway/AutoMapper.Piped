using Materialize.Reify;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize
{
    public static class QueryableExtensions
    {

        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source) {
            return source.MapAs<TDest>(new Options());
        }

        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source, Options options) 
        {
            var reifiableFac = MaterializeServices.Resolve<ReifiableFactory>();

            var reifiable = reifiableFac.CreateReifiable<TDest>(source, options);

            return reifiable.BaseReifyQuery;
        }




        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source, ISnooper snooper) 
        {
            return source.MapAs<TDest>(new Options() {
                                                Snooper = snooper
                                                });
            
            //var reifiableFac = MaterializeServices.Resolve<ReifiableFactory>();

            //var reifiable = reifiableFac.CreateReifiable<TDest>(source);
            
            //if(snooper != null) {
            //    reifiable.QueryFromClient += new EventHandler<Expression>((o, ex) => snooper.OnQueryFromClient(ex));
            //    reifiable.Strategized += new EventHandler<IReifyStrategy>((o, s) => snooper.OnStrategized(s));
            //    reifiable.QueryToServer += new EventHandler<IQueryable>((o, qy) => snooper.OnQueryToServer(qy));
            //    reifiable.Fetched += new EventHandler<IEnumerable>((o, en) => snooper.OnFetched(en));
            //    reifiable.Transformed += new EventHandler<IEnumerable>((o, en) => snooper.OnTransformed(en));
            //}
            
            //return reifiable.BaseReifyQuery;
        }



    }
}
