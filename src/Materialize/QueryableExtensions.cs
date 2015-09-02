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
        public static IMaterializable<TDest> MaterializeAs<TDest>(this IQueryable qyOrig) 
        {
            return Materializable.Create<TDest>(qyOrig);            
        }

    }
}
