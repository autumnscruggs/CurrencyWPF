using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.Serialization
{
    [System.Serializable]
    public class SerializableCurrencyRepo
    {
        public List<SerializableCoin> Coins { get; set; }

        public SerializableCurrencyRepo(List<ICoin> coins)
        {
            Coins = new List<SerializableCoin>();
            foreach (ICoin c in coins)
            {
                Coins.Add(new SerializableCoin(c.Year, c.MonetaryValue, c.Name));
            }
        }

    }
}
