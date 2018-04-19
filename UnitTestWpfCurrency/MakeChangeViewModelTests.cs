using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyMidterm.ViewModels;
using CurrencyLibrary.USCurrency;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Win32;
using CurrencyMidterm;
using CurrencyLibrary.Serialization;

namespace UnitTestWpfCurrency
{
    [TestClass]
    public class MakeChangeViewModelTests
    {
        private USCurrencyRepo repo;
        private RepoViewModel rpVM;
        private MakeChangeViewModel vm;

        public MakeChangeViewModelTests()
        {
            repo = new USCurrencyRepo();
            rpVM = new RepoViewModel(repo);
            vm = new MakeChangeViewModel(repo, rpVM);
        }

        [TestMethod]
        public void MakeChangeViewModel_MakeChange()
        {
            //Arrange
            USCurrencyRepo changeRepo;
            double amount = 1.50F;

            //Act
            changeRepo = (USCurrencyRepo)repo.MakeChange(amount);
            vm.RepoAmount = amount;
            vm.MakeChange();

            //Assert
            CollectionAssert.AreEquivalent(changeRepo.Coins, rpVM.CurrentRepo.Coins);
        }

        [TestMethod]
        public void MakeChangeViewModel_Save()
        {
            //Arrange
            string path = $"dataFile{StaticInformation.FileExtension}";

            //Act
            vm.SaveFile(path);

            //Assert
            Assert.IsTrue(SaveAndLoadUtility.FileExists(path));
        }
    }
}
