using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.SourceRegimes;
using Materialize.Reify.Mapping;

namespace Materialize.Reify
{
    internal class ReifiableFactory
    {
        ISourceRegimeDetector _regimeDetector;
        IMapStrategySource _mapStrategySource;


        public ReifiableFactory(
            ISourceRegimeDetector regimeDetector,
            IMapStrategySource mapStrategySource) 
        {
            _regimeDetector = regimeDetector;
            _mapStrategySource = mapStrategySource;
        }



        public IReifiable<TDest> CreateReifiable<TDest>(IQueryable qySource) 
        {
            var tOrig = qySource.ElementType;
            var tDest = typeof(TDest);
            
            var regime = _regimeDetector.DetectRegime(qySource.Provider);
            
            Func<IMapStrategy> fnMapStrategy = () => _mapStrategySource
                                                            .GetStrategy(regime, tOrig, tDest);
            
            //construct and return nicely-typed reifiable
            return (IReifiable<TDest>)Activator.CreateInstance(
                                                    typeof(Reifiable<,>)
                                                                .MakeGenericType(tOrig, tDest),
                                                    qySource,
                                                    fnMapStrategy);
        }

    }
}
