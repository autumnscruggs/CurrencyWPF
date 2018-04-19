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
using System.Windows.Input;

namespace CurrencyMidterm.ViewModels
{
    public class RepoViewModel : BaseViewModel
    {
        public USCurrencyRepo CurrentRepo { get; protected set; }

        private ObservableCollection<CoinView> views;
        public ObservableCollection<CoinView> CoinViews
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

        private ObservableCollection<string> coinNames;
        public ObservableCollection<string> CoinNames
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

        public RepoViewModel(USCurrencyRepo repo)
        {  
            CurrentRepo = repo;
            SetCoinViews();
            RefreshCoinNames();
            CoinViews.CollectionChanged += new NotifyCollectionChangedEventHandler(RefreshCoinNames);
        }

        private void RefreshCoinNames(object sender = null, NotifyCollectionChangedEventArgs e = null)
        {
            CoinNames.Clear();

            foreach (ICoin coin in CurrentRepo.Coins)
            {
                CoinNames.Add(coin.Name);
            }
        }

        public virtual void AddCoin(ICoin coin)
        {
            CurrentRepo.AddCoin(coin);
            CoinViews.Add(new CoinView((USCoin)coin));
        }

        public virtual void RemoveCoin(ICoin coin)
        {
            CurrentRepo.AddCoin(coin);
            CoinView coinView = CoinViews.ToList().Find(x => x.Coin == coin);
            CoinViews.Remove(coinView);
        }

        public virtual void SetRepo(USCurrencyRepo newRepo)
        {
            CurrentRepo = newRepo;
            this.RaisePropertyChangedEvent(nameof(CurrentRepo));
        }

        protected override void RaisePropertyChangedEvent(string propertyName)
        {
            base.RaisePropertyChangedEvent(propertyName);

            if(propertyName == nameof(CurrentRepo))
            {
                SetCoinViews();
                RefreshCoinNames();
            }
        }

        private void SetCoinViews()
        {
            CoinViews.Clear();

            foreach (ICoin coin in CurrentRepo.Coins)
            {
                CoinViews.Add(new CoinView((USCoin)coin));
            }
        }
    }
}
