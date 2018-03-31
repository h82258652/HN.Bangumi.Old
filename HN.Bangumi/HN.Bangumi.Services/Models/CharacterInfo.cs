using HN.Bangumi.Json;
using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class CharacterInfo
    {
        [JsonProperty("birth")]
        public string Birth { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("alias")]
        public Alias Alias { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(SingleItemArrayConverter))]
        public string[] Source { get; set; }

        [JsonProperty("name_cn")]
        public string ChineseName { get; set; }

        [JsonProperty("cv")]
        public string Cv { get; set; }
    }
}