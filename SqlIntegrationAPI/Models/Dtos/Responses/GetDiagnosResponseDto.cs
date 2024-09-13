﻿namespace SqlIntegrationAPI.Models.Dtos.Responses
{
    public class GetDiagnosResponseDto
    {
        public long RecId { get; }

        public string Endpoint { get; set; }

        public string? Status { get; set; }

        public DateTime? LastRun { get; set; }

        public long? TotalRecordsTracked { get; set; }

        public long? TotalRecordsAdded { get; set; }

        public long? TotalRecordsUpdated { get; set; }

        public TimeSpan? TimeTaken { get; set; }

        public DateTime? NextRun { get; set; }

    }
}
