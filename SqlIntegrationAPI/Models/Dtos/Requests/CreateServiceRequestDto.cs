namespace SqlIntegrationAPI.Models.Dtos.Requests
{
    public class CreateServiceRequestDto
    {
        public string Name { get; set; }

        public string Endpoint { get; set; }

        public bool Enable { get; set; } = true;

        public string? QueryString { get; set; }

        public TimeSpan Period { get; set; }

        public string Table { get; set; }

        public string Columns { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
