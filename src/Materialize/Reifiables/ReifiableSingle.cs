using Materialize.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reifiables
{
    internal class ReifiableSingle<TOrig, TProj, TDest>
        : Reifiable
    {
        readonly IQueryable<TOrig> _qyOrig;
        readonly IStrategy<TOrig, TDest> _rootStrategy;


        public ReifiableSingle(
            IQueryable<TOrig> qyOrig,
            IStrategy<TOrig, TDest> rootStrategy) 
        {
            _qyOrig = qyOrig;
            _rootStrategy = rootStrategy;
        }


        public override bool IsMaterialized {
            get {
                throw new NotImplementedException();
            }
        }

        public override Type OrigType {
            get { return typeof(TOrig); }
        }

        public override Type ProjType {
            get { return typeof(TProj); }
        }

        public override Type DestType {
            get { return typeof(TDest); }
        }



        TDest Materialize() {
            throw new NotImplementedException();
        }


        public override Reifiable SpawnWithModifiedQuery(
            Func<Expression, Expression> fnModifyExpression) 
        {
            throw new NotImplementedException(); //don't think this will ever need implementing...
        }
    }

}
