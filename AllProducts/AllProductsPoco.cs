
namespace BudgetRegisterEntryLinesService
{
    [PrimaryKey(nameof(ProductNumber))]
    public abstract partial class AllProductsBase
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

        // JSON Property: "ProductDescription"
        [JsonProperty("ProductDescription")]
        public string? ProductDescription { get; set; } // Nullable string

        // JSON Property: "ProductName"
        [JsonProperty("ProductName")]
        public string? ProductName { get; set; } // Non-nullable, assuming it's essential

        // JSON Property: "ProductSearchName"
        [JsonProperty("ProductSearchName")]
        public string? ProductSearchName { get; set; } // Non-nullable, assuming it's essential

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime
    }

    public partial class AllProductsBase
    {
        public static AllProductsBase FromJson(string json) => JsonConvert.DeserializeObject<AllProductsBase>(json, Converter.Settings);
    }

    public class AllProducts : AllProductsBase { }

    public class AllProductsTestR : AllProductsBase { }
}

