using ExchangeRates.Domain.Models;
using System.Threading.Tasks;

namespace ExchangeRates.UI.Strategies
{
    public interface IDataStrategy
    {
        Task<Currency> GetDataAsync();
    }
}
