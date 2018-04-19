using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.USCurrency
{
    public class USCurrencyRepo : CurrencyRepo
    {
        public static List<USCoin> PossibleCoins { get; private set; }

        public USCurrencyRepo()
        {
            if (PossibleCoins == null || PossibleCoins.Count < 0)
            {
                PossibleCoins = new List<USCoin>();
                PossibleCoins.Add(new DollarCoin());
                PossibleCoins.Add(new HalfDollar());
                PossibleCoins.Add(new Quarter());
                PossibleCoins.Add(new Penny());
                PossibleCoins.Add(new Nickel());
                PossibleCoins.Add(new Dime());
                PossibleCoins = PossibleCoins.OrderByDescending(x => x.MonetaryValue).ToList();
            }
        }

        //Makes change from possible coins to make the most efficient change
        public override ICurrencyRepo MakeChange(double amount)
        {
            return CreateChange(amount);  
        }

        public override ICurrencyRepo MakeChange(double amountTendered, double totalCost)
        {
            return CreateChange(amountTendered, totalCost);
        }

        //Makes change from existing coins
        public override ICurrencyRepo MakeChangeFromCurrentCoins(double amount)
        {
            USCurrencyRepo changeRepo = new USCurrencyRepo();
            List<ICoin> coinsToRemove = new List<ICoin>();

            decimal change = (decimal)amount;

            this.Coins = this.Coins.OrderByDescending(x => x.MonetaryValue).ToList();

            foreach (USCoin coin in this.Coins)
            {
                if (change <= 0) { break; }

                decimal coinValue = (decimal)coin.MonetaryValue;

                change -= coinValue;

                changeRepo.AddCoin(coin);
                coinsToRemove.Add(coin);
            }

            this.Coins = this.Coins.Except(coinsToRemove).ToList(); //remove change from this repo

            return changeRepo;
        }

        public override ICurrencyRepo MakeChangeFromCurrentCoins(double amountTendered, double totalCost)
        {
            double amount = totalCost - amountTendered;
            return MakeChangeFromCurrentCoins(amount);
        }

        public override ICurrencyRepo GetOnlyCoinsOfType(Type coinType)
        {
            ICurrencyRepo originalRepo = this;
            ICurrencyRepo repo = new USCurrencyRepo();

            foreach(ICoin c in originalRepo.Coins)
            {
                if(coinType == c.GetType())
                {
                    repo.AddCoin(c);
                }
            }

            return repo;
        }

        public override ICurrencyRepo Reduce()
        {
            ICurrencyRepo originalRepo = this;
            ICurrencyRepo reducedRepo = new USCurrencyRepo();

            for(int x = (PossibleCoins.Count - 1); x >= 0; x--)
            {
                ICoin smallerCoin = PossibleCoins[x]; //coin we're reducing
                ICurrencyRepo currentCoins = originalRepo.GetOnlyCoinsOfType(PossibleCoins[x].GetType());

                for (int y = 0; y < PossibleCoins.Count; y++)
                {
                    ICoin largerCoin = PossibleCoins[y]; //coin we're trying to reduce the smaller coin to

                    double amountNeededToReduce = largerCoin.MonetaryValue / smallerCoin.MonetaryValue;
                    if (currentCoins.GetCoinCount() >= amountNeededToReduce)
                    {
                        int amountPossible = (int)(currentCoins.GetCoinCount() / amountNeededToReduce);
                        for (int z = 0; z < amountPossible; z++)
                        {
                            reducedRepo.AddCoin(largerCoin);
                            for (int a = 0; a < amountNeededToReduce; a++) //removing reduced coins
                            {
                                currentCoins.Coins.RemoveAt(currentCoins.GetCoinCount() - 1);
                            }
                        }
                    }
                }
            }

            return reducedRepo;
        }

        

        //Static Make Change
        public static ICurrencyRepo CreateChange(double amount)
        {
            USCurrencyRepo repo = new USCurrencyRepo();

            decimal change = (decimal)amount;

            foreach (USCoin coin in PossibleCoins)
            {
                if (change <= 0) { break; }

                decimal coinValue = (decimal)coin.MonetaryValue;

                int count = (int)(change / coinValue);
                change -= count * coinValue;

                for (int x = 0; x < count; x++)
                {
                    repo.AddCoin(coin);
                }

                count = 0;
            }

            return repo;
        }

        public static ICurrencyRepo CreateChange(double amountTendered, double totalCost)
        {
            double amount = totalCost - amountTendered;
            return CreateChange(amount);
        }
    }
}
