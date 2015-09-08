﻿using Materialize.Reify.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping
{
    abstract class StrategyBase<TOrig, TDest>
        : IMapStrategy //<TOrig, TDest>
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
