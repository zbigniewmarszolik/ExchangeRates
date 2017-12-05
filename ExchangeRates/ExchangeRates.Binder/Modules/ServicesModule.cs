using Autofac;
using ExchangeRates.Domain.Services;
using ExchangeRates.Services.Factories;
using ExchangeRates.Services.Services;

namespace ExchangeRates.Binder.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyService>().As<ICurrencyService>();

            builder.RegisterType<HttpClientFactory>();
        }
    }
}
