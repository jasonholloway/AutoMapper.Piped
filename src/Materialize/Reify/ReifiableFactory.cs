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
        //IMapStrategySource _mapStrategies;
        //IParseStrategySource _parseStrategies;
        ParserFactory _parserFac;

        public ReifiableFactory(
            ISourceRegimeDetector regimeDetector,
            ParserFactory parserFac) 
        {
            _regimeDetector = regimeDetector;
            _parserFac = parserFac;
            //_mapStrategies = mapStrategies;
            //_parseStrategies = parseStrategies;
        }



        public IReifiable<TDest> CreateReifiable<TDest>(IQueryable qySource) 
        {
            var tOrig = qySource.GetType();
            var tOrigElem = qySource.ElementType;

            var tDest = typeof(IEnumerable<TDest>);
            var tDestElem = typeof(TDest);

            //var regime = _regimeDetector.DetectRegime(qySource.Provider);

            //Func<IMapStrategy> fnMapStrategy = () => _mapStrategies
            //                                                .GetStrategy(regime, tOrig, tDest);

            //construct and return nicely-typed reifiable
            return (IReifiable<TDest>)Activator.CreateInstance(
                                                    typeof(Reifiable<,>)
                                                                .MakeGenericType(tOrigElem, tDestElem),
                                                    qySource,
                                                    _regimeDetector,
                                                    _parserFac);

                                                    //fnMapStrategy,
                                                    //_parseStrategies);
        }

    }
}
