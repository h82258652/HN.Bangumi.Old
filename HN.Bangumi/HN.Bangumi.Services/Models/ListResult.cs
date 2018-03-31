using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class ListResult<T>
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("list")]
        public T[] List { get; set; }
    }
}