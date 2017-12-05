using ExchangeRates.Domain.Entities;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;

namespace ExchangeRates.Infrastructure.Factories
{
    public class SQLiteConnectionFactory
    {
        public SQLiteConnection Get()
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), Path.Combine(ApplicationData.Current.LocalFolder.Path, "currency_exchange_rates.db"));

            connection.CreateTable<CurrencyEntity>();
            connection.CreateTable<RateEntity>();

            return connection;
        }
    }
}
