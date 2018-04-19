using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CurrencyLibrary;
using CurrencyLibrary.USCurrency;

namespace UnitTestCurrency
{

    [TestClass]
    public class USCoinTests
    {

        Penny p;

        public USCoinTests()
        {
            p = new Penny();
        }


        [TestMethod]
        public void USCoinPennyConstructorTest()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual(CurrencyLibrary.USCurrency.USCoinMintMark.D, p.MintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current year is default year

        }

        [TestMethod]
        public void USCoinMintMarkTest()
        {

            //Arrange
            string mintNameDenver, mintNamePhili, mintNameSanFran, mintNameWestPoint, mintNameNewOrleans;
            USCoinMintMark D, P, S, W, O;

            //Act 
            mintNameDenver = "Denver";
            mintNamePhili = "Philadephia";
            mintNameSanFran = "San Francisco";
            mintNameWestPoint = "West Point";
            mintNameNewOrleans = "New Orleans";

            D = USCoinMintMark.D;
            P = USCoinMintMark.P;
            S = USCoinMintMark.S;
            W = USCoinMintMark.W;
            O = USCoinMintMark.O;

            //Assert
            Assert.AreEqual(USCoin.GetMintNameFromMark(D), mintNameDenver);
            Assert.AreEqual(USCoin.GetMintNameFromMark(P), mintNamePhili);
            Assert.AreEqual(USCoin.GetMintNameFromMark(S), mintNameSanFran);
            Assert.AreEqual(USCoin.GetMintNameFromMark(W), mintNameWestPoint);
            Assert.AreEqual(USCoin.GetMintNameFromMark(O), mintNameNewOrleans);
        }

        [TestMethod]
        public void USCoinPennyMonetaryValue()
        {
            //Arrange
            p = new Penny();
            //Act 
            //nothing should have .01;
            //Assert
            Assert.AreEqual(.01, p.MonetaryValue);
        }

        [TestMethod]
        public void USCoinPennyAbout()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual("US Penny is from 2017. It is worth $0.01. It was made in Denver.", p.About());
        }
    }
}
