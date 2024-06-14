
namespace BudgetRegisterEntryLinesService
{
    // For EF Core 7+ use [PrimaryKey] to define composite keys at the class level.
    [PrimaryKey(nameof(CustVendRelation), nameof(DataAreaId), nameof(FromDate), nameof(ItemId), nameof(ToDate))]
    public abstract partial class CustomerItemsBase
    {
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        // JSON Property: "dataAreaId"
        [JsonProperty("ParentReference")]
        public string? ParentReference { get; set; } // Non-nullable, assuming it's part of the composite key
        
        // JSON Property: "dataAreaId"
        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; } // Non-nullable, assuming it's part of the composite key

        // JSON Property: "FromDate"
        [JsonProperty("FromDate")]
        public DateTime FromDate { get; set; } // Non-nullable, usually required

        // JSON Property: "ItemId"
        [JsonProperty("ItemId")]
        public string ItemId { get; set; } // Non-nullable, assuming it's part of the composite key

        // JSON Property: "CustVendRelation"
        [JsonProperty("CustVendRelation")]
        public string CustVendRelation { get; set; } // Non-nullable, assuming it's part of the composite key

        // JSON Property: "ToDate"
        [JsonProperty("ToDate")]
        public DateTime ToDate { get; set; } // Nullable DateTime

        // JSON Property: "IsActive"
        [JsonProperty("IsActive")]
        public string? IsActive { get; set; } // Nullable string

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "Description"
        [JsonProperty("Description")]
        public string? Description { get; set; } // Nullable string

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime
    }

    public partial class CustomerItemsBase
    {
        public static CustomerItemsBase FromJson(string json) => JsonConvert.DeserializeObject<CustomerItemsBase>(json, Converter.Settings);
    }

    public class CustomerItems : CustomerItemsBase { }

    public class CustomerItemsTestR : CustomerItemsBase { }
}

