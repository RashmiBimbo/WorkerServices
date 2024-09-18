using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CommonCode.Models.Dtos.Responses
{
    public class GetServiceResponseDto
    {
        [JsonProperty("enable")]
        public bool Enable { get; set; } = true;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("queryString")]
        public string? QueryString { get; set; }

        [JsonProperty("period")]
        public TimeSpan Period { get; set; }

        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("columns")]
        public string Columns { get; set; }

        [JsonProperty("tableAltered")]
        public bool TableAltered { get; set; }
    }
}
