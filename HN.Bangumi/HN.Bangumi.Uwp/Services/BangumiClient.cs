using System;
using System.Net.Http;

namespace HN.Bangumi.Uwp.Services
{
    public class BangumiClient : HttpClient
    {
        public BangumiClient() : base(new BangumiClientHandler())
        {
            BaseAddress = new Uri(Constants.BangumiUrlBase);
        }
    }
}