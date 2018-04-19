using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.Serialization
{
    [System.Serializable]
    public class SerializableCoin
    {
        public int Year { get; set; }
        public double MonetaryValue { get; set; }
        public string Name { get; set; }

        public SerializableCoin(int year, double value, string name)
        {
            Year = year;
            MonetaryValue = value;
            Name = name;
        }

    }
}
