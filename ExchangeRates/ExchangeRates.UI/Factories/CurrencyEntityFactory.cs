using ExchangeRates.Domain.Entities;
using ExchangeRates.Domain.Models;
using System;
using System.Collections.Generic;

namespace ExchangeRates.UI.Factories
{
    public class CurrencyEntityFactory
    {
        public CurrencyEntity Get(Currency currency)
        {
            var instance = new CurrencyEntity
            {
                Base = currency.Base,
                Date = currency.Date,
                Rates = new List<RateEntity>(),
                LocalSavedDate = DateTime.Now
            };

            foreach (var item in currency.Rates)
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
