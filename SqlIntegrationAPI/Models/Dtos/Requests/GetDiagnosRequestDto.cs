using System.ComponentModel.DataAnnotations;

namespace SqlIntegrationAPI.Models.Dtos.Requests
{
    public class GetDiagnosRequestDto
    {
        [Required]
        [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
        [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        public string Endpoint { get; set; }

    }
}
