using System;
using System.Collections.Generic;
using ExchangeRates.Domain.Entities;
using ExchangeRates.Domain.Repositories;
using ExchangeRates.Infrastructure.Factories;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System.Linq;

namespace ExchangeRates.Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private SQLiteConnection _connection { get; set; }

        public CurrencyRepository(SQLiteConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.Get();
        }

        public void InsertData(CurrencyEntity currencyEntity)
        {
            try
            {
                _connection.InsertOrReplaceWithChildren(currencyEntity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<CurrencyEntity> ReadData()
        {
            IList<CurrencyEntity> currencies;

            try
            {
                currencies = _connection.GetAllWithChildren<CurrencyEntity>().ToList();
            }
            catch(Exception e)
            {
                currencies = null;
                throw e;
            }

            return currencies;
        }
    }
}
