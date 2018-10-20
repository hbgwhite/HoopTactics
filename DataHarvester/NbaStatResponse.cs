using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DataHarvester
{
    public class NbaStatResponse
    {
        [JsonProperty("resource")]
        public string Resource { get; set; }
        [JsonProperty("parameters")]
        public NbaStatResponseParameters Metadata { get; set; }
        [JsonProperty("resultSet")]
        public NbaStatResponseResultSet ResultSet { get; set; }
    }
}
