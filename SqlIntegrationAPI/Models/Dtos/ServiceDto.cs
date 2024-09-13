using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SqlIntegrationAPI.Models.Dtos
{
    public class ServiceResponseDto
    {
        public long RecId { get; }

        public bool Enable { get; set; } = true;

        public string Name { get; set; }

        public string Endpoint { get; set; }

        public string? QueryString { get; set; }

        public TimeSpan Period { get; set; }

        public string Table { get; set; }

        public bool Altered { get; set; }

        public string? Status { get; set; }

        public DateTime? LastRun { get; set; }

        public long? TotalRecordsTracked { get; set; }

        public long? TotalRecordsAdded { get; set; }

        public long? TotalRecordsUpdated { get; set; }

        public TimeSpan? TimeTaken { get; set; }

        public DateTime? NextRun { get; set; }

        public string Columns { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

    }
}
