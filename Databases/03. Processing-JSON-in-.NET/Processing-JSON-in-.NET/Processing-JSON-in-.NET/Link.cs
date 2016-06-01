using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Processing_JSON_in_.NET
{
    public class Link
    {
        [JsonProperty("@href")]
        public string Path { get; set; }
    }
}
