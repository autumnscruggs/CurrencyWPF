using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.USCurrency
{
    public class Nickel : USCoin
    {
        public Nickel() : this(USCoinMintMark.D) { }
        public Nickel(USCoinMintMark mark) : base(mark)
        {
            this.Name += " Nickel";
            this.MonetaryValue = .05;
        }
    }
}
