using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Materialize.SourceRegimes;
using Materialize.Reify.Mapping;

namespace Materialize.Reify
{
    internal class ReifiableFactory
    {        
        public IReifiable<TDest> CreateReifiable<TDest>(IQueryable qySource) 
        {
            var tOrig = qySource.ElementType;
            var tDest = typeof(TDest);

            //test source regime
            var regimeDetector = new SourceRegimeDetector();
            var regime = regimeDetector.DetectRegime(qySource.Provider);
            
            //TO-DO!!!!
            //Strategies should also be keyed by source regime!
            //RegimeDetector & StrategyProvider should be supplied somehow...
            //...
            
            //get mapping strategy
            var mapStrategySource = new MapStrategyProvider();
            Func<IMapStrategy> fnMapStrategy = () => mapStrategySource.GetStrategy(tOrig, tDest);
            
            //construct and return nicely-typed reifiable
            return (IReifiable<TDest>)Activator.CreateInstance(
                                                    typeof(Reifiable<,>)
                                                                .MakeGenericType(tOrig, tDest),
                                                    qySource,
                                                    fnMapStrategy);
        }

    }
}
