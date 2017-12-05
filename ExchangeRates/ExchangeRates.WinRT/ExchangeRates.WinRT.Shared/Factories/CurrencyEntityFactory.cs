using ExchangeRates.Domain.Entities;
using ExchangeRates.Domain.Models;
using System.Collections.Generic;

namespace ExchangeRates.WinRT.Factories
{
    public class CurrencyEntityFactory
    {
        public CurrencyEntity Get(Currency currency)
        {
            var instance = new CurrencyEntity
            {
                Base = currency.Base,
                Date = currency.Date,
                Rates = new List<RateEntity>()
            };

            foreach(var item in currency.Rates)
            {
                var rate = new RateEntity
                {
                    CurrencyName = item.Key,
                    CurrencyRate = item.Value
                };

                instance.Rates.Add(rate);
            }

            return instance;
        }
    }
}
