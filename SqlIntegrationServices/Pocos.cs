
using System.ComponentModel.DataAnnotations;

namespace SqlIntegrationServices
{
    public partial class DeserializeJson<T> where T : notnull
    {
        public static T Deserialize(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);

    }

    public abstract class BasePoco { }

    // For EF Core 7+ use [PrimaryKey] to define composite keys at the class level.
    [PrimaryKey(nameof(Voucher), nameof(RecId1))]
    public abstract partial class SubledgerVoucherGeneralJournalEntryEntitiesBase
    {
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        // JSON Property: "Voucher"
        [JsonProperty("Voucher")]
        public string Voucher { get; set; } // Non-nullable key property

        // JSON Property: "RecId1"
        [JsonProperty("RecId1")]
        public long RecId1 { get; set; } // Non-nullable key property

        // JSON Property: "GeneralJournalEntry"
        [JsonProperty("GeneralJournalEntry")]
        public long? GeneralJournalEntry { get; set; } // Nullable long

        // JSON Property: "ModifiedBy1"
        [JsonProperty("ModifiedBy1")]
        public string? ModifiedBy1 { get; set; } // Nullable string

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

        // JSON Property: "ModifiedDateTime1"
        [JsonProperty("ModifiedDateTime1")]
        public DateTime? ModifiedDateTime1 { get; set; } // Nullable DateTime

        // JSON Property: "AccountingDate"
        [JsonProperty("AccountingDate")]
        public DateTime? AccountingDate { get; set; } // Nullable DateTime

        // JSON Property: "Partition1"
        [JsonProperty("Partition1")]
        public long? Partition1 { get; set; } // Nullable long
    }

    public class SubledgerVoucherGeneralJournalEntryEntities : SubledgerVoucherGeneralJournalEntryEntitiesBase { }

    public class SubledgerVoucherGeneralJournalEntryEntitiesTestR : SubledgerVoucherGeneralJournalEntryEntitiesBase { }


    [PrimaryKey(nameof(FromUnitSymbol), nameof(ToUnitSymbol))]
    public abstract class UnitOfMeasureConversionsBase
    {
        // A property for the OData etag, typically used for versioning in OData services.
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }

        // Properties to hold the unit symbols and conversion factors.
        public string FromUnitSymbol { get; set; }
        public string ToUnitSymbol { get; set; }
        public int? InnerOffset { get; set; }
        public int? OuterOffset { get; set; }
        public string? Rounding { get; set; }
        public int? Numerator { get; set; }
        public int? Factor { get; set; }
        public int? Denominator { get; set; }
    }

    [Serializable]
    public class UnitOfMeasureConversions : UnitOfMeasureConversionsBase { }

    [Serializable]
    public class UnitOfMeasureConversionsTestR : UnitOfMeasureConversionsBase { }


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

    public class AllProducts : AllProductsBase { }

    public class AllProductsTestR : AllProductsBase { }


    // Composite key defined using the [PrimaryKey] attribute (EF Core 7+)
    [PrimaryKey(nameof(BudgetModel), nameof(DataAreaId))]
    public class BudgetModelPoco
    {
        // Optional fields (nullable in the database)
        [JsonProperty("etag", NullValueHandling = NullValueHandling.Ignore)]
        public string? Etag { get; set; }

        [JsonProperty("parentReference", NullValueHandling = NullValueHandling.Ignore)]
        public string? ParentReference { get; set; }

        [JsonProperty("cashFlowForecasts", NullValueHandling = NullValueHandling.Ignore)]
        public string? CashFlowForecasts { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("stopped", NullValueHandling = NullValueHandling.Ignore)]
        public string? Stopped { get; set; }

        // Non-nullable fields (required in the database)
        [JsonProperty("BudgetModel")]
        public string BudgetModel { get; set; }

        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; }
    }

    public class BudgetModel : BudgetModelPoco { }

    public class BudgetModelTestR : BudgetModelPoco { }


    // For EF Core 7+ use [PrimaryKey] to define composite keys at the class level.
    [PrimaryKey(nameof(DataAreaId), nameof(EntryNumber), nameof(LegalEntityId))]
    public class BudgetRegisterEntryHeadersPoco
    {
        // JSON Property: "dataAreaId"
        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; }

        // JSON Property: "EntryNumber"
        [JsonProperty("EntryNumber")]
        public string EntryNumber { get; set; }

        // JSON Property: "LegalEntityId"
        [JsonProperty("LegalEntityId")]
        public string LegalEntityId { get; set; }

        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; }

        // JSON Property: "ReasonCode"
        [JsonProperty("ReasonCode")]
        public string? ReasonCode { get; set; }

        // JSON Property: "BudgetCode"
        [JsonProperty("BudgetCode")]
        public string? BudgetCode { get; set; }

        // JSON Property: "Status"
        [JsonProperty("Status")]
        public string? Status { get; set; }

        // JSON Property: "WorkflowStatus"
        [JsonProperty("WorkflowStatus")]
        public string? WorkflowStatus { get; set; }

        // JSON Property: "BudgetType"
        [JsonProperty("BudgetType")]
        public string? BudgetType { get; set; }

        // JSON Property: "RevenueBudgetTotal"
        [JsonProperty("RevenueBudgetTotal")]
        public decimal? RevenueBudgetTotal { get; set; }

        // JSON Property: "DefaultDate"
        [JsonProperty("DefaultDate")]
        public DateTime? DefaultDate { get; set; }

        // JSON Property: "BudgetModelId"
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

    public class BudgetRegisterEntryHeaders : BudgetRegisterEntryHeadersPoco { }

    public class BudgetRegisterEntryHeadersTestR : BudgetRegisterEntryHeadersPoco { }


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

    public class CustomerItems : CustomerItemsBase { }

    public class CustomerItemsTestR : CustomerItemsBase { }


    [PrimaryKey(nameof(DataAreaId), nameof(Chapter), nameof(Heading), nameof(Subheading), nameof(CountryExtension), nameof(StatisticalSuffix))]
    public abstract partial class HSNCodesBase
    {
        // JSON Property: "@odata.etag"
        [JsonProperty("@odata.etag")]
        public string? Etag { get; set; } // Nullable string

        // JSON Property: "dataAreaId"
        [Key]
        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; } // Nullable string

        // JSON Property: "Chapter"
        [Key]
        [JsonProperty("Chapter")]
        public string Chapter { get; set; } // Nullable string

        // JSON Property: "Heading"
        [Key]
        [JsonProperty("Heading")]
        public string Heading { get; set; } // Nullable string

        // JSON Property: "Subheading"
        [Key]
        [JsonProperty("Subheading")]
        public string Subheading { get; set; } // Nullable string

        // JSON Property: "CountryExtension"
        [Key]
        [JsonProperty("CountryExtension")]
        public string CountryExtension { get; set; } // Nullable string

        // JSON Property: "StatisticalSuffix"
        [Key]
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

    public class HSNCodes : HSNCodesBase { }
}

