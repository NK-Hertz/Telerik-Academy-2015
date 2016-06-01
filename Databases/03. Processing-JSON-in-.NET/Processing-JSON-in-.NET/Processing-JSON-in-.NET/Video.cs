using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Processing_JSON_in_.NET
{
    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("yt:videoId")]
        public string Id { get; set; }
    }
}
