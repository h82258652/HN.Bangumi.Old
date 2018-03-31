using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class ErrorResult
    {
        [JsonProperty("request")]
        public string Request { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}