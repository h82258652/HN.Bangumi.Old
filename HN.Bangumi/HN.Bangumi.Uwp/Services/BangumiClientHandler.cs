using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HN.Bangumi.Uwp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HN.Bangumi.Uwp.Services
{
    public class BangumiClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            var json = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<JToken>(json);
            if (token.Type == JTokenType.Object)
            {
                var result = token.ToObject<ErrorResult>();
                if (result.Code != 0)
                {
                    throw new BangumiException(result);
                }
            }
            return response;
        }
    }
}