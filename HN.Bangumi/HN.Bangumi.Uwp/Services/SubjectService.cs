using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HN.Bangumi.Uwp.Models;
using HN.Bangumi.Uwp.Models.Enum;
using Newtonsoft.Json;

namespace HN.Bangumi.Uwp.Services
{
    public class SubjectService
    {

        public async Task<Subject> GetSubject(int id, ResponseGroup responseGroup)
        {
            using (var client = new BangumiClient())
            {
           var json  =      await client.GetStringAsync($"/subject/{id}");
                return JsonConvert.DeserializeObject<Subject>(json);
            }
        }
    }
}
