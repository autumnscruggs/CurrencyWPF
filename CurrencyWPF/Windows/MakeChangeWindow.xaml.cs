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
using System.Windows.Shapes;

namespace CurrencyMidterm.Windows
{
    /// <summary>
    /// Interaction logic for MakeChange.xaml
    /// </summary>
    public partial class MakeChangeWindow : Window
    {
        public MakeChangeWindow()
        {
            InitializeComponent();
        }

        private void MakeChangeView1_Loaded(object sender, RoutedEventArgs e)
        {
            //USCurrencyRepo changeRepo = new USCurrencyRepo();
            RepoViewModel repoModel = new RepoViewModel(StaticInformation.MainRepo);
            this.MakeChangeView1.DataContext = new MakeChangeViewModel(StaticInformation.MainRepo, repoModel);
            this.MakeChangeView1.ChangeRepoView.DataContext = repoModel;
        }
    }
}
