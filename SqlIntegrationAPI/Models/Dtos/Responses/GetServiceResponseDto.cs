using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SqlIntegrationAPI.Models.Dtos.Responses
{
    public class GetServiceResponseDto
    {
        public bool Enable { get; set; } = true;

        public string Name { get; set; }

        public string Endpoint { get; set; }

        public string? QueryString { get; set; }

        public TimeSpan Period { get; set; }

        public string Table { get; set; }

        public string Columns { get; set; }

        public bool TableAltered { get; set; }
    }
}
