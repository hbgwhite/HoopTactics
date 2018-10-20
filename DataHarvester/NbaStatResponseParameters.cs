using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DataHarvester
{
    public class NbaStatResponseParameters
    {
        [JsonProperty("LeagueID")]
        public int LeagueId { get; set; }
        [JsonProperty("PerMode")]
        public string StatMode { get; set; }
        [JsonProperty("StatCategory")]
        public string RankedBy { get; set; }
        [JsonProperty("Season")]
        public string StatYear { get; set; }
        public string SeasonType { get; set; }
        public string Scope { get; set; }
        public string ActiveFlag { get; set; }
    }
}
