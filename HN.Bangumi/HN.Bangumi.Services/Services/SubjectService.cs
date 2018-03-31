using System;
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
    }
}