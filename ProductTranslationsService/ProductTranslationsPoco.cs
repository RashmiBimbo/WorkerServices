
namespace ProductTranslationsService
{
    [PrimaryKey(nameof(ProductNumber), nameof(LanguageId))]
    public abstract partial class ProductTranslationsBase
    {
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        // JSON Property: "@odata.etag"
        [JsonProperty("ParentReference")]
        public string? ParentReference { get; set; } // Nullable string

        // JSON Property: "ProductNumber"
        [JsonProperty("ProductNumber")]
        public string ProductNumber { get; set; } // Non-nullable, assuming it's essential

        // JSON Property: "Description"
        [JsonProperty("Description")]
        public string? Description { get; set; } // Nullable string

        // JSON Property: "ProductName"
        [JsonProperty("ProductName")]
        public string? ProductName { get; set; } // Non-nullable, assuming it's essential

        // JSON Property: "ProductSearchName"
        [JsonProperty("LanguageId")]
        public string LanguageId { get; set; } // Non-nullable, assuming it's essential

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime
    }

    public partial class ProductTranslationsBase
    {
        public static ProductTranslationsBase FromJson(string json) => JsonConvert.DeserializeObject<ProductTranslationsBase>(json, Converter.Settings);
    }

    public class AllProducts : ProductTranslationsBase { }

    public class ProductTranslationsTestR : ProductTranslationsBase { }
}

