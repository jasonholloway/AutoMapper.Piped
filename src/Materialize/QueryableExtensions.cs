using Materialize.Reify;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize
{
    public static class QueryableExtensions
    {
        static ReifiableFactory _reifiableFac = new ReifiableFactory();        
            
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qySource) 
        {
            var reifiable = _reifiableFac.CreateReifiable<TDest>(qySource);
            
            return new Materializable<TDest>(
                                reifiable.BaseReifyQuery);                                       
        }
    }
}
