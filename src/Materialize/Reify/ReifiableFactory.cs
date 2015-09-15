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
        IMapStrategySource _mapStrategySource;
        IParseStrategySource _parseStrategySource;


        public ReifiableFactory(
            ISourceRegimeDetector regimeDetector,
            IMapStrategySource mapStrategySource,
            IParseStrategySource parseStrategySource) 
        {
            _regimeDetector = regimeDetector;
            _mapStrategySource = mapStrategySource;
            _parseStrategySource = parseStrategySource;
        }



        public IReifiable<TDest> CreateReifiable<TDest>(IQueryable qySource) 
        {
            var tOrig = qySource.GetType();
            var tOrigElem = qySource.ElementType;

            var tDest = typeof(IEnumerable<TDest>);
            var tDestElem = typeof(TDest);
            
            var regime = _regimeDetector.DetectRegime(qySource.Provider);
            
            Func<IMapStrategy> fnMapStrategy = () => _mapStrategySource
                                                            .GetStrategy(regime, tOrig, tDest);
            
            //construct and return nicely-typed reifiable
            return (IReifiable<TDest>)Activator.CreateInstance(
                                                    typeof(Reifiable<,>)
                                                                .MakeGenericType(tOrigElem, tDestElem),
                                                    qySource,
                                                    fnMapStrategy,
                                                    _parseStrategySource);
        }

    }
}
