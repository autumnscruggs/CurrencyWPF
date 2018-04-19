using CurrencyLibrary;
using CurrencyLibrary.USCurrency;
using CurrencyMidterm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyMidterm.Views.Coins
{
    /// <summary>
    /// Interaction logic for Coin.xaml
    /// </summary>
    public partial class CoinView : UserControl
    {
        public Coin Coin { get; private set; }

        public CoinView(Coin coin)
        {
            InitializeComponent();
            Coin = coin;
            CoinViewModel viewModel = new CoinViewModel(coin);
            this.DataContext = viewModel;
        }

        public CoinView(USCoin coin)
        {
            InitializeComponent();
            Coin = coin;
            USCoinViewModel viewModel = new USCoinViewModel(coin);
            this.DataContext = viewModel;
        }
    }
}
