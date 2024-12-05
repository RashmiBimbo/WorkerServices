using static CommonCode.CommonClasses.Common;
using System.ComponentModel.DataAnnotations;

namespace CommonCode.CommonClasses
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
        private TimeSpan _period = TimeSpan.FromMinutes(300); // Default value set here

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
        public TimeSpan Period
        {
            get => _period;
            set
            {
                // Set default value if no value is provided or a wrong type is assigned
                if (value == TimeSpan.Zero)
                {
                    _period = TimeSpan.FromMinutes(300);
                }
                else
                {
                    _period = value;
                }
            }
        }

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
        [JsonProperty("TableAltered")]
        public bool TableAltered { get; set; } = false;

        public string? Status { get; set; }

        public DateTime? LastRun { get; set; }

        public long? TotalRecordsTracked { get; set; }

        public long? TotalRecordsAdded { get; set; }

        public long? TotalRecordsUpdated { get; set; }

        public TimeSpan? TimeTaken { get; set; }

        public DateTime? NextRun { get; set; }

        [JsonProperty("Columns")]
        public List<Column> Columns { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s]*$")]
        public string CreatedBy { get; set; } = "Rashmi";

        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s]*$")]
        public string? ModifiedBy { get; set; }
    }

    public partial class Column
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Include")]
        public bool Include { get; set; } = true;
    }
}
