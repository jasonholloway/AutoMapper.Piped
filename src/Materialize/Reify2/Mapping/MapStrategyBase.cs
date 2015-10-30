using System;
using Materialize.Reify2.Rebasing;
using System.Collections.Generic;
using System.Linq;
using Materialize.Types;

namespace Materialize.Reify2.Mapping
{
    abstract class MapStrategyBase<TOrig, TDest> 
        : IMapStrategy
    {
        public Type SourceType {
            get { return typeof(TOrig); }
        }
        
        public abstract Type FetchType { get; }

        public Type TransformedType {
            get { return typeof(TDest); }
        }
                

        public bool FetchesToTuple {  //?????????
            get { return FetchType != TransformedType; }
        }
        
        public virtual bool RewritesExpression {
            get { return true; }
        }
        
        public abstract IMapper CreateWriter();
                 

        public virtual IRebaseStrategy GetRootRebaseStrategy(RootVector roots) {
            throw new RebaseRootException(
                            "{0} can't supply IRebaseStrategy for root vector ({1} -> {2})!", 
                            this.GetType().GetNiceName(),
                            roots.OrigRoot.Type.GetNiceName(),
                            roots.RebasedRoot.Type.GetNiceName());
        }
            
    }

}