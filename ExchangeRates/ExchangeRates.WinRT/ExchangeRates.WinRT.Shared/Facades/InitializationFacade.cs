using System;
using ExchangeRates.Domain.Repositories;
using ExchangeRates.Domain.Services;
using ExchangeRates.WinRT.Factories;
using System.Linq;
using ExchangeRates.Domain.Models;
using System.Threading.Tasks;

namespace ExchangeRates.WinRT.Facades
{
    public class InitializationFacade
    {
        private ICurrencyService _currencyService { get; set; }
        private ICurrencyRepository _currencyRepository { get; set; }
        private CurrencyFactory _currencyFactory { get; set; }
        private CurrencyEntityFactory _currencyEntityFactory { get; set; }

        public InitializationFacade(ICurrencyService currencyService,
            ICurrencyRepository currencyRepository,
            CurrencyFactory currencyFactory,
            CurrencyEntityFactory currencyEntityFactory)
        {
            _currencyService = currencyService;
            _currencyRepository = currencyRepository;
            _currencyFactory = currencyFactory;
            _currencyEntityFactory = currencyEntityFactory;
        }

        public async Task<Currency> GetData()
        {
            return await InitializeData();
        }

        private async Task<Currency> InitializeData()
        {
            var localCurrencyData = _currencyRepository.ReadData();

            if (localCurrencyData != null && localCurrencyData.Count > 0)
            {
                var lastEntity = localCurrencyData.Last();

                if (lastEntity.Date.Day == DateTime.Now.Day)
                    return _currencyFactory.Get(lastEntity);

                else return await DownloadAndSave();
            }

            else return await DownloadAndSave();
        }

        private async Task<Currency> DownloadAndSave()
        {
            var remoteCurrencyData = await _currencyService.GetLatestRates();

            var currencyEntity = _currencyEntityFactory.Get(remoteCurrencyData);

            _currencyRepository.InsertData(currencyEntity);

            return remoteCurrencyData;
        }
    }
}
