using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using HN.Bangumi.OAuth;

namespace HN.Bangumi.Http
{
    public class OAuthHandler : DelegatingHandler
    {
        private readonly IOAuthProvider _oauthProvider;

        public OAuthHandler(IOAuthProvider oauthProvider) : this(oauthProvider, new HttpClientHandler())
        {
        }

        public OAuthHandler(IOAuthProvider oauthProvider, HttpMessageHandler innerHandler) : base(innerHandler)
        {
            if (oauthProvider == null)
            {
                throw new ArgumentNullException(nameof(oauthProvider));
            }

            _oauthProvider = oauthProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _oauthProvider.GetAccessToken());
            return await base.SendAsync(request, cancellationToken);
        }
    }
}