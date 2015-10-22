using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.SourceRegimes;
using Materialize.Reify2.Mapping;
using Materialize.Reify2.Parsing;

namespace Materialize.Reify2
{
    internal class ReifiableFactory
    {
        ISourceRegimeProvider _regimeSource;
        ParserFactory _parserFac;
        MaterializeOptions _baseOptions;

        public ReifiableFactory(
            ISourceRegimeProvider regimeSource,
            ParserFactory parserFac,
            MaterializeOptions baseOptions) 
        {
            _regimeSource = regimeSource;
            _parserFac = parserFac;
            _baseOptions = baseOptions;
        }


        public IReifiable<TDest> CreateReifiable<TDest>(IQueryable qySource, MaterializeOptions options) 
        {
            var tOrigElem = qySource.ElementType;
            var tDestElem = typeof(TDest);
            
            return (IReifiable<TDest>)Activator.CreateInstance(
                                                    typeof(Reifiable<,>)
                                                                .MakeGenericType(tOrigElem, tDestElem),
                                                    qySource,
                                                    _regimeSource,
                                                    _parserFac,
                                                    options.MergeWith(_baseOptions));
        }

    }
}
