namespace CommonCode.Config
{
    public partial class Services
    {
        [JsonProperty("Services", NullValueHandling = NullValueHandling.Ignore)]
        public List<Service> ServiceList { get; set; }
    }

    public partial class Service
    {
        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("ServiceConfiguration", NullValueHandling = NullValueHandling.Ignore)]
        public ServiceConfiguration ServiceConfiguration { get; set; }
    }

    public partial class ServiceConfiguration
    {
        [JsonProperty("Run", NullValueHandling = NullValueHandling.Ignore)]
        public bool Run { get; set; }

        [JsonProperty("Period", NullValueHandling = NullValueHandling.Ignore)]
        public long Period { get; set; }

        [JsonProperty("Table", NullValueHandling = NullValueHandling.Ignore)]
        public string Table { get; set; }

        [JsonProperty("Columns", NullValueHandling = NullValueHandling.Ignore)]
        public List<Column> Columns { get; set; }
    }

    public partial class Column
    {
        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Add", NullValueHandling = NullValueHandling.Ignore)]
        public bool Add { get; set; }
    }
}
