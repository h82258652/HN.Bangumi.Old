using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class UserCollection
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
        public long LastTouch { get; set; }

        [JsonProperty("subject")]
        public Subject Subject { get; set; }
    }
}