using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary
{
    public class Coin : ICoin
    {
        public int Year { get; }
        public double MonetaryValue { get; protected set;  }
        public string Name { get; protected set; }

        public Coin()
        {
            Year = System.DateTime.Now.Year;
        }

        public virtual string About()
        {
            return $"{this.Name} is from {Year}. It is worth ${MonetaryValue.ToString("F")}.";
        }
    }
}
