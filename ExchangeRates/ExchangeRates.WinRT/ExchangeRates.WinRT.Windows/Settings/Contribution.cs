using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ExchangeRates.WinRT.Settings
{
    public class Contribution
    {
        public void Setup()
        {
            SettingsPane settingsPane = SettingsPane.GetForCurrentView();

            settingsPane.CommandsRequested += (s, e) =>
            {
                SettingsCommand settingsCommand = new SettingsCommand(
                  "CONTRIBUTION_ID",
                  "Contribution",
                  command =>
                  {
                      var flyout = new SettingsFlyout();
                      flyout.Title = "About";

                      flyout.Content = new TextBlock()
                      {
                          Text = "Application uses http://fixer.io/ API for getting the data published by European Central Bank. " 
                          + "Thanks to the Fixer API, the application is able to read valid data.",
                          TextAlignment = Windows.UI.Xaml.TextAlignment.Left,
                          TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap,
                          FontSize = 14
                      };

                      flyout.HeaderBackground = new SolidColorBrush(Colors.Purple);
                      flyout.HeaderForeground = new SolidColorBrush(Colors.BlanchedAlmond);
                      flyout.Background = new SolidColorBrush(Colors.Black);
                      flyout.Foreground = new SolidColorBrush(Colors.White);

                      flyout.Show();
                  }
                );

                e.Request.ApplicationCommands.Add(settingsCommand);
            };
        }
    }
}
