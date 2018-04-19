using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyMidterm.ViewModels;
using CurrencyLibrary.USCurrency;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using CurrencyMidterm;

namespace UnitTestWpfCurrency
{
    [TestClass]
    public class StaticRepoViewModelTest
    {
        private StaticRepoViewModel vm;

        public StaticRepoViewModelTest()
        {
            vm = new StaticRepoViewModel();
        }

        [TestMethod]
        public void StaticRepoViewModel_ClearAllTest()
        {
            //Arrange
            USCoin penny = new Penny();

            //Act
            vm.AddCoin(penny);
            vm.AddCoin(penny);
            vm.ClearAll();

            //Assert
            Assert.AreEqual(StaticRepoViewModel.CoinViews.Count, 0);
            Assert.AreEqual(StaticRepoViewModel.CoinNames.Count, 0);
            Assert.AreEqual(StaticInformation.MainRepo.Coins.Count, 0);
        }

        [TestMethod]
        public void StaticRepoViewModel_AddCoinTest()
        {
            //Arrange
            USCoin penny = new Penny();

            //Act
            vm.AddCoin(penny);

            //Assert
            Assert.AreEqual(StaticRepoViewModel.CoinViews.Count, 1);
            Assert.AreEqual(StaticRepoViewModel.CoinNames.Count, 1);
            Assert.AreEqual(StaticInformation.MainRepo.Coins.Count, 1);
        }

        [TestMethod]
        public void StaticRepoViewModel_RemoveCoinTest()
        {
            //Arrange
            USCoin penny = new Penny();

            //Act
            vm.ClearAll();
            vm.AddCoin(penny);
            vm.RemoveCoin(penny);

            //Assert
            Assert.AreEqual(StaticRepoViewModel.CoinViews.Count, 0);
            Assert.AreEqual(StaticRepoViewModel.CoinNames.Count, 0);
            Assert.AreEqual(StaticInformation.MainRepo.Coins.Count, 0);
        }
    }
}
