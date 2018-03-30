using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class Ep
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("sort")]
        public int Sort { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_cn")]
        public string ChineseName { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("airdate")]
        public string Airdate { get; set; }

        [JsonProperty("comment")]
        public int Comment { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}