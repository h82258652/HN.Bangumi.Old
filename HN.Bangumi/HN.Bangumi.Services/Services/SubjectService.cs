using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HN.Bangumi.Http;
using HN.Bangumi.Models;
using Newtonsoft.Json;

namespace HN.Bangumi.Services
{
    public class SubjectService
    {
        public async Task<Subject> Get(int id, ResponseGroup responseGroup = ResponseGroup.Small)
        {
            if (!Enum.IsDefined(typeof(ResponseGroup), responseGroup))
            {
                throw new ArgumentOutOfRangeException(nameof(responseGroup));
            }

            var url = $"/subject/{id}?responseGroup={responseGroup.ToString().ToLowerInvariant()}";
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Subject>(json);
            }
        }

        public async Task<Subject> GetEps(int subjectId)
        {
            var url = $"/subject/{subjectId}/ep";
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Subject>(json);
            }
        }

        public async Task<ListResult<Subject>> Search(string keywords, SubjectType? type = null, ResponseGroup responseGroup = ResponseGroup.Small, int start = 0, int maxResults = 10)
        {
            if (keywords == null)
            {
                throw new ArgumentNullException(nameof(keywords));
            }
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            if (maxResults <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxResults));
            }

            var url = $"/search/subject/{WebUtility.UrlEncode(keywords)}";
            var query = new Dictionary<string, string>();
            if (type.HasValue)
            {
                query["type"] = ((int)type.Value).ToString();
            }
            query["responseGroup"] = responseGroup.ToString().ToLowerInvariant();
            query["start"] = start.ToString();
            query["max_results"] = maxResults.ToString();
            if (query.Count > 0)
            {
                url += "?" + string.Join("&", query.Select(temp => temp.Key + "=" + WebUtility.UrlEncode(temp.Value)));
            }
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ListResult<Subject>>(json);
            }
        }
    }
}