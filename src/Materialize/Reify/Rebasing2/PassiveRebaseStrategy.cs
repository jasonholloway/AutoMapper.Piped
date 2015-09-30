using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    class PassiveRebaseStrategy : IRebaseStrategy
    {
        public PassiveRebaseStrategy(Type type) {
            TypeVector = new TypeVector(type, type);
        }
        
        public TypeVector TypeVector { get; private set; }

        public IRebaseStrategy Expand(Expression exSubject) {
            return null;
        }

        public IRebaseStrategy GetRootStrategy(RootVector roots) {
            return null;
        }

        public Expression Rebase(Expression exSubject) {
            return exSubject;
        }
    }
}
