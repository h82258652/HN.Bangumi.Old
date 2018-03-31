using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class ProgressEp
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public ProgressEpStatus Status { get; set; }
    }
}