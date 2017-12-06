using ExchangeRates.Domain.Entities;
using ExchangeRates.Domain.Models;
using ExchangeRates.Domain.Repositories;
using ExchangeRates.UI.Factories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.UI.Facades
{
    public class InitializationFacade : IInitializationFacade
    {
        public Action<string> DbErrorAction { get; set; }
        public Action<string> ApiErrorAction { get; set; }

        private ICurrencyRepository _currencyRepository { get; set; }
        private DataStrategyFactory _dataStrategyFactory { get; set; }

        public InitializationFacade(
            ICurrencyRepository currencyRepository,
            DataStrategyFactory dataStrategyFactory)
        {
            _currencyRepository = currencyRepository;
            _dataStrategyFactory = dataStrategyFactory;
        }

        public async Task<Currency> GetData()
        {
            IList<CurrencyEntity> localCurrencyData = null;

            try
            {
                localCurrencyData = _currencyRepository.ReadData();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not read data from SQlite database.");
            }

            var strategy = _dataStrategyFactory.CreateDataStrategy(localCurrencyData);

            Currency currencyResult = null;

            try
            {
                currencyResult = await strategy.GetDataAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return currencyResult;
        }
    }
}
