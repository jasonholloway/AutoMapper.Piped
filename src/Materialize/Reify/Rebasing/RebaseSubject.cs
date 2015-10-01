using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    struct RebaseSubject
    {
        public readonly Expression Expression;
        public readonly RootVector[] RootVectors;

        public RebaseSubject(
            Expression exp,
            params RootVector[] rootVectors) 
        {
            Expression = exp;
            RootVectors = rootVectors;
        }

    }
}
