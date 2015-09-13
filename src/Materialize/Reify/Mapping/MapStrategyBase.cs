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
        

        public bool FetchesToTuple {  //?????????
            get { return FetchedType != TransformedType; }
        }
        
        public virtual bool RewritesExpression {
            get { return true; }
        }
        
        public abstract IModifier CreateModifier();
        
    }

}
