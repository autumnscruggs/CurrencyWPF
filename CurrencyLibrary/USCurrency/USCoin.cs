using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibrary.USCurrency
{
    public enum USCoinMintMark
    {
        D, S, W, O, P
    }

    public abstract class USCoin : Coin
    {
        public USCoinMintMark MintMark { get; protected set; }

        public USCoin() : this(USCoinMintMark.P) { }
        public USCoin(USCoinMintMark mark)
        {
            this.Name = "US";
            this.MintMark = mark;
        }

        private const string mintNameDenver = "Denver";
        private const string mintNamePhili = "Philadephia";
        private const string mintNameSanFran = "San Francisco";
        private const string mintNameWestPoint = "West Point";
        private const string mintNameNewOrleans = "New Orleans";

        public static string GetMintNameFromMark(USCoinMintMark d)
        {
            switch (d)
            {
                case USCoinMintMark.D:
                    return mintNameDenver;
                case USCoinMintMark.S:
                    return mintNameSanFran;
                case USCoinMintMark.W:
                    return mintNameWestPoint;
                case USCoinMintMark.O:
                    return mintNameNewOrleans;
                case USCoinMintMark.P:
                    return mintNamePhili;
                default:
                    return mintNameDenver;
            }
        }

        public override string About()
        {
            return $"{base.About()} It was made in {GetMintNameFromMark(this.MintMark)}.";
        }
    }
}
