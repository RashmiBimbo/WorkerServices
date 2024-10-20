using System.ComponentModel.DataAnnotations;

namespace CommonCode.Models.Dtos.Requests
{
    public class CreateServiceRequestDto
    {
        [Required]
        [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string Endpoint { get; set; }

        public bool Enable { get; set; } = true;

        public string? QueryString { get; set; }

        //public TimeSpan Period { get; set; }
        public TimeSpan Period { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The table name has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The table name has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string Table { get; set; }

        public string Columns { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The Created By field has to be maximum of 255 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string CreatedBy { get; set; }
    }
}
