using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyLibrary.USCurrency;

namespace UnitTestCurrency
{
    [TestClass]
    public class DollarCoinTests
    {
        DollarCoin c;

        [TestMethod]
        public void DollarCoinConstructor()
        {
            //Arrange
            DollarCoin philli;
            c = new DollarCoin();

            //Act 
            philli = new DollarCoin(USCoinMintMark.P);
            //Assert
            //Current Year is default year
            Assert.AreEqual(USCoinMintMark.D, c.MintMark);
            Assert.AreEqual(System.DateTime.Now.Year, c.Year);
            Assert.AreEqual(System.DateTime.Now.Year, philli.Year);
            Assert.AreEqual(USCoinMintMark.P, philli.MintMark);
        }

        [TestMethod]
        public void DollarCoinMonetaryValue()
        {
            //Arrange
            c = new DollarCoin();
            //Act 

            //Assert
            Assert.AreEqual(1.00, c.MonetaryValue);
        }

        [TestMethod]
        public void DollarCoinAbout()
        {
            //Arrange
            c = new DollarCoin();
            //Act 

            //Assert
            Assert.AreEqual("US Dollar Coin is from 2017. It is worth $1.00. It was made in Denver.", c.About());
        }
    }
}
