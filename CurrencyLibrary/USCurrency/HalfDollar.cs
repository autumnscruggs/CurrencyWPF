using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.USCurrency
{
    public class HalfDollar : USCoin
    {
        public HalfDollar() : this(USCoinMintMark.D) { }
        public HalfDollar(USCoinMintMark mark) : base(mark)
        {
            this.Name += " Half Dollar";
            this.MonetaryValue = .50;
        }
    }
}
