using CurrencyLibrary;
using CurrencyLibrary.USCurrency;
using CurrencyMidterm.Views.Coins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMidterm.ViewModels
{
    public class StaticRepoViewModel : BaseViewModel
    {
        private static ObservableCollection<CoinView> views;
        public static ObservableCollection<CoinView> CoinViews
        {
            get
            {
                if (views == null)
                {
                    views = new ObservableCollection<CoinView>();
                }

                return views;
            }
        }
        private static ObservableCollection<string> coinNames;
        public static ObservableCollection<string> CoinNames
        {
            get
            {
                if (coinNames == null)
                {
                    coinNames = new ObservableCollection<string>();
                }

                return coinNames;
            }
        }

        public StaticRepoViewModel() 
        {
            SetCoinViews();
            RefreshCoinNames();
            CoinViews.CollectionChanged += new NotifyCollectionChangedEventHandler(RefreshCoinNames);
        }

        protected void RefreshCoinNames(object sender = null, NotifyCollectionChangedEventArgs e = null)
        {
            CoinNames.Clear();

            foreach (ICoin coin in StaticInformation.MainRepo.Coins)
            {
                CoinNames.Add(coin.Name);
            }
        }
        
        public virtual void AddCoin(ICoin coin)
        {
            StaticInformation.MainRepo.AddCoin(coin);
            CoinViews.Add(new CoinView((USCoin)coin));
        }

        public virtual void RemoveCoin(ICoin coin)
        {
            StaticInformation.MainRepo.RemoveCoin(coin);
            CoinView coinView = CoinViews.ToList().Find(x => x.Coin == coin);
            CoinViews.Remove(coinView);
        }

        public void ClearAll()
        {
            StaticInformation.MainRepo.Coins.Clear();
            RefreshAll();
        }

        protected virtual void RefreshAll()
        {
            this.SetCoinViews();
            this.RefreshCoinNames();
        }

        protected void SetCoinViews()
        {
            CoinViews.Clear();

            foreach (ICoin coin in StaticInformation.MainRepo.Coins)
            {
                CoinViews.Add(new CoinView((USCoin)coin));
            }
        }
    }
}
