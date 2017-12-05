using ExchangeRates.Domain.Entities;
using ExchangeRates.Domain.Models;
using System.Collections.Generic;

namespace ExchangeRates.WinRT.Factories
{
    public class CurrencyFactory
    {
        public Currency Get(CurrencyEntity currencyEntity)
        {
            var instance = new Currency
            {
                Base = currencyEntity.Base,
                Date = currencyEntity.Date,
                Rates = new Dictionary<string, decimal>()
            };

            foreach (var item in currencyEntity.Rates)
                instance.Rates.Add(item.CurrencyName, item.CurrencyRate);

            return null;
        }
    }
}
