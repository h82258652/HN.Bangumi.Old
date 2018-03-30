using System;
using System.Net;
using System.Threading.Tasks;
using HN.Bangumi.Uwp.Models;
using Newtonsoft.Json;

namespace HN.Bangumi.Uwp.Services
{
    public class UserService
    {
        public async Task<User> GetUser(int uid)
        {
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync($"/user/{uid}");
                return JsonConvert.DeserializeObject<User>(json);
            }
        }

        public async Task<User> GetUser(string username)
        {
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync($"/user/{WebUtility.UrlEncode(username)}");
                return JsonConvert.DeserializeObject<User>(json);
            }
        }

        public async Task<Collection[]> GetCollection(string username)
        {
            // TODO has more parameters https://github.com/bangumi/api/blob/master/docs-raw/User-API.md

            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync($"/user/{WebUtility.UrlEncode(username)}/collection");
                return JsonConvert.DeserializeObject<Collection[]>(json);
            }
        }

        public async void GetCollection(int uid)
        {
            throw new NotImplementedException();
        }
    }
}