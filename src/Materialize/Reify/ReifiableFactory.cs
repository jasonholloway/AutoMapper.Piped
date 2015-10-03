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
        ISourceRegimeProvider _regimeSource;
        ParserFactory _parserFac;

        public ReifiableFactory(
            ISourceRegimeProvider regimeSource,
            ParserFactory parserFac) 
        {
            _regimeSource = regimeSource;
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
                                                    _regimeSource,
                                                    _parserFac);
        }

    }
}
