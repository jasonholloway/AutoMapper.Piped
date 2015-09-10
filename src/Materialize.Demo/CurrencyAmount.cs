using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo
{

    struct CurrencyAmount
    {
        readonly CurrencyContext _currencyCtx;
        readonly decimal _baseAmount;

        public decimal BaseAmount {
            get { return _baseAmount; }
        }

        public decimal LocalAmount {
            get { return _baseAmount * _currencyCtx.ActiveCurrency.Ratio; }
        }


        public CurrencyAmount(CurrencyContext currencyCtx, decimal baseAmount) {
            _currencyCtx = currencyCtx;
            _baseAmount = baseAmount;
        }


        public override string ToString() {
            return string.Format(
                            _currencyCtx.ActiveCurrency.Format,
                            LocalAmount
                            );
        }

    }
    

}
