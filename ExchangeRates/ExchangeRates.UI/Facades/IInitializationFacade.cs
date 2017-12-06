using ExchangeRates.Domain.Models;
using System.Threading.Tasks;

namespace ExchangeRates.UI.Facades
{
    public interface IInitializationFacade
    {
        Task<Currency> GetData();
    }
}
