using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyLibrary.USCurrency;

namespace UnitTestCurrency
{
    [TestClass]
    public class QuarterTests
    {
        Quarter q;

        [TestMethod]
        public void QuarterConstructor()
        {
            //Arrange
            Quarter sanFran;
            q = new Quarter();

            //Act 
            sanFran = new Quarter(USCoinMintMark.S);
            //Assert
            //Current Year is default year
            Assert.AreEqual(USCoinMintMark.D, q.MintMark);
            Assert.AreEqual(System.DateTime.Now.Year, q.Year);
            Assert.AreEqual(System.DateTime.Now.Year, sanFran.Year);
            Assert.AreEqual(USCoinMintMark.S, sanFran.MintMark);
        }

        [TestMethod]
        public void QuarterMonetaryValue()
        {
            //Arrange
            q = new Quarter();
            //Act 

            //Assert
            Assert.AreEqual(.25, q.MonetaryValue);
        }

        [TestMethod]
        public void QuarterAbout()
        {
            //Arrange
            q = new Quarter();
            //Act 

            //Assert
            Assert.AreEqual("US Quarter is from 2017. It is worth $0.25. It was made in Denver.", q.About());
        }
    }
}
