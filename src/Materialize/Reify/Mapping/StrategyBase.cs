using Materialize.Reify.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping
{
    abstract class StrategyBase<TOrig, TDest>
        : IStrategy //<TOrig, TDest>
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


        public abstract IModifier CreateModifier();
        
    }

}
