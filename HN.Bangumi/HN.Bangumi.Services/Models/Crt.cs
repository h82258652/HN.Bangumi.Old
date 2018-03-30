using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HN.Bangumi.Models
{
    [JsonObject]
   public  class Crt
    { 

        [JsonProperty("id")]
        public int Id { get; set; }


        [JsonProperty("url")]
        public string Url { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }

        public string name_cn { get; set; }

        [JsonProperty("role_name")]
        public string RoleName { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("comment")]
        public int comment { get; set; }


        public int collects { get; set; }


        public info info { get; set; }


        public actor[] actors { get; set; }
    }
}
