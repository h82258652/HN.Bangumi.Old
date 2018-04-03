using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class CollectionInfo
    {
        /// <summary>
        /// 想做
        /// </summary>
        [JsonProperty("wish")]
        public int? Wish { get; set; }

        /// <summary>
        /// 做过
        /// </summary>
        [JsonProperty("collect")]
        public int? Collect { get; set; }

        /// <summary>
        /// 在做
        /// </summary>
        [JsonProperty("doing")]
        public int Doing { get; set; }

        /// <summary>
        /// 搁置
        /// </summary>
        [JsonProperty("on_hold")]
        public int? OnHold { get; set; }

        /// <summary>
        /// 抛弃
        /// </summary>
        [JsonProperty("dropped")]
        public int? Dropped { get; set; }
    }
}