using ExchangeRates.Domain.Models;
using ExchangeRates.WinRT.Facades;
using Microsoft.Practices.Prism.Mvvm;

namespace ExchangeRates.WinRT.ViewModels
{
    public class CurrencyViewModel : BindableBase
    {
        private InitializationFacade _initializationFacade { get; set; }
        private Currency _currencyData { get; set; }

        public CurrencyViewModel(InitializationFacade initializationFacade)
        {
            _initializationFacade = initializationFacade;

            PrepareData();
        }

        private async void PrepareData()
        {
            _currencyData = await _initializationFacade.GetData();
        }
    }
}
