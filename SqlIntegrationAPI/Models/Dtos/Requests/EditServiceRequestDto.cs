namespace SqlIntegrationAPI.Models.Dtos.Requests
{
    public class EditServiceRequestDto
    {
        public long RecId { get; }

        public string Endpoint { get; set; }

        public bool Enable { get; set; } = true;

        public string Name { get; set; }

        public string? QueryString { get; set; }

        public TimeSpan Period { get; set; }

        public string Table { get; set; }

        public string Columns { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
