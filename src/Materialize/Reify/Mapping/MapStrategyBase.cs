﻿using System;
using Materialize.Reify.Rebasing;
using Materialize.Reify.Parsing;

namespace Materialize.Reify.Mapping
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
        
        public abstract IModifier CreateModifier();
                 

        public virtual IRebaseStrategy GetRootRebaseStrategy(RootVector roots) {
            return null; // throw new NotImplementedException(); //should return null or throw more precisely-typed exception...
        }
    }

}
