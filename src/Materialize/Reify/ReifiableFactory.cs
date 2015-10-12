﻿using System;
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
        Options _baseOptions;

        public ReifiableFactory(
            ISourceRegimeProvider regimeSource,
            ParserFactory parserFac,
            Options baseOptions) 
        {
            _regimeSource = regimeSource;
            _parserFac = parserFac;
            _baseOptions = baseOptions;
        }


        public IReifiable<TDest> CreateReifiable<TDest>(IQueryable qySource, Options options) 
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
