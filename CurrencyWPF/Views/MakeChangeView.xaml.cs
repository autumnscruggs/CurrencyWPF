using CurrencyMidterm.ViewModels;
using CurrencyMidterm.Views.Coins;
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

namespace CurrencyMidterm.Views
{
    /// <summary>
    /// Interaction logic for MakeChangeView.xaml
    /// </summary>
    public partial class MakeChangeView : UserControl
    {
        public MakeChangeView()
        {
            InitializeComponent();
        }

        private void ChangeRepoView_Loaded(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("ChangeRepoView.DataContext // " + ChangeRepoView.DataContext);
        }
    }
}
