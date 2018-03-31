using System;
using System.Net.Http;
using HN.Bangumi.OAuth;

namespace HN.Bangumi.Http
{
    public class BangumiClient : HttpClient
    {
        public BangumiClient() : base(new BangumiClientHandler())
        {
            BaseAddress = new Uri(Constants.BangumiUrlBase);
        }

        public BangumiClient(IOAuthProvider oauthProvider) : base(new BangumiClientHandler(new OAuthHandler(oauthProvider)))
        {
            BaseAddress = new Uri(Constants.BangumiUrlBase);
        }
    }
}