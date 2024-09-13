namespace SqlIntegrationAPI.Models.Dtos.Requests
{
    public class DeleteServiceRequestDto
    {
        public long RecId { get; }

        public string Endpoint { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

    }
}
