using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace SqlIntegrationAPI.Models.Domains
{
    [PrimaryKey(nameof(RecId))]
    public partial class DbService
    {
        private string ServiceName;
        private string ServiceTable;
        private string ServiceEndpoint;

        [Key]
        public long RecId { get; }

        [JsonProperty("Enable")]
        public bool Enable { get; set; } = true;

        [Required]
        [StringLength(255)]
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
        [StringLength(255)]
        [JsonProperty("Endpoint")]
        public string Endpoint
        {
            get => ServiceEndpoint;
            set
            {
                ServiceEndpoint = value.Trim();
            }
        }

        [Required]
        [StringLength(255)]
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
        [JsonProperty("Period")]
        public TimeSpan Period { get; set; } = new TimeSpan(0, 30, 0);

        [MaxLength]
        [JsonProperty("QueryString")]
        public string? QueryString { get; set; } = "cross-company=true";

        [Required]
        [JsonProperty("Altered")]
        public bool Altered { get; set; } = false;

        [StringLength(255)]
        public string? Status { get; set; }

        public DateTime? LastRun { get; set; }

        public long? TotalRecordsTracked { get; set; }

        public long? TotalRecordsAdded { get; set; }

        public long? TotalRecordsUpdated { get; set; }

        public TimeSpan? TimeTaken { get; set; }

        public DateTime? NextRun { get; set; }

        [Required]
        [MaxLength]
        [JsonProperty("Columns")]
        public string Columns { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string? ModifiedBy { get; set; }

        public bool Active { get; set; } = true;

    }

}
