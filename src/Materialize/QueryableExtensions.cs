using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JH.DynaType;
using System.Linq.Expressions;
using System.Collections;

namespace Materialize
{    
    public static class QueryableExtensions
    {        
        public static IEnumerable<TDest> MaterializeAs<TDest>(this IQueryable qyOrig) 
        {
            var tOrig = qyOrig.ElementType;
            var tDest = typeof(TDest);

            var reifier = ReifierSource.Default.GetReifier(tOrig, tDest);

            var exNew = reifier.Map(qyOrig.Expression);
            var qyNew = qyOrig.Provider.CreateQuery(exNew);
            
            //var data = ((IEnumerable)qyNew).Cast<object>().ToArray();


            var reformed = reifier.Reform(qyNew);

            return ((IEnumerable<TDest>)reformed);
        }

    }
}
