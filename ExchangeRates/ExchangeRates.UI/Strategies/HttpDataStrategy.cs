using ExchangeRates.Domain.Models;
using ExchangeRates.Domain.Repositories;
using ExchangeRates.Domain.Services;
using ExchangeRates.UI.Factories;
using System;
using System.Threading.Tasks;

namespace ExchangeRates.UI.Strategies
{
    public class HttpDataStrategy : IDataStrategy
    {
        private ICurrencyService _currencyService { get; set; }
        private ICurrencyRepository _currencyRepository { get; set; }
        private CurrencyEntityFactory _currencyEntityFactory { get; set; }

        public HttpDataStrategy(
            ICurrencyService currencyService,
            ICurrencyRepository currencyRepository,
            CurrencyEntityFactory currencyEntityFactory)
        {
            _currencyService = currencyService;
            _currencyRepository = currencyRepository;
            _currencyEntityFactory = currencyEntityFactory;
        }

        public async Task<Currency> GetDataAsync()
        {
            Currency remoteCurrencyData = null;

            try
            {
                remoteCurrencyData = await _currencyService.GetLatestRatesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not download currency exchange rates from the remote server.");
            }

            var currencyEntity = _currencyEntityFactory.Get(remoteCurrencyData);

            try
            {
                _currencyRepository.InsertData(currencyEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not insert data to SQlite database.");
            }

            return remoteCurrencyData;
        }
    }
}
