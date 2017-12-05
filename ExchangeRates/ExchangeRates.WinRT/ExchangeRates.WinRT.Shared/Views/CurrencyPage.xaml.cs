using ExchangeRates.WinRT.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ExchangeRates.WinRT.Views
{
    public sealed partial class CurrencyPage : Page
    {
        public CurrencyPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var vm = e.Parameter as CurrencyViewModel;

            DataContext = vm;
        }
    }
}
