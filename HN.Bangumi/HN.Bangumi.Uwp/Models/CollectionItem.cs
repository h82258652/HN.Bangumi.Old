using Newtonsoft.Json;

namespace HN.Bangumi.Uwp.Models
{
    [JsonObject]
    public class CollectionItem
    {
        [JsonProperty("doing")]
        public int Doing { get; set; }
    }
}