
namespace AllProductsService
{
    [PrimaryKey(nameof(DataAreaId), nameof(GroupCode))]
    public abstract partial class PriceCustomerGroupsBase
    {
        // String properties are nullable by default
        public string DataAreaId { get; set; }

        public string GroupCode { get; set; }

        public string? GroupName { get; set; }

        public string? ModifiedBy1 { get; set; }

        // Nullable integer
        public int? PricingPriority { get; set; }

        // Nullable DateTime
        public DateTime? ModifiedDateTime1 { get; set; }

        // Nullable string for ETag (assuming it's not essential to always have a value)
        public string? Etag { get; set; }

        public string? ParentReference { get; set; }
    }

    public partial class PriceCustomerGroupsBase
    {
        public static PriceCustomerGroupsBase FromJson(string json) => JsonConvert.DeserializeObject<PriceCustomerGroupsBase>(json, Converter.Settings);
    }

    //public class AllProducts : PriceCustomerGroupsBase { }

    public class PriceCustomerGroupsTestR : PriceCustomerGroupsBase { }
}

