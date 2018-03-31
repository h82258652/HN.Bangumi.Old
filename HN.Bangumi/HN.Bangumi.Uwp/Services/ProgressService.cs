using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HN.Bangumi.Http;

namespace HN.Bangumi.Uwp.Services
{
    public class ProgressService
    {
        public async Task<object> Update(int subjectId, string watchedEps, string watchedVols = null)
        {
            if (watchedEps == null)
            {
                throw new ArgumentNullException(nameof(watchedEps));
            }

            var postData = new Dictionary<string, string>
            {
                ["watched_eps"] = watchedEps
            };
            if (watchedVols != null)
            {
                postData["watched_vols"] = watchedVols;
            }

            using (var client = new BangumiClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync($"/subject/{subjectId}/update/watched_eps", postContent);
                    var json = await response.Content.ReadAsStringAsync();
                    throw new NotImplementedException();
                }
            }
        }
    }
}