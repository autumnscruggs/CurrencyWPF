using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.USCurrency
{
    public class Dime : USCoin
    {
        public Dime() : this(USCoinMintMark.D) { }
        public Dime(USCoinMintMark mark) : base(mark)
        {
            this.Name += " Dime";
            this.MonetaryValue = .10;
        }
    }
}
