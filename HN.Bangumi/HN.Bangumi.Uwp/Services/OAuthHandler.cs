using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Security.Authentication.Web;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace HN.Bangumi.Uwp.Services
{
    public class OAuthHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            WebAuthenticationResult authenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None,new Uri($"https://bgm.tv/oauth/authorize?client_id={Constants.AppId}&response_type=code"));
            if (authenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var responseUrl = authenticationResult.ResponseData;
                var responseUriDecoder = new WwwFormUrlDecoder(new Uri(responseUrl).Query);
                var code = responseUriDecoder.GetFirstValueByName("code");
            }

            request.Headers.Authorization = AuthenticationHeaderValue.Parse("");

            return await base.SendAsync(request, cancellationToken);
        }

        private async void GetAccessToken(string code)
        { 
            using (var client = new HttpClient())
            {
                Dictionary<string, string> postData = new Dictionary<string, string>();
                postData["grant_type"] = "authorization_code";
                postData["client_id"] = Constants.AppId;
                postData["client_secret"] = Constants.AppSecret;
                postData["code"] = code;
                postData["redirect_uri"] = "";

                var postContent= new FormUrlEncodedContent(postData);
                var response = await client.PostAsync("https://bgm.tv/oauth/access_token", postContent);
                var json = await response.Content.ReadAsStringAsync();
                var xx = JsonConvert.DeserializeObject(json);
            }
        }
    }
}