using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyLibrary.USCurrency;

namespace UnitTestCurrency
{
    [TestClass]
    public class HalfDollarTests
    {
        HalfDollar h;

        [TestMethod]
        public void HalfDollarConstructor()
        {
            //Arrange
            HalfDollar philli;
            h = new HalfDollar();

            //Act 
            philli = new HalfDollar(USCoinMintMark.P);
            //Assert
            //Current Year is default year
            Assert.AreEqual(USCoinMintMark.D, h.MintMark);
            Assert.AreEqual(System.DateTime.Now.Year, h.Year);
            Assert.AreEqual(System.DateTime.Now.Year, philli.Year);
            Assert.AreEqual(USCoinMintMark.P, philli.MintMark);
        }

        [TestMethod]
        public void HalfDollarMonetaryValue()
        {
            //Arrange
            h = new HalfDollar();
            //Act 

            //Assert
            Assert.AreEqual(.50, h.MonetaryValue);
        }

        [TestMethod]
        public void HalfDollarAbout()
        {
            //Arrange
            h = new HalfDollar();
            //Act 

            //Assert
            Assert.AreEqual("US Half Dollar is from 2017. It is worth $0.50. It was made in Denver.", h.About());
        }
    }
}
