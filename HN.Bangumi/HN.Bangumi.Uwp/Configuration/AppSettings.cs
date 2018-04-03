using System;
using System.Linq;
using HN.Bangumi.Models;
using Windows.Security.Credentials;
using Windows.Storage;

namespace HN.Bangumi.Uwp.Configuration
{
    public class AppSettings
    {
        public string AccessToken
        {
            get
            {
                var passwordVault = new PasswordVault();
                return passwordVault.RetrieveAll()
                    .FirstOrDefault(temp => temp.Resource == Constants.BangumiAccessTokenResourceKey && temp.UserName == "access_token")
                    ?.Password;
            }
        }

        public DateTimeOffset? AccessTokenExpiresOn => (DateTimeOffset?)ApplicationData.Current.LocalSettings.Values["AccessTokenExpiresOn"];

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

        public void ClearAccessToken()
        {
            var passwordVault = new PasswordVault();
            foreach (var credential in passwordVault.RetrieveAll().Where(temp => temp.Resource == Constants.BangumiAccessTokenResourceKey))
            {
                passwordVault.Remove(credential);
            }
            ApplicationData.Current.LocalSettings.Values["AccessTokenExpiresOn"] = null;
        }

        public void SetAccessToken(AccessToken accessToken)
        {
            if (accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            var passwordVault = new PasswordVault();
            passwordVault.Add(new PasswordCredential(Constants.BangumiAccessTokenResourceKey, "access_token", accessToken.Value));
            passwordVault.Add(new PasswordCredential(Constants.BangumiAccessTokenResourceKey, "refresh_token", accessToken.RefreshToken));
            passwordVault.Add(new PasswordCredential(Constants.BangumiAccessTokenResourceKey, "user_id", accessToken.UserId.ToString()));
            ApplicationData.Current.LocalSettings.Values["AccessTokenExpiresOn"] = DateTimeOffset.UtcNow.AddSeconds(accessToken.ExpiresIn).AddMinutes(-5);
        }
    }
}