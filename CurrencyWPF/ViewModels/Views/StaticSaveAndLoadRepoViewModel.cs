using CurrencyLibrary;
using CurrencyLibrary.Serialization;
using CurrencyLibrary.USCurrency;
using CurrencyMidterm.Views.Coins;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyMidterm.ViewModels
{
    public class StaticSaveAndLoadRepoViewModel : StaticRepoViewModel
    {
        public double RepoTotal
        {
            get { return StaticInformation.MainRepo.TotalValue(); }
        }
        public List<USCoin> ComboBoxCoins
        {
            get
            {
                return USCurrencyRepo.PossibleCoins;
            }
        }

        public ICommand NewRepoCommand { get; }
        public ICommand SaveRepoCommand { get; }
        public ICommand LoadRepoCommand { get; }
        public ICommand AddCoinCommand { get; }

        private USCoin selectedCoin;
        public USCoin SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                selectedCoin = value;
                this.RaisePropertyChangedEvent(nameof(SelectedCoin));
            }
        }

        private int coinNum;
        public int CoinNum
        {
            get { return coinNum; }
            set
            {
                coinNum = value;
                this.RaisePropertyChangedEvent(nameof(CoinNum));
            }
        }

        public StaticSaveAndLoadRepoViewModel()
        {
            AddCoinCommand = new BaseCommand(AddCommand);
            SaveRepoCommand = new BaseCommand(SaveCommand);
            LoadRepoCommand = new BaseCommand(LoadCommand);
            NewRepoCommand = new BaseCommand(NewCommand);
        }

      
        private void NewCommand()
        {
            ClearAll();
        }

        protected override void RefreshAll()
        {
            base.RefreshAll();
            this.RaisePropertyChangedEvent(nameof(RepoTotal));
        }

        private void SaveCommand()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = $"{StaticInformation.FileExtensionName} Files (*{StaticInformation.FileExtension})|*{StaticInformation.FileExtension}";
            if (dialog.ShowDialog() == true)
            {
                SerializableCurrencyRepo currencyRepo = new SerializableCurrencyRepo(StaticInformation.MainRepo.Coins);
                SaveAndLoadUtility.Save<SerializableCurrencyRepo>(currencyRepo, dialog.FileName);
            }
        }

        private void LoadCommand()
        {
            SerializableCurrencyRepo loadedRepo = null;

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.DefaultExt = ".bs";
            dialog.Filter = $"{StaticInformation.FileExtensionName} Files (*{StaticInformation.FileExtension})|*{StaticInformation.FileExtension}";

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                loadedRepo = SaveAndLoadUtility.Load<SerializableCurrencyRepo>(filename);

                USCurrencyRepo repo = new USCurrencyRepo();
                List<ICoin> coins = new List<ICoin>();
                foreach (SerializableCoin coin in loadedRepo.Coins)
                {
                    USCoin usCoin;
                    string name = coin.Name.Replace("US ", "");
                    switch (name)
                    {
                        case "Penny":
                            usCoin = new Penny();
                            break;
                        case "Nickel":
                            usCoin = new Nickel();
                            break;
                        case "Dime":
                            usCoin = new Dime();
                            break;
                        case "Quarter":
                            usCoin = new Quarter();
                            break;
                        case "Half Dollar":
                            usCoin = new HalfDollar();
                            break;
                        case "Dollar Coin":
                            usCoin = new DollarCoin();
                            break;
                        default:
                            usCoin = new Penny();
                            break;
                    }

                    coins.Add(usCoin);
                }

                StaticInformation.MainRepo.Coins = coins;
                RefreshAll();
            }
        }

        public override void AddCoin(ICoin coin)
        {
            base.AddCoin(coin);
            this.RaisePropertyChangedEvent(nameof(RepoTotal));
        }

        public override void RemoveCoin(ICoin coin)
        {
            base.RemoveCoin(coin);
            this.RaisePropertyChangedEvent(nameof(RepoTotal));
        }

        private void AddCommand()
        {
            for (int x = 0; x < CoinNum; x++)
            {
                USCoin coin = SelectedCoin;
                this.AddCoin(coin);
            }
        }
    }
}
