using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.SourceRegimes;
using Materialize.Reify.Mapping;
using Materialize.Reify.Parsing;

namespace Materialize.Reify
{
    internal class ReifiableFactory
    {
        ISourceRegimeDetector _regimeDetector;
        ParserFactory _parserFac;

        public ReifiableFactory(
            ISourceRegimeDetector regimeDetector,
            ParserFactory parserFac) 
        {
            _regimeDetector = regimeDetector;
            _parserFac = parserFac;
        }


        public IReifiable<TDest> CreateReifiable<TDest>(IQueryable qySource) 
        {
            var tOrigElem = qySource.ElementType;
            var tDestElem = typeof(TDest);
            
            return (IReifiable<TDest>)Activator.CreateInstance(
                                                    typeof(Reifiable<,>)
                                                                .MakeGenericType(tOrigElem, tDestElem),
                                                    qySource,
                                                    _regimeDetector,
                                                    _parserFac);
        }

    }
}
