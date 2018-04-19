using CurrencyLibrary;
using CurrencyLibrary.USCurrency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CurrencyMidterm.ViewModels
{
    public class USCoinViewModel : CoinViewModel
    {
        public USCoinViewModel(Coin c) : base(c)
        {
            Coin = c;
        }

        protected override string FormattedCoinStringFromMonetaryValue()
        {
            if(Coin.MonetaryValue >= 1.00)
            {
                return $"${Coin.MonetaryValue.ToString()}";
            }
            else
            {
                double removeZeroes = Coin.MonetaryValue * 100;
                return $"{removeZeroes}¢";
            }
        }

        protected override Brush CoinColorFromCoinType()
        {
            if(Coin is Penny)
            {
                //COPPER
                return new SolidColorBrush(Colors.Coral);
            }
            else if(Coin is DollarCoin)
            {
                //GOLD
                return new SolidColorBrush(Colors.Gold);
            }
            else
            {
                //SILVER
                return new SolidColorBrush(Colors.Silver);
            }
        }
    }
}
