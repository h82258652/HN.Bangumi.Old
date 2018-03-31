using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HN.Bangumi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HN.Bangumi.Http
{
    public class BangumiClientHandler : DelegatingHandler
    {
        public BangumiClientHandler() : base(new HttpClientHandler())
        {
        }

        public BangumiClientHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            var json = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<JToken>(json);
            if (token.Type == JTokenType.Object)
            {
                var result = token.ToObject<ErrorResult>();
                if (result.Code != 0 && result.Code != 200)
                {
                    throw new BangumiException(result);
                }
            }
            return response;
        }
    }
}