using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CommonCode.Models.Dtos.Responses
{
    public class GetDiagnosResponseDto
    {
        public string Name { get; set; }

        public string Endpoint { get; set; }

        public string? Status { get; set; }

        [DisplayName("Last Run")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull =false, DataFormatString = "dd-MMM-yy:dd:mm:ss")]
        public DateTime? LastRun { get; set; }

        [DisplayName("Total Records Tracked")]
        public long? TotalRecordsTracked { get; set; }

        [DisplayName("Total Records Added")]
        public long? TotalRecordsAdded { get; set; }

        [DisplayName("Total Records Updated")]
        public long? TotalRecordsUpdated { get; set; }

        [DisplayName("Time Taken")]
        public TimeSpan? TimeTaken { get; set; }

        [DisplayName("Next Run")]
        [DisplayFormat(DataFormatString ="dd-MMM-yy:dd:mm:ss")]
        public DateTime? NextRun { get; set; }

    }
}
