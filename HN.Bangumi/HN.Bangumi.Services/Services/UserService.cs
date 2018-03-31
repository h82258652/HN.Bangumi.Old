using System;
using System.Net;
using System.Threading.Tasks;
using HN.Bangumi.Http;
using HN.Bangumi.Models;
using Newtonsoft.Json;

namespace HN.Bangumi.Services
{
    public class UserService
    {
        /// <summary>
        /// 返回用户基础信息
        /// </summary>
        /// <param name="uid">UID</param>
        /// <returns></returns>
        public async Task<User> Get(int uid)
        {
            var url = $"/user/{uid}";
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<User>(json);
            }
        }

        /// <summary>
        /// 返回用户基础信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public async Task<User> Get(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var url = $"/user/{WebUtility.UrlEncode(username)}";
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<User>(json);
            }
        }
    }
}