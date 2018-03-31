using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class Calendar
    {
        [JsonProperty("weekday")]
        public Weekday Weekday { get; set; }

        [JsonProperty("items")]
        public Subject[] Items { get; set; }
    }
}