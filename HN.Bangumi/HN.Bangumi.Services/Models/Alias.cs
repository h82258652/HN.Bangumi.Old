using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class Alias
    {
        [JsonProperty("jp")]
        public string Jp { get; set; }

        [JsonProperty("kana")]
        public string Kana { get; set; }

        [JsonProperty("romaji")]
        public string Romaji { get; set; }

        [JsonProperty("zh")]
        public string Zh { get; set; }
    }
}