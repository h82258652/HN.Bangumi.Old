﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Security.Authentication.Web;
using Windows.Security.Credentials;
using Windows.Storage;
using HN.Bangumi.Models;
using HN.Bangumi.OAuth;
using Newtonsoft.Json;

namespace HN.Bangumi.Uwp.OAuth
{
    public class UwpOAuthProvider : IOAuthProvider
    {
        private async Task<string> GetAuthorizeCode()
        {
            var authenticateUrl = $"https://bgm.tv/oauth/authorize?client_id={Constants.AppId}&response_type=code&redirect_uri={WebUtility.UrlEncode(Constants.RedirectUri)}";
            var authenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, new Uri(authenticateUrl), new Uri(Constants.RedirectUri));

            switch (authenticationResult.ResponseStatus)
            {
                case WebAuthenticationStatus.Success:
                    var responseUrl = authenticationResult.ResponseData;
                    var responseUrlDecoder = new WwwFormUrlDecoder(new Uri(responseUrl).Query);
                    var code = responseUrlDecoder.GetFirstValueByName("code");
                    return code;

                case WebAuthenticationStatus.UserCancel:
                    throw new UserCancelAuthorizeException(authenticationResult);

                case WebAuthenticationStatus.ErrorHttp:
                    throw new AuthorizeErrorHttpException(authenticationResult);
            }
            throw new AuthorizationException(authenticationResult);
        }

        private async Task<AccessToken> GetAccessToken(string authorizeCode)
        {
            var postData = new Dictionary<string, string>
            {
                ["grant_type"] = "authorization_code",
                ["client_id"] = Constants.AppId,
                ["client_secret"] = Constants.AppSecret,
                ["code"] = authorizeCode,
                ["redirect_uri"] = Constants.RedirectUri
            };

            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync("https://bgm.tv/oauth/access_token", postContent);
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AccessToken>(json);
                }
            }
        }

        private async Task<AccessToken> GetStorageAccessToken()
        {
            var json = (string)ApplicationData.Current.LocalSettings.Values["AccessToken"];
            if (json == null)
            {
                return null;
            }

            var accessToken = JsonConvert.DeserializeObject<AccessToken>(json);
            var expiresOn = (DateTime)ApplicationData.Current.LocalSettings.Values["AccessTokenExpiresOn"];
            if (DateTime.Now <= expiresOn)
            {
                return accessToken;
            }

            var refreshToken = accessToken.RefreshToken;
            if (refreshToken == null)
            {
                return null;
            }
            return await RefreshAccessToken(refreshToken);
        }

        private async Task<AccessToken> RefreshAccessToken(string refreshToken)
        {
            var postData = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["client_id"] = Constants.AppId,
                ["client_secret"] = Constants.AppSecret,
                ["refresh_token"] = refreshToken,
                ["redirect_uri"] = Constants.RedirectUri
            };
            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync("https://bgm.tv/oauth/access_token", postContent);
                    var json = await response.Content.ReadAsStringAsync();
                    var accessToken = JsonConvert.DeserializeObject<AccessToken>(json);

                    return accessToken;
                }
            }
        }

        public async Task<string> GetAccessToken()
        {
            var accessToken = await GetStorageAccessToken();
            if (accessToken != null)
            {
                return accessToken.Value;
            }

            // main
            var authenticateUrl = $"https://bgm.tv/oauth/authorize?client_id={Constants.AppId}&response_type=code&redirect_uri={WebUtility.UrlEncode(Constants.RedirectUri)}";
            var authenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, new Uri(authenticateUrl), new Uri(Constants.RedirectUri));
            if (authenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var responseUrl = authenticationResult.ResponseData;
                var responseUrlDecoder = new WwwFormUrlDecoder(new Uri(responseUrl).Query);
                var code = responseUrlDecoder.GetFirstValueByName("code");

                await GetAccessToken(code);
            }

            throw new NotImplementedException();
        }
    }
}