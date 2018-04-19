using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary
{
    public abstract class CurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }

        public CurrencyRepo()
        {
            Coins = new List<ICoin>();
        }


        public int GetCoinCount()
        {
            return Coins.Count;
        }

        public virtual ICurrencyRepo GetOnlyCoinsOfType(Type coinType)
        {
            throw new NotImplementedException();
        }

        public virtual ICurrencyRepo MakeChange(double amount)
        {
            throw new NotImplementedException();   
        }

        public virtual ICurrencyRepo MakeChange(double amountTendered, double totalCost)
        {
            throw new NotImplementedException();
        }

        public virtual ICurrencyRepo MakeChangeFromCurrentCoins(double amount)
        {
            throw new NotImplementedException();
        }

        public virtual ICurrencyRepo MakeChangeFromCurrentCoins(double amountTendered, double totalCost)
        {
            throw new NotImplementedException();
        }

        public virtual ICurrencyRepo Reduce()
        {
            throw new NotImplementedException();
        }

        public void AddCoin(ICoin coin)
        {
            Coins.Add(coin);
        }

        public ICoin RemoveCoin(ICoin coin)
        {
            Coins.Remove(coin);
            return coin;
        }

        public double TotalValue()
        {
            return Coins.Sum(x => x.MonetaryValue);
        }
    }
}
