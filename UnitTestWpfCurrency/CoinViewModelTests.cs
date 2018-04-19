using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyMidterm.ViewModels;
using CurrencyLibrary.USCurrency;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Media;

namespace UnitTestWpfCurrency
{
    [TestClass]
    public class CoinViewModelTests
    {
        [TestMethod]
        public void CoinViewModel_FormattedCoinStringFromMonetaryValue()
        {
            //Arrange
            CoinViewModel vm = new CoinViewModel(new Penny());
            string defaultString = "25¢";
            string returnedString = "";

            //Act
            returnedString = vm.FormattedCoinString;

            //Assert
            Assert.AreEqual(defaultString, returnedString);
        }

        [TestMethod]
        public void CoinViewModel_CoinColorFromCoinType()
        {
            //Arrange
            CoinViewModel vm = new CoinViewModel(new Penny());
            Brush defaultBrush = new SolidColorBrush(Colors.White);
            Brush returnedBrush;

            //Act
            returnedBrush = vm.CoinColor;

            //Assert
            Assert.AreEqual(defaultBrush.ToString(), returnedBrush.ToString());
        }

        [TestMethod]
        public void USCoinViewModel_FormattedCoinStringFromMonetaryValue()
        {
            //Arrange
            USCoinViewModel pennyVM = new USCoinViewModel(new Penny());
            string pennyFormattedString = "1¢";
            string returnedPennyString = "";

            USCoinViewModel dollarVM = new USCoinViewModel(new DollarCoin());
            string dollarFormattedString = "$1";
            string returnedDollarString = "";

            //Act
            returnedPennyString = pennyVM.FormattedCoinString;
            returnedDollarString = dollarVM.FormattedCoinString;

            //Assert
            Assert.AreEqual(pennyFormattedString, returnedPennyString);
            Assert.AreEqual(dollarFormattedString, returnedDollarString);
        }

        [TestMethod]
        public void USCoinViewModel_CoinColorFromCoinType()
        {
            //Arrange
            USCoinViewModel pennyVM = new USCoinViewModel(new Penny());
            Brush pennyBrush = new SolidColorBrush(Colors.Coral);
            Brush returnedPennyBrush;

            USCoinViewModel dollarVM = new USCoinViewModel(new DollarCoin());
            Brush dollarBrush = new SolidColorBrush(Colors.Gold);
            Brush returnedDollarBrush;


            USCoinViewModel nickelVM = new USCoinViewModel(new Nickel());
            Brush nickelBrush = new SolidColorBrush(Colors.Silver);
            Brush returnedNickelBrush;

            //Act
            returnedPennyBrush = pennyVM.CoinColor;
            returnedDollarBrush = dollarVM.CoinColor;
            returnedNickelBrush =  nickelVM.CoinColor;

            //Assert
            Assert.AreEqual(pennyBrush.ToString(), returnedPennyBrush.ToString());
            Assert.AreEqual(dollarBrush.ToString(), returnedDollarBrush.ToString());
            Assert.AreEqual(nickelBrush.ToString(), returnedNickelBrush.ToString());
        }
    }
}
