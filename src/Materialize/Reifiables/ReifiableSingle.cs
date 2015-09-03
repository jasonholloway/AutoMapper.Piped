using Materialize.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reifiables
{
    abstract class ReifiableSingle : Reifiable
    {
        public static ReifiableSingle Create(IQueryProvider queryProv, Expression queryExp, Type tDest) 
        {
            //should cache all this by type vector - ie compiled ctor
            //...

            var tOrig = queryExp.Type;

            var rootStrategy = StrategySource.Default.GetStrategy(tOrig, tDest);

            var tProj = rootStrategy.ProjectedType;

            return (ReifiableSingle)Activator.CreateInstance(
                                                    typeof(ReifiableSingle<,,>).MakeGenericType(tOrig, tProj, tDest),
                                                    queryProv,
                                                    queryExp,
                                                    rootStrategy
                                                    );
        } 
    }


    class ReifiableSingle<TOrig, TProj, TDest>
        : ReifiableSingle
    {
        readonly IQueryable<TOrig> _qyOrig;
        readonly Func<Expression, Expression> _fnModifyExp;
        readonly IStrategy<TOrig, TDest> _rootStrategy;
        readonly Lazy<TDest> _lzReified;

        public ReifiableSingle(
            IQueryable<TOrig> qyOrig,
            Func<Expression, Expression> fnModifyExp,
            IStrategy<TOrig, TDest> rootStrategy) 
        {
            _qyOrig = qyOrig;
            _fnModifyExp = fnModifyExp;
            _rootStrategy = rootStrategy;
            _lzReified = new Lazy<TDest>(Reify);
        }


        public override bool IsCompleted {
            get { return _lzReified.IsValueCreated; }
        }

        public override object Result {
            get { return _lzReified.Value; }
        }


        public override IQueryProvider QueryProvider {
            get { return _queryProv; }
        }

        public override Expression QueryExpression {
            get { return _queryExp; }
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



        TDest Reify() {
            var reifier = _rootStrategy.CreateReifier();

            //NAH! We are more connected with previous expression than we like to think...

            //As is, reifier will just select from whatever is in exp

            //Exp needs to be in two: the spatial functions, which can be projected, then the determinant question at the end, reducing to scalar


            var projExp = reifier.Project();



            throw new NotImplementedException();
        }
        
    }

}
