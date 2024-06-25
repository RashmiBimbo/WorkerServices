
namespace SqlIntegrationServices
{
    // For EF Core 7+ use [PrimaryKey] to define composite keys at the class level.
    [PrimaryKey(nameof(DataAreaId), nameof(GroupCode))]
    public abstract partial class LineDiscountCustomerGroupsBase
    {
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        // JSON Property: "dataAreaId"
        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; } // Nullable string

        // JSON Property: "GroupCode"
        [JsonProperty("GroupCode")]
        public string GroupCode { get; set; } // Nullable string

        // JSON Property: "GroupName"
        [JsonProperty("GroupName")]
        public string? GroupName { get; set; } // Nullable string

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime
    }

public partial class LineDiscountCustomerGroupsBase
{
    public static LineDiscountCustomerGroupsBase FromJson(string json) => JsonConvert.DeserializeObject<LineDiscountCustomerGroupsBase>(json, Converter.Settings);
}

//public class SubledgerVoucherGeneralJournalEntryEntities : LineDiscountCustomerGroupsBase { }

public class LineDiscountCustomerGroupsTestR : LineDiscountCustomerGroupsBase { }
}

