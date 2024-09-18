using System.ComponentModel.DataAnnotations;

namespace CommonCode.Models.Dtos.Requests
{
    public class DeleteServiceRequestDto
    {
        [Required]
        [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
        public string Endpoint { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

    }
}
