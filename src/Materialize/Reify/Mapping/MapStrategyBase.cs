using System;

namespace Materialize.Reify.Mapping
{
    abstract class StrategyBase<TOrig, TDest>
        : IMapStrategy
    {
        public Type SourceType {
            get { return typeof(TOrig); }
        }
        
        public abstract Type FetchedType { get; }

        public Type TransformedType {
            get { return typeof(TDest); }
        }
        

        public bool UsesIntermediateType {  //?????????
            get { return FetchedType != TransformedType; }
        }


        public abstract IModifier CreateModifier();
        
    }

}
