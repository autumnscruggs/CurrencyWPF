using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.USCurrency
{
    public class Penny : USCoin
    {
        public Penny() : this(USCoinMintMark.D) { }
        public Penny(USCoinMintMark mark) : base(mark)
        {
            this.Name += " Penny";
            this.MonetaryValue = .01;
        }
    }
}
