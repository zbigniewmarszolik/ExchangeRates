using ExchangeRates.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ExchangeRates.Domain.Services
{
    public interface ICurrencyService
    {
        Task<Currency> GetLatestRatesAsync();
    }
}
