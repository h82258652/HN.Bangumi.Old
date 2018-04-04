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
            var passwordVault = new PasswordVault();
            passwordVault.Add(new PasswordCredential(Constants.BangumiAccessTokenResourceKey, "userId", "200242"));
            var passwordCredentials = passwordVault.RetrieveAll().ToList();
            foreach (var credential in passwordCredentials)
            {
                credential.RetrievePassword();
            }

            return;
            //Frame.Navigate(typeof(CalendarView));
            var appSettings = new AppSettings();
            //appSettings.ClearAccessToken();
            var process = await new UserService(new UwpOAuthProvider(appSettings)).GetProgress("h82258652");
        }
    }
}