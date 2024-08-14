using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "HeaderReference", "InvoiceLineNumber")]
public abstract partial class VendorInvoiceLinesBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string HeaderReference { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal InvoiceLineNumber { get; set; }

    [StringLength(2000)]
    public string? AccountingDistributionTemplateId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AdjustedUnitPrice { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Amount { get; set; }

    [StringLength(2000)]
    public string? BudgetReservationDocumentNumber { get; set; }

    public int? BudgetReservationLineNumber { get; set; }

    [StringLength(2000)]
    public string? CFOPCode { get; set; }

    [StringLength(2000)]
    public string? ChangeQuantityManually { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ChargesOnPurchases { get; set; }

    [StringLength(2000)]
    public string? CloseForReceipt { get; set; }

    [StringLength(2000)]
    public string? Commodity { get; set; }

    [StringLength(2000)]
    public string? CountyOrigDest { get; set; }

    [StringLength(2000)]
    public string? Currency { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CWDeliveryRemainder { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CWRemainingQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CWUpdate { get; set; }

    [StringLength(2000)]
    public string? DataAreaCompany { get; set; }

    [StringLength(2000)]
    public string? DeliveryName { get; set; }

    [StringLength(2000)]
    public string? DeliveryState { get; set; }

    [StringLength(2000)]
    public string? DimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DimensionNumber { get; set; }

    [StringLength(2000)]
    public string? DiotOperationType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Discount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DiscountPercent { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InventNow { get; set; }

    [StringLength(2000)]
    public string? InventorySiteId { get; set; }

    [StringLength(2000)]
    public string? InventoryWarehouseId { get; set; }

    [StringLength(2000)]
    public string? InvoiceAccount { get; set; }

    [StringLength(2000)]
    public string? IsTax1099GTradeOrBusinessIncome { get; set; }

    [StringLength(2000)]
    public string? IsTax1099SPropertyOrServices { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    [StringLength(2000)]
    public string? ItemName { get; set; }

    [StringLength(2000)]
    public string? ItemNumber { get; set; }

    [StringLength(2000)]
    public string? ItemSalesTax { get; set; }

    [StringLength(2000)]
    public string? LineDescription { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineNumber { get; set; }

    [StringLength(2000)]
    public string? LineType { get; set; }

    [StringLength(2000)]
    public string? MainAccountDisplayValue { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultilineDiscount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MultilineDiscountPercentage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? NetAmount { get; set; }

    [StringLength(2000)]
    public string? OrderedInventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? Ordering { get; set; }

    [StringLength(2000)]
    public string? OrigCountryRegionId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? OriginalDeliverRemainder { get; set; }

    public byte[]? PackedExtensions { get; set; }

    [StringLength(2000)]
    public string? PartyID { get; set; }

    [StringLength(2000)]
    public string? PDSCalculationId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Percentage { get; set; }

    [StringLength(2000)]
    public string? Port { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceUnit { get; set; }

    [StringLength(2000)]
    public string? ProcurementCategoryHierarchyName { get; set; }

    [StringLength(2000)]
    public string? ProcurementCategoryName { get; set; }

    [StringLength(2000)]
    public string? ProductColorId { get; set; }

    [StringLength(2000)]
    public string? ProductConfigurationId { get; set; }

    [StringLength(2000)]
    public string? ProductSizeId { get; set; }

    [StringLength(2000)]
    public string? ProductStyleId { get; set; }

    [StringLength(2000)]
    public string? ProductVersionId { get; set; }

    [StringLength(255)]
    public string? PurchaseOrder { get; set; }

    public long? PurchLineNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReceiveNow { get; set; }

    [StringLength(2000)]
    public string? ReleaseAllRetainedAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainAfter { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainAfterInvent { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainBefore { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainBeforeInvent { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RetainageAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RetainPercentage { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroup { get; set; }

    [StringLength(2000)]
    public string? StateOfOrigin { get; set; }

    [StringLength(2000)]
    public string? StatisticsProcedure { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Tax1099Amount { get; set; }

    [StringLength(2000)]
    public string? Tax1099Box { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Tax1099GStateTaxWithheldAmount { get; set; }

    public int? Tax1099GTaxYear { get; set; }

    [StringLength(2000)]
    public string? Tax1099GVendorStateId { get; set; }

    [StringLength(2000)]
    public string? Tax1099GVendorStateTaxId { get; set; }

    [StringLength(2000)]
    public string? Tax1099SAddressOrLegalDescription { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Tax1099SBuyerPartOfRealEstateTaxAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Tax1099SClosingDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Tax1099StateAmount { get; set; }

    [StringLength(2000)]
    public string? Tax1099Type { get; set; }

    [StringLength(2000)]
    public string? TaxServiceCode { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdGroup { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdItemGroupName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TotalRetainedAmount { get; set; }

    [StringLength(2000)]
    public string? TransactionCode { get; set; }

    [StringLength(2000)]
    public string? Transport { get; set; }

    [StringLength(2000)]
    public string? Unit { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? UnitPrice { get; set; }

    [StringLength(2000)]
    public string? VendorAccount { get; set; }

    [StringLength(2000)]
    public string? VendorInvoiceLineReviewStatus { get; set; }

    [StringLength(2000)]
    public string? WithholdingTaxGroup { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesTax { get; set; }

    [StringLength(2000)]
    public string? WithholdingTaxItemGroup { get; set; }
}

public partial class VendorInvoiceLinesTest : VendorInvoiceLinesBase {}

public partial class VendorInvoiceLines : VendorInvoiceLinesBase {}
