using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DataHarvester
{
    public class NbaStatResponseResultSet
    {
        [JsonProperty("name")]
        private string Name { get; set; }
        [JsonProperty("headers")]
        public IEnumerable<string> Headers { get; set; }
        [JsonProperty("rowSet")]
        public IEnumerable<Player> Players { get; set; }
    }
}
