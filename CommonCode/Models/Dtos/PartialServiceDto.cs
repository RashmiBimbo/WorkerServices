using CommonCode.CommonClasses;
using System.ComponentModel.DataAnnotations;

namespace CommonCode.Models.Dtos;
public class PartialServiceDto
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

    public string? QueryString { get; set; } = "cross-company=true";

    public TimeSpan Period { get; set; } = TimeSpan.FromMinutes(30);

    [Required]
    [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
    [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
    [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
    public string Table { get; set; }

    public bool TableAltered { get; set; } = false;

    public string? Status { get; set; }

    public DateTime? LastRun { get; set; }

    public long? TotalRecordsTracked { get; set; }

    public long? TotalRecordsAdded { get; set; }

    public long? TotalRecordsUpdated { get; set; }

    public TimeSpan? TimeTaken { get; set; }

    public DateTime? NextRun { get; set; }

    public string Columns { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required]
    [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
    [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
    [RegularExpression("^[a-zA-Z0-9\\s]*$")]
    public string CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; } = DateTime.Now;

    [StringLength(255, ErrorMessage = "The service name has to be maximum of 255 characters")]
    [MinLength(3, ErrorMessage = "The service name has to be minimum of 3 characters")]
    [RegularExpression("^[a-zA-Z0-9\\s]*$")]
    public string? ModifiedBy { get; set; }

}


//public class PartialServiceDto
//{
//    [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
//    [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
//    [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
//    public string? Endpoint { get; set; }

//    public bool? Enable { get; set; } = true;

//    [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
//    [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
//    [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
//    public string? Name { get; set; }

//    public string? QueryString { get; set; }

//    public TimeSpan? Period { get; set; }

//    [StringLength(255, ErrorMessage = "The endpoint has to be maximum of 255 characters")]
//    [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
//    [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
//    public string? Table { get; set; }

//    public string? Columns { get; set; }

//    public bool? TableAltered { get; set; }

//    public DateTime? ModifiedDate { get; set; }

//    [StringLength(255, ErrorMessage = "The endpoint has to be of 3-255 characters")]
//    [MinLength(3, ErrorMessage = "The endpoint has to be minimum of 3 characters")]
//    [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
//    public string? ModifiedBy { get; set; }

//    public DateTime CreatedDate { get; set; }

//    [Required]
//    [StringLength(255, ErrorMessage = "The Created By field has to be maximum of 255 characters")]
//    [RegularExpression("^[a-zA-Z0-9\\s-_]*$")]
//    public string CreatedBy { get; set; }
//}
//}
