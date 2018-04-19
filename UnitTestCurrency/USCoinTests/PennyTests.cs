using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyLibrary.USCurrency;

namespace UnitTestCurrency
{
    [TestClass]
    public class PennyTests
    {
        Penny p;

        [TestMethod]
        public void PennyConstructor()
        {
            //Arrange
            Penny philiPenny;
            //Act 
            p = new Penny();
            philiPenny = new Penny(USCoinMintMark.P);
            //Assert
            //D is the default mint mark
            //Current Year is default year
            Assert.AreEqual(USCoinMintMark.D, p.MintMark);
            Assert.AreEqual(System.DateTime.Now.Year, p.Year);
            Assert.AreEqual(System.DateTime.Now.Year, philiPenny.Year);
            Assert.AreEqual(USCoinMintMark.P, philiPenny.MintMark);
        }

        [TestMethod]
        public void PennyMonetaryValue()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual(.01, p.MonetaryValue);
        }

        [TestMethod]
        public void PennyAbout()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual("US Penny is from 2017. It is worth $0.01. It was made in Denver.", p.About());

        }
    }
}
