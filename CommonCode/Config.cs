using static CommonCode.Common;
using System.ComponentModel.DataAnnotations;

namespace CommonCode.Config
{
    public partial class Services 
    {
        [JsonProperty("Services")]
        public HashSet<ServiceDetail> ServiceSet { get; set; } = [];
    }

    public partial class ServiceDetail
    {
        private string ServiceName;
        private string ServiceTable;
        private string ServiceEndpoint;

        [JsonProperty("Enable")]
        public bool Enable { get; set; } = true;

        [Required]
        [JsonProperty("Name")]
        public string Name
        {
            get => ServiceName;
            set
            {
                ServiceName = IsEmpty(value) ? Endpoint : value.Trim();
            }
        }

        [Required]
        [JsonProperty("Endpoint")]
        public string Endpoint
        {
            get => ServiceEndpoint;
            set
            {
                ServiceEndpoint = value.Trim();
            }
        }

        [JsonProperty("QueryString")]
        public string? QueryString { get; set; } = "cross-company=true";

        [Required]
        [JsonProperty("Period")]
        public int Period { get; set; } = 30;

        [Required]
        [JsonProperty("Table")]
        public string Table
        {
            get => ServiceTable;
            set
            {
                ServiceTable = IsEmpty(value) ? Endpoint + "Test" : value.Trim();
            }
        }

        [Required]
        [JsonProperty("Altered")]
        public bool Altered { get; set; } = false;

        public string Status { get; set; }

        public string LastRun { get; set; }

        public int TotalRecordsTracked { get; set; }

        public int TotalRecordsAdded { get; set; }

        public int TotalRecordsUpdated { get; set; }

        public int TimeTaken { get; set; }

        public string NextRun { get; set; }

        [JsonProperty("Columns")]
        public List<Column> Columns { get; set; }
    }

    public partial class Column
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Include")]
        public bool Include { get; set; } = true;
    }
}
