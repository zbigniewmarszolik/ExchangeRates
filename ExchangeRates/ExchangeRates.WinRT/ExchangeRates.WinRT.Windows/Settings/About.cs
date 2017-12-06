using Windows.ApplicationModel;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ExchangeRates.WinRT.Settings
{
    public class About
    {
        public void Setup()
        {
            SettingsPane settingsPane = SettingsPane.GetForCurrentView();

            settingsPane.CommandsRequested += (s, e) =>
            {
                SettingsCommand settingsCommand = new SettingsCommand(
                  "ABOUT_ID",
                  "About",
                  command =>
                  {
                      var flyout = new SettingsFlyout();
                      flyout.Title = "About";

                      var version = Package.Current.Id.Version;
                      var versionstring = string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);

                      flyout.Content = new TextBlock()
                      {
                          Text = "Developed by Zbigniew Marszolik\r\nVersion " + versionstring +
                          "\r\n\r\nThis is an Windows 8.1 application showing up-to-date currency exchange rates published by European Central Bank.",
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
