using System;
using System.Linq;
using Windows.Security.Credentials;
using Windows.Storage;

namespace HN.Bangumi.Uwp.Configuration
{
    public class AppSettings
    {
        public DateTimeOffset? AccessTokenExpiresOn
        {
            get
            {
                return (DateTimeOffset?)ApplicationData.Current.LocalSettings.Values["AccessTokenExpiresOn"];
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values["AccessTokenExpiresOn"] = value;
            }
        }

        public string RefreshToken
        {
            get
            {
                var passwordVault = new PasswordVault();
                return passwordVault.RetrieveAll()
                    .FirstOrDefault(temp => temp.Resource == Constants.BangumiAccessTokenResourceKey && temp.UserName == "refresh_token")
                    ?.Password;
            }
        }
    }
}