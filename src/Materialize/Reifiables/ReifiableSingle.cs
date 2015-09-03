using Materialize.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reifiables
{
    abstract class ReifiableSingle : Reifiable
    {
        public static ReifiableSingle Create(
            ReifiableSeries series,
            Func<Expression, Expression> fnModifyProjection) 
        {
            return (ReifiableSingle)Activator.CreateInstance( //could be compiled...
                                                typeof(ReifiableSingle<,,>)
                                                        .MakeGenericType(series.OrigType, series.ProjType, series.DestType),
                                                series,
                                                fnModifyProjection);            
        } 
    }


    class ReifiableSingle<TOrig, TProj, TDest>
        : ReifiableSingle
    {
        ReifiableSeries<TOrig, TProj, TDest> _parentSeries;        
        Func<Expression, Expression> _fnModifyExp;
        Lazy<TDest> _lzReified;

        public ReifiableSingle(
            ReifiableSeries<TOrig, TProj, TDest> parentSeries,
            Func<Expression, Expression> fnModifyExp) 
        {
            _parentSeries = parentSeries;
            _fnModifyExp = fnModifyExp;
            _lzReified = new Lazy<TDest>(Reify);
        }


        public override bool IsCompleted {
            get { return _lzReified.IsValueCreated; }
        }

        public override object Result {
            get { return _lzReified.Value; }
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
            return (TDest)_parentSeries.Reify(_fnModifyExp);
        }
        
    }

}
