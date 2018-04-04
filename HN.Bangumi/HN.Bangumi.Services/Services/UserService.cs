using System;
using System.Net;
using System.Threading.Tasks;
using HN.Bangumi.Http;
using HN.Bangumi.Models;
using HN.Bangumi.OAuth;
using Newtonsoft.Json;

namespace HN.Bangumi.Services
{
    public class UserService
    {
        private readonly IOAuthProvider _oauthProvider;

        public UserService(IOAuthProvider oauthProvider)
        {
            if (oauthProvider == null)
            {
                throw new ArgumentNullException(nameof(oauthProvider));
            }

            _oauthProvider = oauthProvider;
        }

        /// <summary>
        /// 用户基础信息
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
        /// 用户基础信息
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

        public async Task<UserCollection[]> GetCollection(string username, CollectionCategory category, ResponseGroup responseGroup = ResponseGroup.Medium)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }
            if (!Enum.IsDefined(typeof(CollectionCategory), category))
            {
                throw new ArgumentOutOfRangeException(nameof(category));
            }
            if (!Enum.IsDefined(typeof(ResponseGroup), responseGroup))
            {
                throw new ArgumentOutOfRangeException(nameof(responseGroup));
            }

            var url = $"/user/{WebUtility.UrlEncode(username)}/collection?cat={(category == CollectionCategory.Watching ? "watching" : "all_watching")}&responseGroup={responseGroup.ToString().ToLowerInvariant()}";
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<UserCollection[]>(json);
            }
        }

        public async Task<UserCollection[]> GetCollection(int uid, CollectionCategory category, ResponseGroup responseGroup = ResponseGroup.Medium)
        {
            if (!Enum.IsDefined(typeof(CollectionCategory), category))
            {
                throw new ArgumentOutOfRangeException(nameof(category));
            }
            if (!Enum.IsDefined(typeof(ResponseGroup), responseGroup))
            {
                throw new ArgumentOutOfRangeException(nameof(responseGroup));
            }

            var url = $"/user/{uid}/collection?cat={(category == CollectionCategory.Watching ? "watching" : "all_watching")}&responseGroup={responseGroup.ToString().ToLowerInvariant()}";
            using (var client = new BangumiClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<UserCollection[]>(json);
            }
        }

        /// <summary>
        /// 用户收视进度
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="subjectId">条目 ID</param>
        /// <returns></returns>
        public async Task<Progress[]> GetProgress(string username, int? subjectId = null)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var url = $"/user/{WebUtility.UrlEncode(username)}/progress";
            if (subjectId.HasValue)
            {
                url += $"?subject_id={subjectId}";
            }
            using (var client = new BangumiClient(_oauthProvider))
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Progress[]>(json);
            }
        }

        /// <summary>
        /// 用户收视进度
        /// </summary>
        /// <param name="uid">UID</param>
        /// <param name="subjectId">条目 ID</param>
        /// <returns></returns>
        public async Task<Progress[]> GetProgress(int uid, int? subjectId = null)
        {
            var url = $"/user/{uid}/progress";
            if (subjectId.HasValue)
            {
                url += $"?subject_id={subjectId}";
            }
            using (var client = new BangumiClient(_oauthProvider))
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Progress[]>(json);
            }
        }

        public async Task<SubjectCollectionInfo> GetSubjectCollectionInfo(int subjectId)
        {
            var url = $"/collection/{subjectId}";
            using (var client = new BangumiClient(_oauthProvider))
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<SubjectCollectionInfo>(json);
            }
        }
    }
}