using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Reify.Rebasing.Root
{
    class RootRule : IRebaseRule
    {
        public IRebaseStrategy GetStrategy(RebaseContext ctx) 
        {
            if(ctx.Subject.Expression == ctx.Subject.Root) {                
                return new RootStrategy(ctx.Map, ctx.NewRoot);
            }

            return null;
        }
    }
}
