using HN.Bangumi.Json;
using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class StaffInfo
    {
        [JsonProperty("alias")]
        [JsonConverter(typeof(AliasConverter))]
        public Alias Alias { get; set; }
    }
}