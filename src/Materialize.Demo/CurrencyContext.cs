using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo
{

    class CurrencyContext
    {
        public Currency ActiveCurrency { get; private set; }

        public void SetActiveCurrency(Currency currency) {
            ActiveCurrency = currency;
        }
    }

}
