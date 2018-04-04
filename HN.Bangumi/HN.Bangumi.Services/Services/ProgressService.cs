using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HN.Bangumi.Http;
using HN.Bangumi.Models;
using HN.Bangumi.OAuth;

namespace HN.Bangumi.Services
{
    public class ProgressService
    {
        private readonly IOAuthProvider _oauthProvider;

        public ProgressService(IOAuthProvider oauthProvider)
        {
            if (oauthProvider == null)
            {
                throw new ArgumentNullException(nameof(oauthProvider));
            }

            _oauthProvider = oauthProvider;
        }

        public async Task Update(int epId, EpStatus status)
        {
            if (!Enum.IsDefined(typeof(EpStatus), status))
            {
                throw new ArgumentOutOfRangeException(nameof(status));
            }

            var url = $"/ep/{epId}/status/{status.ToString().ToLowerInvariant()}";
            using (var client = new BangumiClient(_oauthProvider))
            {
                using (var postContent = new FormUrlEncodedContent(Enumerable.Empty<KeyValuePair<string, string>>()))
                {
                    await client.PostAsync(url, postContent);
                }
            }
        }

        public async Task Update(int[] epId, EpStatus status)
        {
            if (epId == null)
            {
                throw new ArgumentNullException(nameof(epId));
            }
            if (epId.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(status));
            }
            if (!Enum.IsDefined(typeof(EpStatus), status))
            {
                throw new ArgumentOutOfRangeException(nameof(status));
            }

            var url = $"/ep/{epId.Last()}/status/{status.ToString().ToLowerInvariant()}";
            using (var client = new BangumiClient(_oauthProvider))
            {
                using (var postContent = new FormUrlEncodedContent(Enumerable.Empty<KeyValuePair<string, string>>()))
                {
                    await client.PostAsync(url, postContent);
                }
            }
        }
    }
}