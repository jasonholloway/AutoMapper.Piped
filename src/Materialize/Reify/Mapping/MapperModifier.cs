using Materialize.Reify.Modifiers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Mapping
{    

    abstract class MapperModifier<TOrig, TMed, TDest>
        : IModifier
    {        
        public abstract Expression Rewrite(Expression exSource);
        protected abstract TDest Transform(TMed fetched);

        object IModifier.Transform(object fetched) {
            return Transform((TMed)fetched);
        }

    }


}
