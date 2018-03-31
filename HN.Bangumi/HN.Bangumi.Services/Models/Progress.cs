using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class Progress
    {
        [JsonProperty("subject_id")]
        public int SubjectId { get; set; }

        [JsonProperty("eps")]
        public ProgressEp[] Eps { get; set; }
    }
}