using ExchangeRates.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ExchangeRates.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        void InsertData(CurrencyEntity currencyEntity);
        IList<CurrencyEntity> ReadData();
    }
}
