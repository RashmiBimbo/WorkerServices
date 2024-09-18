using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CommonCode.Models.Dtos
{
    public class ServiceDto
    {
        public bool Enable { get; set; } = true;

        [Required]
        [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\-_]*$")]
        public string Endpoint { get; set; }

        public string? QueryString { get; set; }

        public TimeSpan Period { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string Table { get; set; }

        public bool? TableAltered { get; set; }

        public string? Status { get; set; }

        public DateTime? LastRun { get; set; }

        public long? TotalRecordsTracked { get; set; }

        public long? TotalRecordsAdded { get; set; }

        public long? TotalRecordsUpdated { get; set; }

        public TimeSpan? TimeTaken { get; set; }

        public DateTime? NextRun { get; set; }

        public string Columns { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s]*$")]
        public string CreatedBy { get; set; }

    }
}
