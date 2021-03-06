﻿using System;
using Materialize.Reify.Rebasing;
using Materialize.Reify.Parsing;
using System.Collections.Generic;
using System.Linq;
using Materialize.Types;

namespace Materialize.Reify.Mapping
{
    abstract class MapStrategyBase<TOrig, TDest> 
        : ReifyStrategy, IMapStrategy
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
        
        public abstract IModifier CreateModifier();
                 

        public virtual IRebaseStrategy GetRootRebaseStrategy(RootVector roots) {
            throw new RebaseRootException(
                            "{0} can't supply IRebaseStrategy for root vector ({1} -> {2})!", 
                            this.GetType().GetNiceName(),
                            roots.OrigRoot.Type.GetNiceName(),
                            roots.RebasedRoot.Type.GetNiceName());
        }
            
    }

}