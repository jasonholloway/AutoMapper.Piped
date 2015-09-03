using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies
{
    abstract class StrategyBase<TOrig, TDest>
        : IStrategy<TOrig, TDest>
    {
        public Type SourceType {
            get { return typeof(TOrig); }
        }
        
        public abstract Type ProjectedType { get; }

        public Type TransformedType {
            get { return typeof(TDest); }
        }
        

        public bool UsesIntermediateType {  //?????????
            get { return ProjectedType != TransformedType; }
        }


        public abstract IReifier<TOrig, TDest> CreateReifier();

        IReifier IStrategy.CreateReifier() {
            return CreateReifier();
        }
    }

}
