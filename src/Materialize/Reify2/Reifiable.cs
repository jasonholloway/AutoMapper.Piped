using Materialize.Expressions;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Mapping;
using Materialize.Reify2.Parameterize;
using Materialize.Reify2.Parsing2;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify2
{
    //Reifiables are mostly QueryProviders, serving ReifyQueries
    //As such, they orchestrate query-parsing, fetching and transformation, via a stack of modifiers.

    interface IReifiable : IQueryProvider
    { }


    class Reifiable<TElem> : IReifiable
    {
        ISourceRegimeProvider _regimeSourceProv;
        MapperSource _mapperWriterSource;
        MaterializeOptions _options;
        ISnooper _snoop;        
        IQueryable<TElem> _qySource;
        

        public Reifiable(
            IQueryable<TElem> sourceQuery, 
            ISourceRegimeProvider regimeSourceProv,
            MapperSource mapperWriterSource,
            MaterializeOptions options)
        {
            _qySource = sourceQuery;

            _regimeSourceProv = regimeSourceProv;
            _mapperWriterSource = mapperWriterSource;
            _options = options;
            _snoop = options.Snooper;
        }
        


        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) 
        {
            return typeof(IOrderedQueryable).IsAssignableFrom(expression.Type)
                    ? new OrderedReifyQuery<TElement>(this, expression)
                    : new ReifyQuery<TElement>(this, expression);            
        }


        public IQueryable CreateQuery(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }

                
        


        public TResult Execute<TResult>(Expression exQuery) 
        {
            if(!exQuery.Contains(_qySource.Expression)) {
                throw new InvalidOperationException("Bad query expression passed to Reifiable.Execute!");
            }

            _snoop?.Event("Incoming query", exQuery);
            
            var ctx = new ReifyContext(
                            _options.MappingEngine,
                            _options.SourceRegime ?? _regimeSourceProv.GetRegime(_qySource),
                            _mapperWriterSource,
                            _options.AllowClientSideFiltering ?? false,
                            _snoop);


            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //CACHEING HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                                
            var reifier = ReifierFactory.Build(exQuery, ctx, _qySource.Expression);

            
            var result = (TResult)reifier.Execute(_qySource.Provider, exQuery);

            _snoop?.Event("Result", result);

            return result;
        }



        public object Execute(Expression expression) {
            //Just delegate via refl to typed method...
            throw new NotImplementedException();
        }
        

    }

}
