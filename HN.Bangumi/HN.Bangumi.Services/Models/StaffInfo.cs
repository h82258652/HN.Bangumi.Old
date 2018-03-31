using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class StaffInfo
    {
        [JsonProperty("alias")]
        public Alias Alias { get; set; }
    }
}