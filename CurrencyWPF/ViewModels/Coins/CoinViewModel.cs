using CurrencyLibrary;
using CurrencyMidterm.Views.Coins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CurrencyMidterm.ViewModels
{
    public class CoinViewModel : BaseViewModel
    {
        public Coin Coin { get; protected set; }

        public Brush CoinColor
        {
            get  {  return CoinColorFromCoinType(); }
        }
        public string Name
        {
            get { return Coin.Name; }
        }
        public double MonetaryValue
        {
            get { return Coin.MonetaryValue; }
        }
        public string FormattedCoinString
        {
            get { return FormattedCoinStringFromMonetaryValue(); }
        }

        public CoinViewModel(Coin c)
        {
            Coin = c;
        }

        protected virtual Brush CoinColorFromCoinType()
        {
            return new SolidColorBrush(Colors.White);
        }

        protected virtual string FormattedCoinStringFromMonetaryValue()
        {
            return "25¢";
        }
    }
}
