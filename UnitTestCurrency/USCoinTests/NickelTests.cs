using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyLibrary.USCurrency;

namespace UnitTestCurrency
{
    [TestClass]
    public class NickelTests
    {
        Nickel n;

        [TestMethod]
        public void NickelConstructor()
        {
            //Arrange
            Nickel newOrleansNickel;
            n = new Nickel();
      
            //Act 
            newOrleansNickel = new Nickel(USCoinMintMark.O);
            //Assert
            //Current Year is default year
            Assert.AreEqual(USCoinMintMark.D, n.MintMark);
            Assert.AreEqual(System.DateTime.Now.Year, n.Year);
            Assert.AreEqual(System.DateTime.Now.Year, newOrleansNickel.Year);
            Assert.AreEqual(USCoinMintMark.O, newOrleansNickel.MintMark);
        }

        [TestMethod]
        public void NickelMonetaryValue()
        {
            //Arrange
            n = new Nickel();
            //Act 

            //Assert
            Assert.AreEqual(.05, n.MonetaryValue);
        }

        [TestMethod]
        public void NickelAbout()
        {
            //Arrange
            n = new Nickel();
            //Act 

            //Assert
            Assert.AreEqual("US Nickel is from 2017. It is worth $0.05. It was made in Denver.", n.About());
        }
    }
}
