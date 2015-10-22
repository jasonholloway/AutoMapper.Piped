using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Rebasing
{
    struct RootVector
    {
        public readonly Expression OrigRoot;
        public readonly Expression RebasedRoot;
        
        public RootVector(
            Expression origRoot,
            Expression rebasedRoot) 
        {
            OrigRoot = origRoot;
            RebasedRoot = rebasedRoot;
        }
        
        public TypeVector TypeVector {
            get { return new TypeVector(OrigRoot.Type, RebasedRoot.Type); }
        }
    }

}
