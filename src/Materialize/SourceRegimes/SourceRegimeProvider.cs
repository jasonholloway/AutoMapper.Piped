using System.Linq;

namespace Materialize.SourceRegimes
{
    class SourceRegimeProvider : ISourceRegimeProvider 
    {
        ISourceRegimeProvider[] _regimeProvs = new ISourceRegimeProvider[] {
                                                        new EnumerableQueryRegimeProvider(),
                                                        //new EF6Regime(), //unimplemented for now...
                                                        new MinimalRegimeProvider()
                                                    };
        
        public ISourceRegime GetRegime(IQueryable qySource) {
            return _regimeProvs
                        .Select(p => p.GetRegime(qySource))
                        .First(r => r != null);
        }
    }
}
