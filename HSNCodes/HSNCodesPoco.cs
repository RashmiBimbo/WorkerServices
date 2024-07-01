
namespace SqlIntegrationServices
{
    // For EF Core 7+ use [PrimaryKey] to define composite keys at the class level.
    [PrimaryKey(nameof(Chapter), nameof(CountryExtension), nameof(DataAreaId), nameof(Heading), nameof(StatisticalSuffix), nameof(Subheading))]
    public abstract partial class HSNCodesBase
    {
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        // JSON Property: "dataAreaId"
        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; } // Nullable string

        // JSON Property: "Chapter"
        [JsonProperty("Chapter")]
        public string Chapter { get; set; } // Nullable string

        // JSON Property: "Heading"
        [JsonProperty("Heading")]
        public string Heading { get; set; } // Nullable string

        // JSON Property: "Subheading"
        [JsonProperty("Subheading")]
        public string Subheading { get; set; } // Nullable string

        // JSON Property: "CountryExtension"
        [JsonProperty("CountryExtension")]
        public string CountryExtension { get; set; } // Nullable string

        // JSON Property: "StatisticalSuffix"
        [JsonProperty("StatisticalSuffix")]
        public string StatisticalSuffix { get; set; } // Nullable string

        // JSON Property: "Code"
        [JsonProperty("Code")]
        public string? Code { get; set; } // Nullable string

        // JSON Property: "Description"
        [JsonProperty("Description")]
        public string? Description { get; set; } // Nullable string

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "RecIdCopy1"
        [JsonProperty("RecIdCopy1")]
        public long? RecIdCopy1 { get; set; } // Nullable long (for bigint)

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime
    }

    public partial class HSNCodesBase
    {
        public static HSNCodesBase FromJson(string json) => JsonConvert.DeserializeObject<HSNCodesBase>(json, Converter.Settings);
    }

    public class HSNCodesTestR : HSNCodesBase { }
}

