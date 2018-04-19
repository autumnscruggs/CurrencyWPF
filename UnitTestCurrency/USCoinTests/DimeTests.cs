using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyLibrary.USCurrency;

namespace UnitTestCurrency
{
    [TestClass]
    public class DimeTests
    {
        Dime d;

        [TestMethod]
        public void DimeConstructor()
        {
            //Arrange
            Dime westDime;
            d = new Dime();
      
            //Act 
            westDime = new Dime(USCoinMintMark.W);
            //Assert
            //Current Year is default year
            Assert.AreEqual(USCoinMintMark.D, d.MintMark);
            Assert.AreEqual(System.DateTime.Now.Year, d.Year);
            Assert.AreEqual(System.DateTime.Now.Year, westDime.Year);
            Assert.AreEqual(USCoinMintMark.W, westDime.MintMark);
        }

        [TestMethod]
        public void DimeMonetaryValue()
        {
            //Arrange
            d = new Dime();
            //Act 

            //Assert
            Assert.AreEqual(.10, d.MonetaryValue);
        }

        [TestMethod]
        public void DimeAbout()
        {
            //Arrange
            d = new Dime();
            //Act 

            //Assert
            Assert.AreEqual("US Dime is from 2017. It is worth $0.10. It was made in Denver.", d.About());
        }
    }
}
