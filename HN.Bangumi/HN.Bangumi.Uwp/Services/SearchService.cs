using System;
using System.Net;
using System.Threading.Tasks;
using HN.Bangumi.Uwp.Models;
using HN.Bangumi.Uwp.Models.Enum;
using Newtonsoft.Json;

namespace HN.Bangumi.Uwp.Services
{
    public class SearchService
    {
        public async Task<Subject[]> Search(string keywords, SubjectType? type, int start, int maxResults = 25)
        {
            var url = $"/search/subject/{WebUtility.UrlEncode(keywords)}";

            // todo handle parameters
            throw new NotImplementedException();

            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Subject[]>(json);
            }
        }
    }
}