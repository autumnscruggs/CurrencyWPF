using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.USCurrency
{
    public class DollarCoin : USCoin
    {
        public DollarCoin() : this(USCoinMintMark.D) { }
        public DollarCoin(USCoinMintMark mark) : base(mark)
        {
            this.Name += " Dollar Coin";
            this.MonetaryValue = 1.00;
        }
    }
}
