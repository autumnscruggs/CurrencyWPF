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
using System.Windows.Shapes;

namespace CurrencyMidterm.Windows
{
    /// <summary>
    /// Interaction logic for RepoWindow.xaml
    /// </summary>
    public partial class RepoWindow : Window
    {
        private StaticSaveAndLoadRepoViewModel saveRepoViewModel;
        private StaticRepoViewModel repoViewModel;

        public RepoWindow()
        {
            InitializeComponent();
            saveRepoViewModel = new StaticSaveAndLoadRepoViewModel();
            repoViewModel = new StaticRepoViewModel();
        }

        private void RepoView1_Loaded(object sender, RoutedEventArgs e)
        {
            RepoView1.DataContext = repoViewModel;
        }

        private void SaveAndLoadRepoView1_Loaded(object sender, RoutedEventArgs e)
        {
            SaveAndLoadRepoView1.DataContext = saveRepoViewModel;
            saveRepoViewModel.CoinNum = 1;
            SaveAndLoadRepoView1.CoinComboBox.SelectedIndex = 0;
            saveRepoViewModel.SelectedCoin = USCurrencyRepo.PossibleCoins[0];
        }
    }
}
