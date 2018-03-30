using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
  public  class Staff
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public string url { get; set; }

        public string name { get; set; }


        public string name_cn { get; set; }


        public images images { get; set; }


        public int comment { get; set; }

        public int collects { get; set; }

        [JsonProperty("info")]
        public info Info { get; set; }


        public job[] jobs { get; set; }
    }
}
