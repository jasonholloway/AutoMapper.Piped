using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo
{

    class CurrencyContext
    {
        public static readonly CurrencyContext Default = new CurrencyContext();
        

        public Currency ActiveCurrency { get; private set; }
                
        public CurrencyContext() {
            SetActiveCurrency(new Currency("Pound", "£{0:N}", 0.65M));
        }

        public void SetActiveCurrency(Currency currency) {
            ActiveCurrency = currency;
        }


    }

}
