using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class SubjectCollectionStatus
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}