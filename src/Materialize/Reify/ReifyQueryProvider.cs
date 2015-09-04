using Materialize.Reify.Mods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{
    class ReifyQueryProvider<TSource, TDest> : IQueryProvider
    {
        IQueryable<TSource> _sourceQuery;
        IMod _baseMod;

        public ReifyQueryProvider(IQueryable<TSource> sourceQuery, IMod baseMod) {
            _sourceQuery = sourceQuery;
            _baseMod = baseMod;
        }




        public IQueryable CreateQuery(Expression expression) {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            return new ReifyQuery<TElement>(this, expression);
        }

        public object Execute(Expression expression) {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression) 
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //get fully-strategised MappingMod...
            var mapper = new MapperMod<int, int>();

            var stMods = new Stack<IMod>(new[] { mapper });
            
            var modEmitter = new ModEmittingQueryVisitor(null, mod => stMods.Push(mod));
            modEmitter.Visit(expression);





            //with yer stack of mods, now construct ReifyExecutor

            

            throw new NotImplementedException();
        }
    }






}
