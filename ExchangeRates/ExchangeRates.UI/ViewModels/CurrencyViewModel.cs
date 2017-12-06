using ExchangeRates.Domain.Models;
using ExchangeRates.UI.Facades;
using ExchangeRates.UI.Helpers;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace ExchangeRates.UI.ViewModels
{
    public class CurrencyViewModel : BindableBase
    {
        private IInitializationFacade _initializationFacade { get; set; }
        private CurrencyDescriptionHelper _currencyDescriptionHelper { get; set; }

        public Action<string> PopErrorAction { get; set; }

        public ObservableCollection<Rate> CurrencyRates { get; set; }

        private bool _isDataLoading;

        public bool IsDataLoading
        {
            get { return _isDataLoading; }
            set { _isDataLoading = value; OnPropertyChanged(() => IsDataLoading); }
        }

        private string _centralDate;

        public string CentralDate
        {
            get { return _centralDate; }
            set { _centralDate = value; OnPropertyChanged(() => CentralDate); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(() => Description); }
        }

        private Rate _selectedRate;

        public Rate SelectedRate
        {
            get { return _selectedRate; }
            set
            {
                _selectedRate = value;
                OnPropertyChanged(() => SelectedRate);
                AssignDescription();
            }
        }

        public CurrencyViewModel(
            IInitializationFacade initializationFacade,
            CurrencyDescriptionHelper currencyDescriptionHelper)
        {
            _initializationFacade = initializationFacade;
            _currencyDescriptionHelper = currencyDescriptionHelper;

            CurrencyRates = new ObservableCollection<Rate>();

            PrepareDataAsync();
        }

        private async void PrepareDataAsync()
        {
            IsDataLoading = true;

            Currency currency = null;

            try
            {
                currency = await _initializationFacade.GetData();
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }

            if (currency == null)
            {
                IsDataLoading = false;
                return;
            }

            foreach (var item in currency.Rates)
            {
                CurrencyRates.Add(new Rate
                {
                    CurrencyName = item.Key,
                    CurrencyRate = item.Value
                });
            }

            CentralDate = currency.Date.ToString();

            IsDataLoading = false;
        }

        private void AssignDescription()
        {
            if (SelectedRate == null)
            {
                Description = "";
                return;
            }

            Description = _currencyDescriptionHelper.ResolveDescription(SelectedRate.CurrencyName);
        }

        private void PopError(string errorText)
        {
            PopErrorAction(errorText);
        }
    }
}
