using Autofac;
using ExchangeRates.WinRT.Facades;
using ExchangeRates.WinRT.Factories;
using ExchangeRates.WinRT.ViewModels;

namespace ExchangeRates.WinRT
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyViewModel>();

            builder.RegisterType<InitializationFacade>();
            builder.RegisterType<CurrencyFactory>();
            builder.RegisterType<CurrencyEntityFactory>();
        }
    }
}
