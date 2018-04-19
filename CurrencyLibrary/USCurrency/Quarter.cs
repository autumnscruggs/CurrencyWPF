using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.USCurrency
{
    public class Quarter : USCoin
    {
        public Quarter() : this(USCoinMintMark.D) { }
        public Quarter(USCoinMintMark mark) : base(mark)
        {
            this.Name += " Quarter";
            this.MonetaryValue = .25;
        }
    }
}
