namespace CommonCode.Config
{
    public partial class Services
    {
        [JsonProperty("Services")]
        public List<ServiceDetail> ServiceList { get; set; }
    }

    public partial class ServiceDetail
    {
        [JsonProperty("Run")]
        public bool Run { get; set; } = true;

        [JsonProperty("ServiceConfiguration")]
        public ServiceConfiguration ServiceConfiguration { get; set; }
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
