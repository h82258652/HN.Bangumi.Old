using HN.Bangumi.Models;
using Newtonsoft.Json;

namespace HN.Bangumi.Uwp.Models
{
    [JsonObject]
    public class Collection
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subject_id")]
        public int SubjectId { get; set; }

        [JsonProperty("ep_status")]
        public int EpStatus { get; set; }

        [JsonProperty("vol_status")]
        public int VolStatus { get; set; }

        [JsonProperty("lasttouch")]
        public int LastTouch { get; set; }

        [JsonProperty("subject")]
        public Subject Subject { get; set; }
    }
}