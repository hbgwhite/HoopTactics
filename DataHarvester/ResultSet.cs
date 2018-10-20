using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DataHarvester
{
    public class ResultSet
    {
        [JsonProperty("rowSet")]
        public IEnumerable<Player> Players { get; set; }
        [JsonProperty("headers")]
        public IEnumerable<string> Headers { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}
