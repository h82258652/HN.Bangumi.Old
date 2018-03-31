using System;
using System.Net.Http;

namespace HN.Bangumi.Http
{
    public class BangumiClient : HttpClient
    {
        public BangumiClient() : base(new BangumiClientHandler())
        {
            BaseAddress = new Uri(Constants.BangumiUrlBase);
        }
    }
}