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
            var rate = new Rate
            {
                CurrencyRate = new decimal(9.15),
                CurrencyName = "CZK"
            };

            _testingViewModel.SelectedRate = rate;

            var result = _testingViewModel.Description;

            var selectedRate = _testingViewModel.SelectedRate;

            Assert.IsNotNull(result);
            Assert.AreEqual("Czech koruna", result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual(rate, selectedRate);
        }

        [TestMethod]
        public void SetSelectedRate_NullInput_ClearingDescription()
        {
            _testingViewModel.SelectedRate = null;

            var result = _testingViewModel.Description;

            Assert.IsNotNull(result);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void SetSelectedRate_WrongInput_ReturningDefaultNull()
        {
            var rate = new Rate
            {
                CurrencyRate = new decimal(9.15),
                CurrencyName = "wrong"
            };

            _testingViewModel.SelectedRate = rate;

            var result = _testingViewModel.Description;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetSetIsDataLoading_ChangingProperty_ActingProperly()
        {
            Assert.IsFalse(_testingViewModel.IsDataLoading);

            _testingViewModel.IsDataLoading = true;

            Assert.IsTrue(_testingViewModel.IsDataLoading);

            _testingViewModel.IsDataLoading = false;

            Assert.IsFalse(_testingViewModel.IsDataLoading);
        }

        [TestMethod]
        public void GetSetCentralDate_ChangingProperty_ActingProperly()
        {
            var date = DateTime.Now;

            _testingViewModel.CentralDate = "";

            Assert.AreNotEqual(date.ToString(), _testingViewModel.CentralDate);

            _testingViewModel.CentralDate = date.ToString();

            Assert.AreEqual(date.ToString(), _testingViewModel.CentralDate);
        }

        [TestMethod]
        public void GetSetDescription_ChangingProperty_ActingProperly()
        {
            var description = "random description";

            _testingViewModel.CentralDate = "";

            Assert.AreNotEqual(description, _testingViewModel.Description);

            _testingViewModel.Description = description;

            Assert.AreEqual(description, _testingViewModel.Description);
        }
    }
}
