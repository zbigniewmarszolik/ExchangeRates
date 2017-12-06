using ExchangeRates.Domain.Models;
using ExchangeRates.Domain.Repositories;
using ExchangeRates.UI.Factories;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.UI.Strategies
{
    public class SqlDataStrategy : IDataStrategy
    {
        private ICurrencyRepository _currencyRepository { get; set; }
        private CurrencyFactory _currencyFactory { get; set; }

        public SqlDataStrategy(
            ICurrencyRepository currencyRepository,
            CurrencyFactory currencyFactory)
        {
            _currencyRepository = currencyRepository;
            _currencyFactory = currencyFactory;
        }

        public async Task<Currency> GetDataAsync()
        {
            Currency currency = null;

            await Task.Run(() =>
            {
                var dataSet = _currencyRepository.ReadData();
                var lastEntity = dataSet.Last();
                currency = _currencyFactory.Get(lastEntity);
            });

            return currency;
        }
    }
}
