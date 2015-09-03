using Materialize.Reifiables;
using System.Linq;

namespace Materialize
{
    public static class QueryableExtensions
    {        
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qyOrig) 
        {
            return (IMaterializable<TDest>)ReifiableSeries.Create(qyOrig, typeof(TDest));      
        }

    }
}
