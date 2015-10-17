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
            return source.MapAs<TDest>(new MaterializeOptions());
        }


        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source, MaterializeOptions options) 
        {
            var reifiableFac = MaterializeServices.Resolve<ReifiableFactory>();

            var reifiable = reifiableFac.CreateReifiable<TDest>(source, options);

            return reifiable.BaseReifyQuery;
        }




        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source, ISnooper snooper) 
        {
            return source.MapAs<TDest>(new MaterializeOptions() {
                                                Snooper = snooper
                                                });
        }



    }
}
