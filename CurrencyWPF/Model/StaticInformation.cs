using CurrencyLibrary.USCurrency;
using CurrencyLibrary.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMidterm
{
    public class StaticInformation
    {
        //Static Repo
        private static USCurrencyRepo mainRepo;
        public static USCurrencyRepo MainRepo
        {
            get
            {
                if(mainRepo == null)
                {
                    mainRepo = new USCurrencyRepo();
                }

                return mainRepo;
            }
        }

        //Save File Information
        public static string FileExtensionName
        {
            get { return "Repo Data"; }
        }

        public static string FileExtension
        {
            get { return ".repo"; }
        }
    }
}
