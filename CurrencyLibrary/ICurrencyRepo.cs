using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyLibrary.USCurrency;

namespace CurrencyLibrary
{
    public interface ICurrencyRepo
    {
        List<ICoin> Coins { get; set; }

        int GetCoinCount();
        double TotalValue();
        void AddCoin(ICoin coin);
        ICoin RemoveCoin(ICoin coin);
        ICurrencyRepo GetOnlyCoinsOfType(Type coinType);
        ICurrencyRepo MakeChange(double amount);
        ICurrencyRepo MakeChange(double amountTendered, double totalCost);
        ICurrencyRepo MakeChangeFromCurrentCoins(double amount);
        ICurrencyRepo MakeChangeFromCurrentCoins(double amountTendered, double totalCost);
        ICurrencyRepo Reduce();
    }
}
