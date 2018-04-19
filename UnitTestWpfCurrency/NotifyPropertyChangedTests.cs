using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyMidterm.ViewModels;
using CurrencyLibrary.USCurrency;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UnitTestWpfCurrency
{
    [TestClass]
    public class NotifyPropertyChangedTests
    {
        [TestMethod]
        public void MakeChangeViewModel_NotifyPropertyChangedTest()
        {
            //Arrange
            RepoViewModel rpVM = new RepoViewModel(new USCurrencyRepo());
            MakeChangeViewModel vm = new MakeChangeViewModel(new USCurrencyRepo(), rpVM);
            List<string> receivedEvents = new List<string>();

            vm.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            //Act
            vm.RepoAmount = 1;

            //Assert
            Assert.AreEqual(receivedEvents[0], "RepoAmount");
        }

        [TestMethod]
        public void RepoViewModel_NotifyPropertyChangedTest()
        {
            //Arrange
            RepoViewModel vm = new RepoViewModel(new USCurrencyRepo());
            List<string> receivedEvents = new List<string>();

            vm.CoinViews.CollectionChanged += delegate (object sender, NotifyCollectionChangedEventArgs e)
            {
                receivedEvents.Add(sender.GetType().ToString());
            };

            //Act
            vm.AddCoin(new Penny());

            //Assert
            Assert.IsTrue(receivedEvents.Count > 0);
        }

        [TestMethod]
        public void StaticRepoViewModel_NotifyPropertyChangedTest()
        {
            //Arrange
            StaticRepoViewModel vm = new StaticRepoViewModel();
            List<string> receivedEvents = new List<string>();

            StaticRepoViewModel.CoinViews.CollectionChanged += delegate (object sender, NotifyCollectionChangedEventArgs e)
            {
                receivedEvents.Add(sender.GetType().ToString());
            };

            //Act
            vm.AddCoin(new Penny());

            //Assert
            Assert.IsTrue(receivedEvents.Count > 0);
        }


    }
}
