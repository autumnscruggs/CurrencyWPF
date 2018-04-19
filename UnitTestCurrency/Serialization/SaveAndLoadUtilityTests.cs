using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyLibrary.USCurrency;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using CurrencyLibrary.Serialization;

namespace UnitTestCurrency.Serialization
{
    [TestClass]
    public class SaveAndLoadUtilityTests
    {
        [TestMethod]
        public void SaveAndLoadUtility_DirectoryExists()
        {
            //Arrange
            string path = "/RandomFolder/";
            bool returnedPathExistance;

            //Act
            returnedPathExistance = SaveAndLoadUtility.DirectoryExists(path, true);

            //Assert
            Assert.IsTrue(returnedPathExistance);
        }

        [TestMethod]
        public void SaveAndLoadUtility_FileExists()
        {
            //Arrange
            string path = "/RandomFolder/randomFile.repo";
            bool returnedPathExistance;
            bool doesPathExist = false;

            //Act
            returnedPathExistance = SaveAndLoadUtility.FileExists(path);

            //Assert
            Assert.AreEqual(returnedPathExistance, doesPathExist);
        }

        [TestMethod]
        public void SaveAndLoadUtility_Save()
        {
           //TODO: Figure out how to test a file saver / binary formatter
        }

        [TestMethod]
        public void SaveAndLoadUtility_Load()
        {
            //TODO: Figure out how to test a file saver / binary formatter
        }
    }
}
