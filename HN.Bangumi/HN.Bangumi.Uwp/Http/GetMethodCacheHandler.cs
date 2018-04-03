using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Abp.Extensions;
using Windows.Storage;

namespace HN.Bangumi.Uwp.Http
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

            var requestUri = request.RequestUri;
            var cacheFileName = requestUri.AbsoluteUri.ToMd5();
            var cacheFilePath = Path.Combine(ApplicationData.Current.TemporaryFolder.Path, cacheFileName);

            if (File.Exists(cacheFilePath))
            {
                return new HttpResponseMessage()
                {
                    Content = new StreamContent(File.OpenRead(cacheFilePath))
                };
            }

            var response = await base.SendAsync(request, cancellationToken);
            var bytes = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(cacheFilePath, bytes, cancellationToken);
            return response;
        }
    }
}