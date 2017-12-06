using Autofac;
using ExchangeRates.UI.Enums;
using ExchangeRates.UI.Facades;
using ExchangeRates.UI.Factories;
using ExchangeRates.UI.Helpers;
using ExchangeRates.UI.Strategies;
using ExchangeRates.UI.ViewModels;

namespace ExchangeRates.Binder.Modules
{
    public class UserInterfaceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyViewModel>();

            builder.RegisterType<InitializationFacade>().As<IInitializationFacade>();

            builder.RegisterType<CurrencyFactory>();
            builder.RegisterType<CurrencyEntityFactory>();
            builder.RegisterType<DataStrategyFactory>().SingleInstance();

            builder.RegisterType<CurrencyDescriptionHelper>();

            builder.RegisterType<HttpDataStrategy>().Keyed<IDataStrategy>(EDataType.InternetData);
            builder.RegisterType<SqlDataStrategy>().Keyed<IDataStrategy>(EDataType.DatabaseData);
        }
    }
}
