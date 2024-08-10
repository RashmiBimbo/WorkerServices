
namespace CommonCode.Config
{
    public partial class Services
    {
        [JsonProperty("Services")]
        public HashSet<ServiceDetail> ServiceSet { get; set; }
    }

    public partial class ServiceDetail
    {
        [JsonProperty("Enable")]
        public bool Enable { get; set; } = true;

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("QueryString")]
        public string QueryString { get; set; }

        [JsonProperty("Period")]
        public int Period { get; set; } = 30;

        [JsonProperty("Table")]
        public string Table { get; set; }

        [JsonProperty("Altered")]
        public bool Altered { get; set; } = false;

        [JsonProperty("Columns")]
        public List<Column> Columns { get; set; }

        //[JsonProperty("ServiceConfiguration")]
        //public ServiceConfiguration ServiceConfiguration { get; set; }
    }

    public partial class ServiceConfiguration
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("Period")]
        public long Period { get; set; } = 30;

        [JsonProperty("Table")]
        public string Table { get; set; }

        [JsonProperty("QueryString")]
        public string QueryString { get; set; } = "cross-company=true";

        [JsonProperty("Altered")]
        public bool Altered { get; set; } = false;

        [JsonProperty("Columns")]
        public List<Column> Columns { get; set; }
    }

    public partial class Column
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Include")]
        public bool Include { get; set; }
    }
}
