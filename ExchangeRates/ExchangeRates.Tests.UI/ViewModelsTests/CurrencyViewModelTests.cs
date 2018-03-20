using ExchangeRates.Domain.Models;
using ExchangeRates.UI.Facades;
using ExchangeRates.UI.Helpers;
using ExchangeRates.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.Tests.UI.ViewModelsTests
{
    [TestClass]
    public class CurrencyViewModelTests
    {
        private CurrencyViewModel _testingViewModel { get; set; }

        private int _dictionarySize { get; set; }

        [TestInitialize]
        public void Setup()
        {
            var dictionary = new Dictionary<string, decimal>();
            dictionary.Add("USD", new decimal(1.3));
            dictionary.Add("PLN", new decimal(4.3));
            _dictionarySize = dictionary.Count;

            var mockInitializationFacade = new Mock<IInitializationFacade>(MockBehavior.Strict);
            mockInitializationFacade.Setup(f => f.GetData()).ReturnsAsync(new Currency
            {
                Base = "EUR",
                Date = DateTime.Now,
                Rates = dictionary
            });

            var initializationFacade = mockInitializationFacade.Object;

            var currencyDescriptionHelper = new CurrencyDescriptionHelper();

            _testingViewModel = new CurrencyViewModel(initializationFacade, currencyDescriptionHelper);
        }

        [TestMethod]
        public void CurrencyViewModel_Constructor_ConstructingProperObject()
        {
            Assert.IsNotNull(_testingViewModel);
            Assert.IsNotNull(_testingViewModel.CurrencyRates);
            Assert.AreEqual(_dictionarySize, _testingViewModel.CurrencyRates.Count);
        }

        [TestMethod]
        public void GetSetSelectedRate_ExistingInput_ReturningProperDescriptionAndGettingRate()
        {
            // Arrange
            var rate = new Rate
            {
                CurrencyRate = new decimal(9.15),
                CurrencyName = "CZK"
            };
            _testingViewModel.SelectedRate = rate;

            // Act
            var result = _testingViewModel.Description;
            var selectedRate = _testingViewModel.SelectedRate;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Czech koruna", result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual(rate, selectedRate);
        }

        [TestMethod]
        public void SetSelectedRate_NullInput_ClearingDescription()
        {
            // Arrange
            _testingViewModel.SelectedRate = null;

            // Act
            var result = _testingViewModel.Description;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void SetSelectedRate_WrongInput_ReturningDefaultNull()
        {
            // Arrange
            var rate = new Rate
            {
                CurrencyRate = new decimal(9.15),
                CurrencyName = "wrong"
            };
            _testingViewModel.SelectedRate = rate;

            // Act
            var result = _testingViewModel.Description;

            // Assert
            Assert.IsNull(result);
        }
    }
}
