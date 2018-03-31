using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_cn")]
        public string ChineseName { get; set; }

        [JsonProperty("role_name")]
        public string RoleName { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("comment")]
        public int Comment { get; set; }

        [JsonProperty("collects")]
        public int Collects { get; set; }

        [JsonProperty("info")]
        public CharacterInfo Info { get; set; }

        [JsonProperty("actors")]
        public Actor[] Actors { get; set; }
    }
}