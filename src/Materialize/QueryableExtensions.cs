using Materialize.Reify2;
using Materialize.Types;
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


        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source, ISnooper snooper) {
            return source.MapAs<TDest>(new MaterializeOptions() {
                Snooper = snooper
            });
        }


        public static IQueryable<TDest> MapAs<TDest>(this IQueryable source, MaterializeOptions options) 
        {
            var reifiableFac = MaterializeServices.Resolve<ReifiableFactory>();

            var reifiable = reifiableFac.CreateReifiable(source, options);

            return reifiable.CreateQuery<TDest>(
                                    Expression.Call(
                                            QueryableMethods.MapAs.MakeGenericMethod(typeof(TDest)),
                                            source.Expression
                                        ));
        }
        

    }
}
