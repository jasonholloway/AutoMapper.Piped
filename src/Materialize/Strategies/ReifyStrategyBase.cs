using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies
{
    abstract class ReifyStrategyBase<TOrig, TDest>
        : IReifyStrategy<TOrig, TDest>
    {
        //public Type SourceType {
        //    get { return typeof(TOrig); }
        //}

        //public virtual Type ProjectType {
        //    get { return typeof(TDest); }
        //}

        //public Type ReformType {
        //    get { return typeof(TDest); }
        //}

        public abstract bool UsesIntermediateType { get; }

        public abstract IReifier<TOrig, TDest> CreateReifier();

        IReifier IReifyStrategy.CreateReifier() {
            return CreateReifier();
        }
    }

}
