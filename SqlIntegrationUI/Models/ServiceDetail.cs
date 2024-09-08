using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI.Models
{
    public partial class DBServices
    {
        [JsonProperty("Services")]
        public HashSet<ServiceDetail> ServiceSet { get; set; } = [];
    }

    [PrimaryKey(nameof(RecId))]
    public partial class DBServiceDetail
    {
        private string ServiceName;
        private string ServiceTable;
        private string ServiceEndpoint;

        [Key]
        public long RecId { get; }

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

        public string? Status { get; set; }

        public string? LastRun { get; set; }

        public long? TotalRecordsTracked { get; set; }

        public long? TotalRecordsAdded { get; set; }

        public long? TotalRecordsUpdated { get; set; }

        public int? TimeTaken { get; set; }

        public string? NextRun { get; set; }

        [Required]
        [MaxLength]
        [JsonProperty("Columns")]
        public string Columns { get; set; }

        [Required]
        public readonly DateTime CreatedDate = DateTime.Now;

        [Required]
        [StringLength(255)]
        public string CreatedBy;

        public DateTime? ModifiedDate;

        [StringLength(255)]
        public string? ModifiedBy;
    }

    [Keyless]
    public partial class DBColumn
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Include")]
        public bool Include { get; set; } = true;
    }
}
