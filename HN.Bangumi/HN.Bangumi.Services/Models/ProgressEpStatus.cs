using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class ProgressEpStatus
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("css_name")]
        public string CssName { get; set; }

        [JsonProperty("url_name")]
        public string UrlName { get; set; }

        [JsonProperty("cn_name")]
        public string ChineseName { get; set; }
    }
}