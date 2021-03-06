﻿using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
    public class SubjectCollectionInfo
    {
        [JsonProperty("status")]
        public SubjectCollectionStatus Status { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("private")]
        public int Private { get; set; }

        [JsonProperty("tag")]
        public string[] Tag { get; set; }

        [JsonProperty("ep_status")]
        public int EpStatus { get; set; }

        [JsonProperty("lasttouch")]
        public long LastTouch { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}