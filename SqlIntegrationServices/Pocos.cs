
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlIntegrationServices
{
    public partial class DeserializeJson<T> where T : notnull
    {
        public static T Deserialize(string json) => JsonConvert.DeserializeObject<T>(json, settings: Converter.Settings);
    }

    #region AllProducts

    [PrimaryKey(nameof(ProductNumber))]
    public abstract partial class AllProductsBase
    {
        [Key]
        [JsonProperty("ProductNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductNumber { get; set; }

        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }
        public string? ParentReference { get; set; }

        [JsonProperty("ProductDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProductDescription { get; set; }

        [JsonProperty("ProductName", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProductName { get; set; }

        [JsonProperty("ProductSearchName", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProductSearchName { get; set; }

        [JsonProperty("ModifiedBy1", NullValueHandling = NullValueHandling.Ignore)]
        public string? ModifiedBy1 { get; set; }

        [JsonProperty("ModifiedDateTime1", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ModifiedDateTime1 { get; set; }
    }

    public class AllProducts : AllProductsBase { }

    public class AllProductsTest : AllProductsBase { }

    #endregion AllProducts

    #region BudgetModel

    [PrimaryKey(nameof(BudgetModel), nameof(DataAreaId))]
    public class BudgetModelsBase
    {
        [Key]
        [JsonProperty("BudgetModel")]
        public string BudgetModel { get; set; }

        [Key]
        [JsonProperty("DataAreaId")]
        public string DataAreaId { get; set; }

        [JsonProperty("@odata.etag", NullValueHandling = NullValueHandling.Ignore)]
        public string? Etag { get; set; }

        [JsonProperty("parentReference", NullValueHandling = NullValueHandling.Ignore)]
        public string? ParentReference { get; set; }

        [JsonProperty("cashFlowForecasts", NullValueHandling = NullValueHandling.Ignore)]
        public string? CashFlowForecasts { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("stopped", NullValueHandling = NullValueHandling.Ignore)]
        public string? Stopped { get; set; }
    }

    public class BudgetModels : BudgetModelsBase { }

    public class BudgetModelsTest : BudgetModelsBase { }

    #endregion BudgetModel

    #region BudgetRegisterEntryHeaders

    [PrimaryKey(nameof(dataAreaId), nameof(EntryNumber), nameof(LegalEntityId))]
    public class BudgetRegisterEntryHeadersBase
    {
        [Key]
        [JsonProperty("DataAreaId")]
        public string dataAreaId { get; set; }

        [Key]
        [JsonProperty("EntryNumber")]
        public string EntryNumber { get; set; }

        [Key]
        [JsonProperty("LegalEntityId")]
        public string LegalEntityId { get; set; }

        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }

        [JsonProperty("ReasonCode")]
        public string? ReasonCode { get; set; }

        [JsonProperty("BudgetCode")]
        public string? BudgetCode { get; set; }

        [JsonProperty("Status")]
        public string? Status { get; set; }

        [JsonProperty("WorkflowStatus")]
        public string? WorkflowStatus { get; set; }

        [JsonProperty("BudgetType")]
        public string? BudgetType { get; set; }

        [JsonProperty("RevenueBudgetTotal")]
        public decimal? RevenueBudgetTotal { get; set; }

        [JsonProperty("DefaultDate")]
        public DateTime? DefaultDate { get; set; }

        [JsonProperty("BudgetModelId")]
        public string? BudgetModelId { get; set; }

        // JSON Property: "SourceDocument"
        [JsonProperty("SourceDocument")]
        public string? SourceDocument { get; set; }

        // JSON Property: "ReasonComment"
        [JsonProperty("ReasonComment")]
        public string? ReasonComment { get; set; }

        // JSON Property: "ExpenseBudgetTotal"
        [JsonProperty("ExpenseBudgetTotal")]
        public decimal? ExpenseBudgetTotal { get; set; }

        // JSON Property: "OneTimeRevision"
        [JsonProperty("OneTimeRevision")]
        public string? OneTimeRevision { get; set; }

        // JSON Property: "ProductTypes"
        [JsonProperty("ProductTypes")]
        public string? ProductTypes { get; set; }

        // JSON Property: "BudgetClassifications"
        [JsonProperty("BudgetClassifications")]
        public string? BudgetClassifications { get; set; }

        // JSON Property: "Budgetmaincategory"
        [JsonProperty("Budgetmaincategory")]
        public string? Budgetmaincategory { get; set; }

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; }

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; }
    }

    public class BudgetRegisterEntryHeaders : BudgetRegisterEntryHeadersBase { }

    public class BudgetRegisterEntryHeadersTest : BudgetRegisterEntryHeadersBase { }

    #endregion BudgetRegisterEntryHeaders

    #region BudgetRegisterEntryLines

    [PrimaryKey(nameof(dataAreaId), nameof(LineNumber), nameof(LegalEntityId), nameof(EntryNumber))]
    public abstract partial class BudgetRegisterEntryLinesBase
    {
        [Key]
        [JsonProperty("DataAreaId")]
        public string dataAreaId { get; set; }

        [Key]
        [JsonProperty("LegalEntityId")]
        public string LegalEntityId { get; set; }

        [Key]
        [JsonProperty("EntryNumber")]
        public string EntryNumber { get; set; }

        [Key]
        [JsonProperty("LineNumber")]
        public decimal? LineNumber { get; set; }

        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }

        // JSON Property: "WorkflowStatus"
        [JsonProperty("WorkflowStatus")]
        public string? WorkflowStatus { get; set; }

        // JSON Property: "BudgetCheckResult"
        [JsonProperty("BudgetCheckResult")]
        public string? BudgetCheckResult { get; set; }

        // JSON Property: "AccountingCurrencyAmount"
        [JsonProperty("AccountingCurrencyAmount")]
        public decimal? AccountingCurrencyAmount { get; set; }

        // JSON Property: "DimensionAccountStructure"
        [JsonProperty("DimensionAccountStructure")]
        public string? DimensionAccountStructure { get; set; }

        // JSON Property: "CurrencyCode"
        [JsonProperty("CurrencyCode")]
        public string? CurrencyCode { get; set; }

        // JSON Property: "Price"
        [JsonProperty("Price")]
        public decimal? Price { get; set; }

        // JSON Property: "TransactionCurrencyAmount"
        [JsonProperty("TransactionCurrencyAmount")]
        public decimal? TransactionCurrencyAmount { get; set; }

        // JSON Property: "DimensionDisplayValue"
        [JsonProperty("DimensionDisplayValue")]
        public string? DimensionDisplayValue { get; set; }

        // JSON Property: "Comment"
        [JsonProperty("Comment")]
        public string? Comment { get; set; }

        // JSON Property: "EntryDate"
        [JsonProperty("EntryDate")]
        public DateTime? EntryDate { get; set; }

        // JSON Property: "Quantity"
        [JsonProperty("Quantity")]
        public decimal? Quantity { get; set; }

        // JSON Property: "IncludeInCashFlowForecast"
        [JsonProperty("IncludeInCashFlowForecast")]
        public string? IncludeInCashFlowForecast { get; set; }

        // JSON Property: "AmountType"
        [JsonProperty("AmountType")]
        public string? AmountType { get; set; }

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; }

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; }
    }

    public class BudgetRegisterEntryLines : BudgetRegisterEntryLinesBase { }

    public class BudgetRegisterEntryLinesTest : BudgetRegisterEntryLinesBase { }

    #endregion

    #region CustomerItems

    [PrimaryKey(nameof(CustVendRelation), nameof(DataAreaId), nameof(FromDate), nameof(ItemId), nameof(ToDate))]
    public abstract partial class CustomerItemsBase
    {
        [JsonProperty("ParentReference")]
        public string? ParentReference { get; set; } // Non-nullable, assuming it's part of the composite key

        [Key]
        [JsonProperty("DataAreaId")]
        public string? DataAreaId { get; set; } // Non-nullable, assuming it's part of the composite key

        [Key]
        [JsonProperty("FromDate")]
        public DateTimeOffset FromDate { get; set; } // Non-nullable, usually required

        [Key]
        [JsonProperty("ItemId")]
        public string? ItemId { get; set; } // Non-nullable, assuming it's part of the composite key

        [Key]
        [JsonProperty("CustVendRelation")]
        public string? CustVendRelation { get; set; } // Non-nullable, assuming it's part of the composite key

        [Key]
        [JsonProperty("ToDate")]
        public DateTimeOffset ToDate { get; set; } // Nullable DateTime

        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

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
        public DateTimeOffset? ModifiedDateTime1 { get; set; } // Nullable DateTime
    }

    public class CustomerItems : CustomerItemsBase { }

    public class CustomerItemsTest : CustomerItemsBase { }

    #endregion CustomerItems

    #region HGMRPDiscountCalculations

    public abstract class HGMRPDiscountCalculationsBase
    {
        [JsonProperty("DataAreaId")]
        public string DataAreaId { get; set; }

        public DateTime? FromDate { get; set; }

        public string ItemId { get; set; }

        public string? DiscountGroup { get; set; }
        public string? JournalName { get; set; }
        public decimal? Percent1 { get; set; }
        public decimal? Percent2 { get; set; }
        public DateTime? ToDate { get; set; }

        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }
        public string? ParentReference { get; set; }
        public string? SiconeMRPReport { get; set; }
        public string? Type { get; set; }
        public string? ModifiedBy1 { get; set; }
        public DateTime? ModifiedDateTime1 { get; set; }
    }

    public class HGMRPDiscountCalculations : HGMRPDiscountCalculationsBase { }

    public class HGMRPDiscountCalculationsTest : HGMRPDiscountCalculationsBase { }

    #endregion HGMRPDiscountCalculations

    #region HGMRPDiscountMasters

    public abstract class HGMRPDiscountMastersBase
    {
        public string DataAreaId { get; set; }

        public DateTime? FromDate { get; set; }

        public string ItemId { get; set; }

        public string? DiscountGroup { get; set; }

        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }
        public string? ParentReference { get; set; }
        public string? Active { get; set; }
        public string? CreatedBy1 { get; set; }
        public DateTime? CreatedDateTime1 { get; set; }
        public decimal? Percent1 { get; set; }
        public decimal? Percent2 { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ModifiedBy1 { get; set; }
        public DateTime? ModifiedDateTime1 { get; set; }
    }

    public class HGMRPDiscountMasters : HGMRPDiscountMastersBase { }

    public class HGMRPDiscountMastersTest : HGMRPDiscountMastersBase { }

    #endregion HGMRPDiscountMasters

    #region HGMRPMasters

    public abstract class HGMRPMastersBase
    {
        [JsonProperty("DataAreaId")]
        public string DataAreaId { get; set; }

        public DateTime? FromDate { get; set; }

        public string? GroupId { get; set; }

        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }
        public string? ParentReference { get; set; }
        public string? Active { get; set; }
        public decimal? GSTPercentage { get; set; }
        public string? ItemId { get; set; }
        public decimal? MRP { get; set; }
        public decimal? MTIndirectPercentage { get; set; }
        public decimal? MTPercentage { get; set; }
        public decimal? PTDPercentage { get; set; }
        public decimal? PTRPercentage { get; set; }
        public decimal? SSPercentage { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? RejectionPercentage { get; set; }
        public decimal? ECOMDirectPercentage { get; set; }
        public decimal? ECOMInDirectPercentage { get; set; }
        public decimal? InstitutionPercentage { get; set; }
        public string? ModifiedBy1 { get; set; }
        public DateTime? ModifiedDateTime1 { get; set; }
    }

    public class HGMRPMasters : HGMRPMastersBase { }

    public class HGMRPMastersTest : HGMRPMastersBase { }

    #endregion HGMRPMasters

    #region HGMRPCalculations

    public abstract class HGMRPCalculationsBase
    {
        [JsonProperty("DataAreaId")]
        public string? DataAreaId { get; set; }

        [JsonProperty("@odata.etag", NullValueHandling = NullValueHandling.Ignore)]
        public string? Etag { get; set; }

        [JsonProperty("FromDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FromDate { get; set; }

        [JsonProperty("GroupId", NullValueHandling = NullValueHandling.Ignore)]
        public string? GroupId { get; set; }

        [JsonProperty("GSTAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? GSTAmount { get; set; }

        [JsonProperty("GSTPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? GSTPercentage { get; set; }
        public string? ItemId { get; set; }

        [JsonProperty("JournalName", NullValueHandling = NullValueHandling.Ignore)]
        public string? JournalName { get; set; }

        [JsonProperty("MRPCode", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MRPCode { get; set; }

        [JsonProperty("MTAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MTAmount { get; set; }

        [JsonProperty("MTIndirectAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MTIndirectAmount { get; set; }

        [JsonProperty("MTIndirectPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MTIndirectPercentage { get; set; }
        [JsonProperty("MTPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MTPercentage { get; set; }

        [JsonProperty("NetAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? NetAmount { get; set; }

        [JsonProperty("PTDAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PTDAmount { get; set; }

        [JsonProperty("PTDPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PTDPercentage { get; set; }

        [JsonProperty("PTRAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PTRAmount { get; set; }

        [JsonProperty("PTRPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PTRPercentage { get; set; }

        [JsonProperty("SSAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SSAmount { get; set; }

        [JsonProperty("SSPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SSPercentage { get; set; }

        [JsonProperty("ToDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ToDate { get; set; }
        [JsonProperty("RejectionAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? RejectionAmount { get; set; }

        [JsonProperty("RejectionPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? RejectionPercentage { get; set; }

        [JsonProperty("ECOMDirectAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ECOMDirectAmount { get; set; }

        [JsonProperty("ECOMDirectPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ECOMDirectPercentage { get; set; }

        [JsonProperty("ECOMInDirectAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ECOMInDirectAmount { get; set; }

        [JsonProperty("ECOMInDirectPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ECOMInDirectPercentage { get; set; }

        [JsonProperty("InstitutionAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? InstitutionAmount { get; set; }

        [JsonProperty("InstitutionPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? InstitutionPercentage { get; set; }

        [JsonProperty("ModifiedBy1", NullValueHandling = NullValueHandling.Ignore)]
        public string? ModifiedBy1 { get; set; }

        [JsonProperty("ModifiedDateTime1", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ModifiedDateTime1 { get; set; }
    }

    public class HGMRPCalculations : HGMRPCalculationsBase { }

    public class HGMRPCalculationsTest : HGMRPCalculationsBase { }

    #endregion HGMRPCalculations

    #region HSNCodes

    [PrimaryKey(nameof(DataAreaId), nameof(Chapter), nameof(Heading), nameof(Subheading), nameof(CountryExtension), nameof(StatisticalSuffix))]
    public abstract partial class HSNCodesBase
    {
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        [Key]
        [JsonProperty("DataAreaId")]
        public string? DataAreaId { get; set; } // Nullable string

        [Key]
        [JsonProperty("Chapter")]
        public string? Chapter { get; set; } // Nullable string?

        [Key]
        [JsonProperty("Heading")]
        public string? Heading { get; set; } // Nullable string?

        [Key]
        [JsonProperty("Subheading")]
        public string? Subheading { get; set; } // Nullable string?

        [Key]
        [JsonProperty("CountryExtension")]
        public string? CountryExtension { get; set; } // Nullable string?

        [Key]
        [JsonProperty("StatisticalSuffix")]
        public string? StatisticalSuffix { get; set; } // Nullable string?

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

    public class HSNCodesTest : HSNCodesBase { }

    public class HSNCodes : HSNCodesBase { }

    #endregion HSNCodes

    #region LineDiscountCustomerGroups

    [PrimaryKey(nameof(dataAreaId), nameof(GroupCode))]
    public abstract partial class LineDiscountCustomerGroupsBase
    {
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        [Key]
        [JsonProperty("DataAreaId")]
        public string dataAreaId { get; set; } // Nullable string

        [Key]
        [JsonProperty("GroupCode")]
        public string GroupCode { get; set; } // Nullable string

        [JsonProperty("GroupName")]
        public string? GroupName { get; set; } // Nullable string

        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime
    }

    public class LineDiscountCustomerGroups : LineDiscountCustomerGroupsBase { }

    public class LineDiscountCustomerGroupsTest : LineDiscountCustomerGroupsBase { }

    #endregion LineDiscountCustomerGroups

    #region PriceCustomerGroups

    [PrimaryKey(nameof(dataAreaId), nameof(GroupCode))]
    public abstract partial class PriceCustomerGroupsBase
    {
        // String properties are nullable by default
        [Key]
        [JsonProperty("DataAreaId", NullValueHandling = NullValueHandling.Ignore)]
        public string dataAreaId { get; set; }

        [Key]
        [JsonProperty("GroupCode", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupCode { get; set; }

        [JsonProperty("GroupName", NullValueHandling = NullValueHandling.Ignore)]

        public string? GroupName { get; set; }

        [JsonProperty("ModifiedBy1", NullValueHandling = NullValueHandling.Ignore)]
        public string? ModifiedBy1 { get; set; }

        [JsonProperty("ModifiedDateTime1", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ModifiedDateTime1 { get; set; }

        // Nullable integer
        [JsonProperty("PricingPriority", NullValueHandling = NullValueHandling.Ignore)]

        public int? PricingPriority { get; set; }

        // Nullable string for ETag (assuming it's not essential to always have a value)
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }

        public string? ParentReference { get; set; }
    }

    public class PriceCustomerGroups : PriceCustomerGroupsBase { }

    public class PriceCustomerGroupsTest : PriceCustomerGroupsBase { }

    #endregion PriceCustomerGroups

    #region ProductTranslations

    [PrimaryKey(nameof(ProductNumber), nameof(LanguageId))]
    public abstract partial class ProductTranslationsBase
    {
        [Key]
        [JsonProperty("ProductNumber")]
        public string ProductNumber { get; set; } // Non-nullable, assuming it's essential

        [Key]
        [JsonProperty("LanguageId")]
        public string LanguageId { get; set; } // Non-nullable, assuming it's essential

        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        [JsonProperty("ParentReference")]
        public string? ParentReference { get; set; } // Nullable string

        [JsonProperty("Description")]
        public string? Description { get; set; } // Nullable string

        [JsonProperty("ProductName")]
        public string? ProductName { get; set; }

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime
    }

    public class ProductTranslations : ProductTranslationsBase { }

    public class ProductTranslationsTest : ProductTranslationsBase { }

    #endregion ProductTranslations

    #region SalesInvoiceHeaders

    [PrimaryKey(nameof(DataAreaId), nameof(InvoiceDate), nameof(InvoiceNumber), nameof(LedgerVoucher))]
    public abstract class CustInvoiceJourBase
    {
        [Key]
        [JsonProperty("InvoiceNumber")]
        public string InvoiceNumber { get; set; }

        [Key]
        [Column(TypeName = "datetime")]
        [JsonProperty("InvoiceDate")]
        public DateTime InvoiceDate { get; set; }

        [Key]
        [JsonProperty("DataAreaId")]
        public string DataAreaId { get; set; }

        [Key]
        [JsonProperty("LedgerVoucher", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string LedgerVoucher { get; set; }

        [JsonProperty("AmountMST", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? AmountMST { get; set; }

        [JsonProperty("ContactPersonId", NullValueHandling = NullValueHandling.Ignore)]
        public string? ContactPersonId { get; set; }

        [JsonProperty("CustomersOrderReference", NullValueHandling = NullValueHandling.Ignore)]
        public string? CustomersOrderReference { get; set; }

        [JsonProperty("CurrencyCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? CurrencyCode { get; set; }

        [JsonProperty("DeliveryAddressName", NullValueHandling = NullValueHandling.Ignore)]
        public string? DeliveryAddressName { get; set; }

        [JsonProperty("DeliveryModeCode", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(ParseStringConverter<long>))]
        public string? DeliveryModeCode { get; set; }

        [JsonProperty("DeliveryTermsCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? DeliveryTermsCode { get; set; }

        [JsonProperty("DriverCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? DriverCode { get; set; }

        [JsonProperty("DriverName", NullValueHandling = NullValueHandling.Ignore)]
        public string? DriverName { get; set; }

        [JsonProperty("Etag", NullValueHandling = NullValueHandling.Ignore)]
        public string? Etag { get; set; }

        [JsonProperty("InvoiceAddressCity", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressCity { get; set; }

        [JsonProperty("InvoiceAddressCountryRegionId", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressCountryRegionId { get; set; }

        [JsonProperty("InvoiceAddressCountryRegionISOCode")]
        public string InvoiceAddressCountryRegionISOCode { get; set; }

        [JsonProperty("InvoiceAddressState", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressState { get; set; }

        [JsonProperty("InvoiceAddressStreet", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressStreet { get; set; }

        [JsonProperty("InvoiceAddressStreetNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressStreetNumber { get; set; }

        [JsonProperty("InvoiceAddressZipCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceAddressZipCode { get; set; }

        [JsonProperty("InvoiceCustomerAccountNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceCustomerAccountNumber { get; set; }

        [JsonProperty("InvoiceHeaderTaxAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? InvoiceHeaderTaxAmount { get; set; }

        [JsonProperty("InvoiceId_CT", NullValueHandling = NullValueHandling.Ignore)]
        public string? InvoiceId_CT { get; set; }

        [JsonProperty("IsProcess_CT", NullValueHandling = NullValueHandling.Ignore)]
        public string? IsProcess_CT { get; set; }

        [JsonProperty("IsProcessed", NullValueHandling = NullValueHandling.Ignore)]
        public string? IsProcessed { get; set; }

        [JsonProperty("IsReturn", NullValueHandling = NullValueHandling.Ignore)]
        public string? IsReturn { get; set; }

        [JsonProperty("IRNNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? IRNNumber { get; set; }

        [JsonProperty("LoaderCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? LoaderCode { get; set; }

        [JsonProperty("LoaderName", NullValueHandling = NullValueHandling.Ignore)]
        public string? LoaderName { get; set; }

        [JsonProperty("ModifiedDateTime1", NullValueHandling = NullValueHandling.Ignore)]
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDateTime1 { get; set; }

        [JsonProperty("OrderAccount", NullValueHandling = NullValueHandling.Ignore)]
        public string? OrderAccount { get; set; }

        [JsonProperty("OrderId", NullValueHandling = NullValueHandling.Ignore)]
        public string? OrderId { get; set; }

        [JsonProperty("PackerCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? PackerCode { get; set; }

        [JsonProperty("PackerName", NullValueHandling = NullValueHandling.Ignore)]
        public string? PackerName { get; set; }

        [JsonProperty("ParentReference", NullValueHandling = NullValueHandling.Ignore)]
        public string? ParentReference { get; set; }

        [JsonProperty("PORefID", NullValueHandling = NullValueHandling.Ignore)]
        public string? PORefID { get; set; }

        [JsonProperty("RecId1", NullValueHandling = NullValueHandling.Ignore)]
        public long? RecId1 { get; set; }

        [JsonProperty("ReturnReasonCodeId", NullValueHandling = NullValueHandling.Ignore)]
        public string? ReturnReasonCodeId { get; set; }

        [JsonProperty("RouteCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? RouteCode { get; set; }

        [JsonProperty("SalesId", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesId { get; set; }

        [JsonProperty("SalesId_CT", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesId_CT { get; set; }

        [JsonProperty("SalesOrderNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesOrderNumber { get; set; }

        [JsonProperty("SalesOrderOriginCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesOrderOriginCode { get; set; }

        [JsonProperty("SalesOrderResponsiblePersonnelNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesOrderResponsiblePersonnelNumber { get; set; }

        [JsonProperty("SalesStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesStatus { get; set; }

        [JsonProperty("SalesType", NullValueHandling = NullValueHandling.Ignore)]
        public string? SalesType { get; set; }

        [JsonProperty("SupervisorCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? SupervisorCode { get; set; }

        [JsonProperty("SupervisorCodeBak", NullValueHandling = NullValueHandling.Ignore)]
        public string? SupervisorCodeBak { get; set; }

        [JsonProperty("TotalChargeAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalChargeAmount { get; set; }

        [JsonProperty("TotalDiscountAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalDiscountAmount { get; set; }

        [JsonProperty("TotalDiscountCustomerGroupCode", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalDiscountCustomerGroupCode { get; set; }

        [JsonProperty("TotalInvoiceAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalInvoiceAmount { get; set; }

        [JsonProperty("TotalTaxAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalTaxAmount { get; set; }

        [JsonProperty("VehicleCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? VehicleCode { get; set; }

        [JsonProperty("VehicleTag", NullValueHandling = NullValueHandling.Ignore)]
        public string? VehicleTag { get; set; }
    }

    public class CustInvoiceJour : CustInvoiceJourBase { }

    public class CustInvoiceJourTest : CustInvoiceJourBase { }

    #endregion SalesInvoiceHeaders

    //#region SalesOrderHeaders

    //[PrimaryKey(nameof(DataAreaId), nameof(SalesOrderNumber))]
    //public abstract class SalesOrderHeadersBase
    //{
    //    [JsonProperty("@odata.etag")]
    //    public string? Etag { get; set; }

    //    [Key]
    //    [JsonProperty("DataAreaId")]
    //    public string? DataAreaId { get; set; }

    //    [Key]
    //    [JsonProperty("SalesOrderNumber")]
    //    public string? SalesOrderNumber { get; set; }

    //    [JsonProperty("CustomerRequisitionNumber")]
    //    public string? CustomerRequisitionNumber { get; set; }

    //    [JsonProperty("SalesOrderProcessingStatus")]
    //    public string? SalesOrderProcessingStatus { get; set; }

    //    [JsonProperty("OrderTotalAmount")]
    //    public long? OrderTotalAmount { get; set; }

    //    [JsonProperty("IntrastatPortId")]
    //    public string? IntrastatPortId { get; set; }

    //    [JsonProperty("ContactPersonId")]
    //    public string? ContactPersonId { get; set; }

    //    [JsonProperty("CustomersOrderReference")]
    //    public string? CustomersOrderReference { get; set; }

    //    [JsonProperty("SkipCreateAutoCharges")]
    //    public string? SkipCreateAutoCharges { get; set; }

    //    [JsonProperty("TotalDiscountPercentage")]
    //    public long? TotalDiscountPercentage { get; set; }

    //    [JsonProperty("CustomerPaymentFineCode")]
    //    public string? CustomerPaymentFineCode { get; set; }

    //    [JsonProperty("IsSalesProcessingStopped")]
    //    public string? IsSalesProcessingStopped { get; set; }

    //    [JsonProperty("InventoryReservationMethod")]
    //    public string? InventoryReservationMethod { get; set; }

    //    [JsonProperty("IntrastatTransportModeCode")]
    //    public string? IntrastatTransportModeCode { get; set; }

    //    [JsonProperty("InvoiceCustomerAccountNumber")]
    //    public string? InvoiceCustomerAccountNumber { get; set; }

    //    [JsonProperty("URL")]
    //    public string? URL { get; set; }

    //    [JsonProperty("InvoiceAddressCity")]
    //    public string? InvoiceAddressCity { get; set; }

    //    [JsonProperty("BankSpecificSymbol")]
    //    public string? BankSpecificSymbol { get; set; }

    //    [JsonProperty("BaseDocumentNumber")]
    //    public string? BaseDocumentNumber { get; set; }

    //    [JsonProperty("IsFinalUser")]
    //    public string? IsFinalUser { get; set; }

    //    [JsonProperty("CFPSCode")]
    //    public string? CFPSCode { get; set; }

    //    [JsonProperty("InvoiceAddressStreet")]
    //    public string? InvoiceAddressStreet { get; set; }

    //    [JsonProperty("InvoiceAddressCountyId")]
    //    public string? InvoiceAddressCountyId { get; set; }

    //    [JsonProperty("DeliveryAddressCountryRegionId")]
    //    public string? DeliveryAddressCountryRegionId { get; set; }

    //    [JsonProperty("IsServiceDeliveryAddressBased")]
    //    public string? IsServiceDeliveryAddressBased { get; set; }

    //    [JsonProperty("InvoiceAddressDistrictName")]
    //    public string? InvoiceAddressDistrictName { get; set; }

    //    [JsonProperty("InvoiceAddressTimeZone")]
    //    public DateTimeOffset? InvoiceAddressTimeZone { get; set; }

    //    [JsonProperty("FiscalOperationPresenceType")]
    //    public string? FiscalOperationPresenceType { get; set; }

    //    [JsonProperty("MultilineDiscountCustomerGroupCode")]
    //    public string? MultilineDiscountCustomerGroupCode { get; set; }

    //    [JsonProperty("IsOwnEntryCertificateIssued")]
    //    public string? IsOwnEntryCertificateIssued { get; set; }

    //    [JsonProperty("DeliveryAddressCountyId")]
    //    public string? DeliveryAddressCountyId { get; set; }

    //    [JsonProperty("DefaultShippingWarehouseId")]
    //    public string? DefaultShippingWarehouseId { get; set; }

    //    [JsonProperty("DeliveryAddressLocationId")]
    //    public string? DeliveryAddressLocationId { get; set; }

    //    [JsonProperty("CustomerPaymentMethodName")]
    //    public string? CustomerPaymentMethodName { get; set; }

    //    [JsonProperty("SalesUnitId")]
    //    public string? SalesUnitId { get; set; }

    //    [JsonProperty("DefaultLedgerDimensionDisplayValue")]
    //    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    //    [JsonProperty("DeliveryAddressCountryRegionISOCode")]
    //    public string? DeliveryAddressCountryRegionISOCode { get; set; }

    //    [JsonProperty("AreTotalsCalculated")]
    //    public string? AreTotalsCalculated { get; set; }

    //    [JsonProperty("TaxExemptNumber")]
    //    public string? TaxExemptNumber { get; set; }

    //    [JsonProperty("DeliveryAddressDescription")]
    //    public string? DeliveryAddressDescription { get; set; }

    //    [JsonProperty("DeliveryAddressLongitude")]
    //    public long? DeliveryAddressLongitude { get; set; }

    //    [JsonProperty("DefaultShippingSiteId")]
    //    public string? DefaultShippingSiteId { get; set; }

    //    [JsonProperty("CashDiscountCode")]
    //    public string? CashDiscountCode { get; set; }

    //    [JsonProperty("DeliveryReasonCode")]
    //    public string? DeliveryReasonCode { get; set; }

    //    [JsonProperty("TotalDiscountCustomerGroupCode")]
    //    public string? TotalDiscountCustomerGroupCode { get; set; }

    //    [JsonProperty("CampaignId")]
    //    public string? CampaignId { get; set; }

    //    [JsonProperty("OrderTotalDiscountAmount")]
    //    public long? OrderTotalDiscountAmount { get; set; }

    //    [JsonProperty("PaymentTermsName")]
    //    public string? PaymentTermsName { get; set; }

    //    [JsonProperty("ShippingCarrierServiceGroupId")]
    //    public string? ShippingCarrierServiceGroupId { get; set; }

    //    [JsonProperty("CIPEcode")]
    //    public string? CIPEcode { get; set; }

    //    [JsonProperty("RequestedReceiptDate")]
    //    public DateTimeOffset? RequestedReceiptDate { get; set; }

    //    [JsonProperty("ConfirmedReceiptDate")]
    //    public DateTimeOffset? ConfirmedReceiptDate { get; set; }

    //    [JsonProperty("BaseDocumentDate")]
    //    public DateTimeOffset? BaseDocumentDate { get; set; }

    //    [JsonProperty("EInvoiceDimensionAccountCode")]
    //    public string? EInvoiceDimensionAccountCode { get; set; }

    //    [JsonProperty("OrderingCustomerAccountNumber")]
    //    public string? OrderingCustomerAccountNumber { get; set; }

    //    [JsonProperty("OrderTotalChargesAmount")]
    //    public long? OrderTotalChargesAmount { get; set; }

    //    [JsonProperty("SalesRebateCustomerGroupId")]
    //    public string? SalesRebateCustomerGroupId { get; set; }

    //    [JsonProperty("TransportationBrokerId")]
    //    public string? TransportationBrokerId { get; set; }

    //    [JsonProperty("DirectDebitMandateId")]
    //    public string? DirectDebitMandateId { get; set; }

    //    [JsonProperty("CreditNoteReasonCode")]
    //    public string? CreditNoteReasonCode { get; set; }

    //    [JsonProperty("IntrastatStatisticsProcedureCode")]
    //    public string? IntrastatStatisticsProcedureCode { get; set; }

    //    [JsonProperty("TMACustomerGroupId")]
    //    public string? TMACustomerGroupId { get; set; }

    //    [JsonProperty("ArePricesIncludingSalesTax")]
    //    public string? ArePricesIncludingSalesTax { get; set; }

    //    [JsonProperty("IsExportSale")]
    //    public string? IsExportSale { get; set; }

    //    [JsonProperty("InvoicePaymentAttachmentType")]
    //    public string? InvoicePaymentAttachmentType { get; set; }

    //    [JsonProperty("ReportingCurrencyFixedExchangeRate")]
    //    public long? ReportingCurrencyFixedExchangeRate { get; set; }

    //    [JsonProperty("IsDeliveryAddressPrivate")]
    //    public string? IsDeliveryAddressPrivate { get; set; }

    //    [JsonProperty("DeliveryAddressCity")]
    //    public string? DeliveryAddressCity { get; set; }

    //    [JsonProperty("DeliveryAddressStreet")]
    //    public string? DeliveryAddressStreet { get; set; }

    //    [JsonProperty("NumberSequenceGroupId")]
    //    public string? NumberSequenceGroupId { get; set; }

    //    [JsonProperty("OrderTotalTaxAmount")]
    //    public long? OrderTotalTaxAmount { get; set; }

    //    [JsonProperty("DeliveryTermsCode")]
    //    public string? DeliveryTermsCode { get; set; }

    //    [JsonProperty("ChargeCustomerGroupId")]
    //    public string? ChargeCustomerGroupId { get; set; }

    //    [JsonProperty("WillAutomaticInventoryReservationConsiderBatchAttributes")]
    //    public string? WillAutomaticInventoryReservationConsiderBatchAttributes { get; set; }

    //    [JsonProperty("SalesTaxGroupCode")]
    //    public string? SalesTaxGroupCode { get; set; }

    //    [JsonProperty("IsInvoiceAddressPrivate")]
    //    public string? IsInvoiceAddressPrivate { get; set; }

    //    [JsonProperty("ThirdPartySalesDigitalPlatformCNPJ")]
    //    public string? ThirdPartySalesDigitalPlatformCNPJ { get; set; }

    //    [JsonProperty("OrderHeaderTaxAmount")]
    //    public long? OrderHeaderTaxAmount { get; set; }

    //    [JsonProperty("FiscalDocumentOperationTypeId")]
    //    public string? FiscalDocumentOperationTypeId { get; set; }

    //    [JsonProperty("OrderCreationDateTime")]
    //    public DateTimeOffset? OrderCreationDateTime { get; set; }

    //    [JsonProperty("SalesOrderOriginCode")]
    //    public string? SalesOrderOriginCode { get; set; }

    //    [JsonProperty("ServiceFiscalInformationCode")]
    //    public string? ServiceFiscalInformationCode { get; set; }

    //    [JsonProperty("DeliveryAddressStateId")]
    //    public string? DeliveryAddressStateId { get; set; }

    //    [JsonProperty("FulfillmentPolicyName")]
    //    public string? FulfillmentPolicyName { get; set; }

    //    [JsonProperty("CommissionSalesRepresentativeGroupId")]
    //    public string? CommissionSalesRepresentativeGroupId { get; set; }

    //    [JsonProperty("CustomerPostingProfileId")]
    //    public string? CustomerPostingProfileId { get; set; }

    //    [JsonProperty("CustomerTransactionSettlementType")]
    //    public string? CustomerTransactionSettlementType { get; set; }

    //    [JsonProperty("BaseDocumentItemNumber")]
    //    public string? BaseDocumentItemNumber { get; set; }

    //    [JsonProperty("TransportationDocumentLineId")]
    //    public Guid TransportationDocumentLineId { get; set; }

    //    [JsonProperty("DeliveryAddressStreetInKana")]
    //    public string? DeliveryAddressStreetInKana { get; set; }

    //    [JsonProperty("CustomerPaymentFinancialInterestCode")]
    //    public string? CustomerPaymentFinancialInterestCode { get; set; }

    //    [JsonProperty("PaymentScheduleName")]
    //    public string? PaymentScheduleName { get; set; }

    //    [JsonProperty("InvoiceAddressStreetNumber")]
    //    public string? InvoiceAddressStreetNumber { get; set; }

    //    [JsonProperty("SalesOrderStatus")]
    //    public string? SalesOrderStatus { get; set; }

    //    [JsonProperty("PaymentTermsBaseDate")]
    //    public DateTimeOffset? PaymentTermsBaseDate { get; set; }

    //    [JsonProperty("ShippingCarrierId")]
    //    public string? ShippingCarrierId { get; set; }

    //    [JsonProperty("InvoiceAddressPostBox")]
    //    public string? InvoiceAddressPostBox { get; set; }

    //    [JsonProperty("ConfirmedShippingDate")]
    //    public DateTimeOffset? ConfirmedShippingDate { get; set; }

    //    [JsonProperty("TenderCode")]
    //    public string? TenderCode { get; set; }

    //    [JsonProperty("DeliveryAddressDunsNumber")]
    //    public string? DeliveryAddressDunsNumber { get; set; }

    //    [JsonProperty("IsEntryCertificateRequired")]
    //    public string? IsEntryCertificateRequired { get; set; }

    //    [JsonProperty("ThirdPartySalesDigitalPlatform")]
    //    public string? ThirdPartySalesDigitalPlatform { get; set; }

    //    [JsonProperty("DeliveryAddressDistrictName")]
    //    public string? DeliveryAddressDistrictName { get; set; }

    //    [JsonProperty("SalesOrderPromisingMethod")]
    //    public string? SalesOrderPromisingMethod { get; set; }

    //    [JsonProperty("DeliveryModeCode")]
    //    //[JsonConverter(typeof(ParseStringConverter<long>))]
    //    public long? DeliveryModeCode { get; set; }

    //    [JsonProperty("BaseDocumentLineNumber")]
    //    public long? BaseDocumentLineNumber { get; set; }

    //    [JsonProperty("TransportationModeId")]
    //    public string? TransportationModeId { get; set; }

    //    [JsonProperty("SalesOrderName")]
    //    public string? SalesOrderName { get; set; }

    //    [JsonProperty("DeliveryAddressStreetNumber")]
    //    public string? DeliveryAddressStreetNumber { get; set; }

    //    [JsonProperty("InvoiceAddressLongitude")]
    //    public long? InvoiceAddressLongitude { get; set; }

    //    [JsonProperty("InvoiceAddressLatitude")]
    //    public long? InvoiceAddressLatitude { get; set; }

    //    [JsonProperty("BaseDocumentType")]
    //    public string? BaseDocumentType { get; set; }

    //    [JsonProperty("SalesOrderPoolId")]
    //    public string? SalesOrderPoolId { get; set; }

    //    [JsonProperty("FormattedInvoiceAddress")]
    //    public string? FormattedInvoiceAddress { get; set; }

    //    [JsonProperty("CustomerPaymentMethodSpecificationName")]
    //    public string? CustomerPaymentMethodSpecificationName { get; set; }

    //    [JsonProperty("CurrencyCode")]
    //    public string? CurrencyCode { get; set; }

    //    [JsonProperty("FormattedDelveryAddress")]
    //    public string? FormattedDelveryAddress { get; set; }

    //    [JsonProperty("BankConstantSymbol")]
    //    public string? BankConstantSymbol { get; set; }

    //    [JsonProperty("PriceCustomerGroupCode")]
    //    public string? PriceCustomerGroupCode { get; set; }

    //    [JsonProperty("DeliveryAddressTimeZone")]
    //    public DateTimeOffset? DeliveryAddressTimeZone { get; set; }

    //    [JsonProperty("FullRunCTPStatus")]
    //    public string? FullRunCTPStatus { get; set; }

    //    [JsonProperty("Email")]
    //    public string? Email { get; set; }

    //    [JsonProperty("InvoiceAddressCityInKana")]
    //    public string? InvoiceAddressCityInKana { get; set; }

    //    [JsonProperty("InvoiceAddressCountryRegionISOCode")]
    //    public string? InvoiceAddressCountryRegionISOCode { get; set; }

    //    [JsonProperty("TransportationTemplateId")]
    //    public string? TransportationTemplateId { get; set; }

    //    [JsonProperty("IsConsolidatedInvoiceTarget")]
    //    public string? IsConsolidatedInvoiceTarget { get; set; }

    //    [JsonProperty("OrderOrAgreementCode")]
    //    public string? OrderOrAgreementCode { get; set; }

    //    [JsonProperty("TransportationRoutePlanId")]
    //    public string? TransportationRoutePlanId { get; set; }

    //    [JsonProperty("FixedDueDate")]
    //    public DateTimeOffset? FixedDueDate { get; set; }

    //    [JsonProperty("DeliveryAddressName")]
    //    public string? DeliveryAddressName { get; set; }

    //    [JsonProperty("ExportReason")]
    //    public string? ExportReason { get; set; }

    //    [JsonProperty("FixedExchangeRate")]
    //    public long? FixedExchangeRate { get; set; }

    //    [JsonProperty("IntrastatTransactionCode")]
    //    public string? IntrastatTransactionCode { get; set; }

    //    [JsonProperty("InvoiceAddressStreetInKana")]
    //    public string? InvoiceAddressStreetInKana { get; set; }

    //    [JsonProperty("InvoiceBuildingCompliment")]
    //    public string? InvoiceBuildingCompliment { get; set; }

    //    [JsonProperty("InvoiceAddressZipCode")]
    //    public string? InvoiceAddressZipCode { get; set; }

    //    [JsonProperty("TotalDiscountAmount")]
    //    public long? TotalDiscountAmount { get; set; }

    //    [JsonProperty("ShippingCarrierServiceId")]
    //    public string? ShippingCarrierServiceId { get; set; }

    //    [JsonProperty("IsOneTimeCustomer")]
    //    public string? IsOneTimeCustomer { get; set; }

    //    [JsonProperty("DeliveryAddressZipCode")]
    //    //[JsonConverter(typeof(ParseStringConverter<long>))]
    //    public long? DeliveryAddressZipCode { get; set; }

    //    [JsonProperty("OrderTakerPersonnelNumber")]
    //    public string? OrderTakerPersonnelNumber { get; set; }

    //    [JsonProperty("DeliveryAddressCityInKana")]
    //    public string? DeliveryAddressCityInKana { get; set; }

    //    [JsonProperty("DeliveryAddressPostBox")]
    //    public string? DeliveryAddressPostBox { get; set; }

    //    [JsonProperty("IsDeliveryAddressOrderSpecific")]
    //    public string? IsDeliveryAddressOrderSpecific { get; set; }

    //    [JsonProperty("InvoiceAddressStateId")]
    //    public string? InvoiceAddressStateId { get; set; }

    //    [JsonProperty("RequestedShippingDate")]
    //    public DateTimeOffset? RequestedShippingDate { get; set; }

    //    [JsonProperty("DeliveryAddressLatitude")]
    //    public long? DeliveryAddressLatitude { get; set; }

    //    [JsonProperty("DeliveryBuildingCompliment")]
    //    public string? DeliveryBuildingCompliment { get; set; }

    //    [JsonProperty("InvoiceAddressCountryRegionId")]
    //    public string? InvoiceAddressCountryRegionId { get; set; }

    //    [JsonProperty("IsEInvoiceDimensionAccountCodeSpecifiedPerLine")]
    //    public string? IsEInvoiceDimensionAccountCodeSpecifiedPerLine { get; set; }

    //    [JsonProperty("InvoiceType")]
    //    public string? InvoiceType { get; set; }

    //    [JsonProperty("EUSalesListCode")]
    //    public string? EUSalesListCode { get; set; }

    //    [JsonProperty("ProjectId")]
    //    public string? ProjectId { get; set; }

    //    [JsonProperty("OverrideSalesTax")]
    //    public string? OverrideSalesTax { get; set; }

    //    [JsonProperty("QuotationNumber")]
    //    public string? QuotationNumber { get; set; }

    //    [JsonProperty("OrderResponsiblePersonnelNumber")]
    //    public string? OrderResponsiblePersonnelNumber { get; set; }

    //    [JsonProperty("CommissionCustomerGroupId")]
    //    public string? CommissionCustomerGroupId { get; set; }

    //    [JsonProperty("LanguageId")]
    //    public string? LanguageId { get; set; }

    //    [JsonProperty("LineDiscountCustomerGroupCode")]
    //    public string? LineDiscountCustomerGroupCode { get; set; }

    //    [JsonProperty("ShippingCarrierCustomerAccountNumber")]
    //    public string? ShippingCarrierCustomerAccountNumber { get; set; }

    //    [JsonProperty("SubBillCreatedFromSubscriptionBilling")]
    //    public string? SubBillCreatedFromSubscriptionBilling { get; set; }

    //    [JsonProperty("RevRecReallocationId")]
    //    public string? RevRecReallocationId { get; set; }

    //    [JsonProperty("RevRecFollowOriginalPricingMethod")]
    //    public string? RevRecFollowOriginalPricingMethod { get; set; }

    //    [JsonProperty("RevRecMultipleSOReallocation")]
    //    public string? RevRecMultipleSOReallocation { get; set; }

    //    [JsonProperty("RevRecContractEndDate")]
    //    public DateTimeOffset? RevRecContractEndDate { get; set; }

    //    [JsonProperty("RevRecLatestReverseJournal")]
    //    public long? RevRecLatestReverseJournal { get; set; }

    //    [JsonProperty("RevRecContractStartDate")]
    //    public DateTimeOffset? RevRecContractStartDate { get; set; }

    //    [JsonProperty("SkipGlobalUnifiedPricingCalculation")]
    //    public string? SkipGlobalUnifiedPricingCalculation { get; set; }

    //}

    //public class SalesOrderHeaders : SalesOrderHeadersBase { }

    //public class SalesOrderHeadersTest : SalesOrderHeadersBase { }

    //#endregion SalesOrder

    #region SubledgerVoucherGeneralJournalEntryEntities

    [PrimaryKey(nameof(Voucher), nameof(RecId1))]
    public abstract partial class SubledgerVoucherGeneralJournalEntryEntitiesBase
    {
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        // JSON Property: "@odata.etag"
        [JsonProperty("@ParentReference")]
        public string? ParentReference { get; set; } // Nullable string

        [Key]
        [JsonProperty("RecId1")]
        public long RecId1 { get; set; } // Non-nullable key property

        [Key]
        [JsonProperty("Voucher")]
        public string Voucher { get; set; } // Non-nullable key property

        // JSON Property: "AccountingDate"
        [JsonProperty("AccountingDate")]
        public DateTime? AccountingDate { get; set; } // Nullable DateTime

        // JSON Property: "GeneralJournalEntry"
        [JsonProperty("GeneralJournalEntry")]
        public long? GeneralJournalEntry { get; set; } // Nullable long

        // JSON Property: "Partition1"
        [JsonProperty("Partition1")]
        public long? Partition1 { get; set; } // Nullable long
        // JSON Property: "TransferId"
        [JsonProperty("TransferId")]
        public long? TransferId { get; set; } // Nullable long

        // JSON Property: "RecVersion1"
        [JsonProperty("RecVersion1")]
        public int? RecVersion1 { get; set; } // Nullable long

        // JSON Property: "SubledgerJournalEntry"
        [JsonProperty("SubledgerJournalEntry")]
        public long? SubledgerJournalEntry { get; set; } // Nullable long

        // JSON Property: "VoucherDataAreaId"
        [JsonProperty("VoucherDataAreaId")]
        public string? VoucherDataAreaId { get; set; } // Non-nullable key property

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime

    }

    public class SubledgerVoucherGeneralJournalEntryEntities : SubledgerVoucherGeneralJournalEntryEntitiesBase { }

    public class SubledgerVoucherGeneralJournalEntryEntitiesTest : SubledgerVoucherGeneralJournalEntryEntitiesBase { }

    #endregion SubledgerVoucherGeneralJournalEntryEntities

    #region TaxDocuments

    [PrimaryKey(nameof(CustVendTransTableId), nameof(dataAreaId), nameof(TaxDocumentNumber))]
    public abstract class TaxDocumentsBase
    {
        [Key]
        public int CustVendTransTableId { get; set; }

        [Key]
        [StringLength(255)]
        public string dataAreaId { get; set; }

        [Key]
        [StringLength(255)]
        public string TaxDocumentNumber { get; set; }

        [StringLength(2000)]
        [JsonProperty("@odata.etag")]
        public string Etag { get; set; }

        [StringLength(2000)]
        public string ParentReference { get; set; }

        public decimal? Amount { get; set; }

        public decimal? AmountInTransactionCurrency { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? TaxAmountInCurrency { get; set; }

        public DateTime? TaxCreditMemoDate { get; set; }

        [StringLength(2000)]
        public string TaxCreditMemoNumber { get; set; }

        public decimal? TaxCreditMemoTransactionAmount { get; set; }

        public decimal? TaxCreditMemoTransactionAmountInTransactionCurrency { get; set; }

        public decimal? TaxCreditMemoTransactionTaxAmount { get; set; }

        public decimal? TaxCreditMemoTransactionTaxAmountInCurrency { get; set; }

        public decimal? TaxCreditMemoTransactionTaxValue { get; set; }

        [StringLength(2000)]
        public string TaxCreditMemoTransactionTypeOfTax { get; set; }

        public DateTime? TaxDocumentDate { get; set; }

        public decimal? TaxDocumentTransactionAmount { get; set; }

        public decimal? TaxDocumentTransactionAmountInTransactionCurrency { get; set; }

        public decimal? TaxDocumentTransactionTaxAmount { get; set; }

        public decimal? TaxDocumentTransactionTaxAmountInCurrency { get; set; }

        public decimal? TaxDocumentTransactionTaxValue { get; set; }

        [StringLength(2000)]
        public string TaxDocumentTransactionTypeOfTax { get; set; }
    }

    public class TaxDocuments : TaxDocumentsBase { }

    public class TaxDocumentsTest : TaxDocumentsBase { }

    #endregion

    #region UnitsOfMeasure

    [PrimaryKey(nameof(UnitSymbol))]
    public abstract class UnitsOfMeasureBase
    {
        [Key]
        [JsonProperty("UnitSymbol")]
        public string UnitSymbol { get; set; }

        [JsonProperty("DecimalPrecision")]
        public int? DecimalPrecision { get; set; }

        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }

        [JsonProperty("FixedUnitSymbolAssignment")]
        public string? FixedUnitSymbolAssignment { get; set; }

        [JsonProperty("IsBaseUnit")]
        public string? IsBaseUnit { get; set; }

        [JsonProperty("IsFixedUnitSymbolAssigned")]
        public string? IsFixedUnitSymbolAssigned { get; set; }

        [JsonProperty("IsSystemUnit")]
        public string? IsSystemUnit { get; set; }

        [JsonProperty("NationalCode")]
        public string? NationalCode { get; set; }

        public string? ParentReference { get; set; }

        [JsonProperty("SystemOfUnits")]
        public string? SystemOfUnits { get; set; }

        [JsonProperty("UnitClass")]
        public string? UnitClass { get; set; }

        [JsonProperty("UnitDescription")]
        public string? UnitDescription { get; set; }
    }

    public class UnitsOfMeasure : UnitsOfMeasureBase { }
    public class UnitsOfMeasureTest : UnitsOfMeasureBase { }

    #endregion UnitsOfMeasure

    #region UnitOfMeasureConversions

    [PrimaryKey(nameof(FromUnitSymbol), nameof(ToUnitSymbol))]
    public abstract class UnitOfMeasureConversionsBase
    {
        // A property for the OData etag, typically used for versioning in OData services.
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }

        // Properties to hold the unit symbols and conversion factors.
        [Key]
        public string FromUnitSymbol { get; set; }

        [Key]
        public string ToUnitSymbol { get; set; }

        public decimal? InnerOffset { get; set; }
        public decimal? OuterOffset { get; set; }
        public string? Rounding { get; set; }
        public int? Numerator { get; set; }
        public decimal? Factor { get; set; }
        public int? Denominator { get; set; }
    }

    [Serializable]
    public class UnitOfMeasureConversions : UnitOfMeasureConversionsBase { }

    [Serializable]
    public class UnitOfMeasureConversionsTest : UnitOfMeasureConversionsBase { }

    #endregion UnitOfMeasureConversions

}

