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
        public long RecId { get; set; }

        [JsonProperty("Enable")]
        public bool Enable { get; set; } = true;

        [Required]
        [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
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
        [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        [JsonProperty("Endpoint")]
        [Key]
        public string Endpoint
        {
            get => ServiceEndpoint;
            set
            {
                ServiceEndpoint = value.Trim();
            }
        }

        [Required]
        [StringLength(255, ErrorMessage = "The table name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The table name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
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
        [JsonProperty("TableAltered")]
        public bool TableAltered { get; set; } = false;

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
        [StringLength(255, ErrorMessage = "The Created By field has to be maximum of 255 characters")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255, ErrorMessage = "The Modified By field has to be maximum of 255 characters")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        public string? ModifiedBy { get; set; }

        public bool Active { get; set; } = true;

    }

}
