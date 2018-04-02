using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HN.Bangumi.Http
{
    public class GetMethodCacheHandler : DelegatingHandler
    {
        public GetMethodCacheHandler() : base(new HttpClientHandler())
        {
        }

        public GetMethodCacheHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method != HttpMethod.Get)
            {

                return await base.SendAsync(request, cancellationToken);
            }

            var requestRequestUri = request.RequestUri;

            var cacheKey = "";

            System.IO.File.ReadAllBytes("");

            if (File.Exists(cacheKey))
            {
                var bytes = File.ReadAllBytes(cacheKey);

                return new HttpResponseMessage() {Content = new ByteArrayContent(bytes)};
            }
            else
            {
                var response = await base.SendAsync(request, cancellationToken);
                var bytes = await response.Content.ReadAsByteArrayAsync();

                File.WriteAllBytes(cacheKey, bytes);

                return response;
            }
        }
    }
}