using System.Threading.Tasks;
using HN.Bangumi.Http;
using HN.Bangumi.Models;
using Newtonsoft.Json;

namespace HN.Bangumi.Services
{
    public class CalendarService
    {
        public async Task<Calendar[]> GetAsync()
        {
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync("/calendar");
                return JsonConvert.DeserializeObject<Calendar[]>(json);
            }
        }
    }
}