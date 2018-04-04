using System.Linq;
using Windows.Security.Credentials;
using HN.Bangumi.Services;
using HN.Bangumi.Uwp.Configuration;
using HN.Bangumi.Uwp.OAuth;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HN.Bangumi.Uwp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(CalendarView));
            var appSettings = new AppSettings();
            //appSettings.ClearAccessToken();
            var appSettingsAccessToken = appSettings.AccessToken;
        }
    }
}