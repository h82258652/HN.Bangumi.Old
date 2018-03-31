using HN.Bangumi.Json;
using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class Subject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_cn")]
        public string ChineseName { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// 章节信息
        /// </summary>
        [JsonProperty("eps")]
        [JsonConverter(typeof(TryParseConverter))]
        public Ep[] Eps { get; set; }

        [JsonProperty("eps_count")]
        public int EpsCount { get; set; }

        [JsonProperty("air_date")]
        public string AirDate { get; set; }

        [JsonProperty("air_weekday")]
        public int AirWeekday { get; set; }

        [JsonProperty("rating")]
        public Rating Rating { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        /// <summary>
        /// 收藏信息
        /// </summary>
        [JsonProperty("collection")]
        public CollectionInfo Collection { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        [JsonProperty("crt")]
        public Character[] Characters { get; set; }

        /// <summary>
        /// 制作人员信息
        /// </summary>
        [JsonProperty("staff")]
        public Staff[] Staff { get; set; }

        /// <summary>
        /// 讨论版
        /// </summary>
        [JsonProperty("topic")]
        public Topic[] Topic { get; set; }

        /// <summary>
        /// 评论日志
        /// </summary>
        [JsonProperty("blog")]
        public Blog[] Blog { get; set; }
    }
}