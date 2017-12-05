using Autofac;
using ExchangeRates.Domain.Repositories;
using ExchangeRates.Infrastructure.Factories;
using ExchangeRates.Infrastructure.Repositories;

namespace ExchangeRates.Binder.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyRepository>().As<ICurrencyRepository>();

            builder.RegisterType<SQLiteConnectionFactory>();
        }
    }
}
