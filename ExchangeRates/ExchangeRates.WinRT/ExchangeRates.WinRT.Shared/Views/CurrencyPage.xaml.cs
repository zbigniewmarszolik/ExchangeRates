using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using ExchangeRates.UI.ViewModels;

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

            vm.PopErrorAction = x => PopErrorAsync(x);
        }

        private async void PopErrorAsync(string errorValue)
        {
            UICommand okButton = new UICommand("OK");

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                async () =>
                {
                    var dialog = new MessageDialog(errorValue, "ERROR");
                    dialog.Commands.Add(okButton);
                    await dialog.ShowAsync();
                });
        }
    }
}
