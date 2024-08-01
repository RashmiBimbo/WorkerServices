using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("DataAreaId", "LineNumber", "PurchaseOrderNumber")]
[Table("PurchaseOrderLinesV2")]
public partial class PurchaseOrderLinesV2Test
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [Column("dataAreaId")]
    [StringLength(255)]
    public string DataAreaId { get; set; } = null!;

    [Key]
    public long LineNumber { get; set; }

    [Key]
    [StringLength(255)]
    public string PurchaseOrderNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AccountingDistributionTemplateName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AllowedOverdeliveryPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AllowedUnderdeliveryPercentage { get; set; }

    [StringLength(2000)]
    public string? Barcode { get; set; }

    [StringLength(2000)]
    public string? BarCodeSetupId { get; set; }

    [Column("BOMId")]
    [StringLength(2000)]
    public string? Bomid { get; set; }

    [StringLength(2000)]
    public string? BudgetReservationDocumentNumber { get; set; }

    public int? BudgetReservationLineNumber { get; set; }

    [StringLength(2000)]
    public string? CalculateLineAmount { get; set; }

    [StringLength(2000)]
    public string? CatchWeightUnitSymbol { get; set; }

    [Column("CFOPCode")]
    [StringLength(2000)]
    public string? Cfopcode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedDeliveryDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedShippingDate { get; set; }

    [StringLength(2000)]
    public string? CustomerReference { get; set; }

    [StringLength(2000)]
    public string? CustomerRequisitionNumber { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCity { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionId { get; set; }

    [Column("DeliveryAddressCountryRegionISOCode")]
    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionIsocode { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDescription { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDistrictName { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressDunsNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? DeliveryAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressLocationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? DeliveryAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressName { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStateId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreet { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressZipCode { get; set; }

    [StringLength(2000)]
    public string? DeliveryBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? DeliveryCityInKana { get; set; }

    [StringLength(2000)]
    public string? DeliveryStreetInKana { get; set; }

    [Column("DIOTOperationType")]
    [StringLength(2000)]
    public string? DiotoperationType { get; set; }

    [StringLength(2000)]
    public string? ExternalItemNumber { get; set; }

    [StringLength(2000)]
    public string? FixedAssetGroupId { get; set; }

    [StringLength(2000)]
    public string? FixedAssetNumber { get; set; }

    [StringLength(2000)]
    public string? FixedAssetTransactionType { get; set; }

    [StringLength(2000)]
    public string? FixedAssetValueModelId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? FixedPriceCharges { get; set; }

    [StringLength(2000)]
    public string? FormattedDelveryAddress { get; set; }

    [Column("GSTHSTTaxType")]
    [StringLength(2000)]
    public string? GsthsttaxType { get; set; }

    [StringLength(2000)]
    public string? IntrastatCommodityCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatPortId { get; set; }

    [StringLength(2000)]
    public string? IntrastatSpecialMovementCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatStatisticsProcedureCode { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? IntrastatStatisticValue { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransactionCode { get; set; }

    [StringLength(2000)]
    public string? IntrastatTransportModeCode { get; set; }

    [StringLength(2000)]
    public string? InventoryLotId { get; set; }

    [StringLength(2000)]
    public string? IsAddedByChannel { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressOrderSpecific { get; set; }

    [StringLength(2000)]
    public string? IsDeliveryAddressPrivate { get; set; }

    [StringLength(2000)]
    public string? IsIntrastatTriangularDeal { get; set; }

    [StringLength(2000)]
    public string? IsLineStopped { get; set; }

    [StringLength(2000)]
    public string? IsNewFixedAsset { get; set; }

    [StringLength(2000)]
    public string? IsPartialDeliveryPrevented { get; set; }

    [StringLength(2000)]
    public string? IsProjectPayWhenPaid { get; set; }

    [Column("IsTax1099GTradeOrBusinessIncome")]
    [StringLength(2000)]
    public string? IsTax1099GtradeOrBusinessIncome { get; set; }

    [Column("IsTax1099SPropertyOrServices")]
    [StringLength(2000)]
    public string? IsTax1099SpropertyOrServices { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    [StringLength(2000)]
    public string? ItemNumber { get; set; }

    [StringLength(2000)]
    public string? ItemWithholdingTaxGroupCode { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineAmount { get; set; }

    [StringLength(2000)]
    public string? LineDescription { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineDiscountAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineDiscountPercentage { get; set; }

    [StringLength(2000)]
    public string? MainAccountIdDisplayValue { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MultilineDiscountAmount { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MultilineDiscountPercentage { get; set; }

    [Column("NGPCode")]
    public int? Ngpcode { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OrderedCatchWeightQuantity { get; set; }

    [StringLength(2000)]
    public string? OrderedInventoryStatusId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OrderedPurchaseQuantity { get; set; }

    [StringLength(2000)]
    public string? OriginCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? OriginStateId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PlanningPriority { get; set; }

    [StringLength(2000)]
    public string? ProcurementProductCategoryName { get; set; }

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

    [StringLength(2000)]
    public string? ProjectActivityNumber { get; set; }

    [StringLength(2000)]
    public string? ProjectCategoryId { get; set; }

    [StringLength(2000)]
    public string? ProjectId { get; set; }

    [StringLength(2000)]
    public string? ProjectLinePropertyId { get; set; }

    [StringLength(2000)]
    public string? ProjectSalesCurrencyCode { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ProjectSalesPrice { get; set; }

    [StringLength(2000)]
    public string? ProjectSalesUnitSymbol { get; set; }

    [StringLength(2000)]
    public string? ProjectTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? ProjectTaxItemGroupCode { get; set; }

    [StringLength(2000)]
    public string? ProjectWorkerPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderLineCreationMethod { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderLineStatus { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PurchasePrice { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PurchasePriceQuantity { get; set; }

    [StringLength(2000)]
    public string? PurchaseRebateVendorGroupId { get; set; }

    [StringLength(2000)]
    public string? PurchaseRequisitionId { get; set; }

    [StringLength(2000)]
    public string? PurchaseUnitSymbol { get; set; }

    [StringLength(2000)]
    public string? ReceivingSiteId { get; set; }

    [StringLength(2000)]
    public string? ReceivingWarehouseId { get; set; }

    [StringLength(2000)]
    public string? ReceivingWarehouseLocationId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedDeliveryDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedShippingDate { get; set; }

    [StringLength(2000)]
    public string? RequesterPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? RetailProductVariantNumber { get; set; }

    [StringLength(2000)]
    public string? RouteId { get; set; }

    [StringLength(2000)]
    public string? SalesTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? SalesTaxItemGroupCode { get; set; }

    [StringLength(2000)]
    public string? ServiceFiscalInformationCode { get; set; }

    [StringLength(2000)]
    public string? SkipCreateAutoCharges { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Tax1099Amount { get; set; }

    [StringLength(2000)]
    public string? Tax1099BoxId { get; set; }

    [Column("Tax1099GStateTaxWithheldAmount", TypeName = "decimal(38, 16)")]
    public decimal? Tax1099GstateTaxWithheldAmount { get; set; }

    [Column("Tax1099GTaxYear")]
    public int? Tax1099GtaxYear { get; set; }

    [Column("Tax1099GVendorStateId")]
    [StringLength(2000)]
    public string? Tax1099GvendorStateId { get; set; }

    [Column("Tax1099GVendorStateTaxId")]
    [StringLength(2000)]
    public string? Tax1099GvendorStateTaxId { get; set; }

    [Column("Tax1099SAddressOrLegalDescription")]
    [StringLength(2000)]
    public string? Tax1099SaddressOrLegalDescription { get; set; }

    [Column("Tax1099SBuyerPartOfRealEstateTaxAmount", TypeName = "decimal(38, 16)")]
    public decimal? Tax1099SbuyerPartOfRealEstateTaxAmount { get; set; }

    [Column("Tax1099SClosingDate", TypeName = "datetime")]
    public DateTime? Tax1099SclosingDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Tax1099StateAmount { get; set; }

    [StringLength(2000)]
    public string? Tax1099StateId { get; set; }

    [StringLength(2000)]
    public string? Tax1099Type { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? UnitWeight { get; set; }

    [StringLength(2000)]
    public string? VendorInvoiceMatchingPolicy { get; set; }

    [StringLength(2000)]
    public string? VendorRetentionTermRuleDescription { get; set; }

    [StringLength(2000)]
    public string? VendorRetentionTermRuleId { get; set; }

    [StringLength(2000)]
    public string? WillProductReceivingCrossDockProducts { get; set; }

    [StringLength(2000)]
    public string? WithholdingTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? WorkflowState { get; set; }

    [StringLength(2000)]
    public string? OverrideSalesTax { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? DlvMode { get; set; }

    [StringLength(2000)]
    public string? DlvTerm { get; set; }

    [StringLength(2000)]
    public string? ItemSerialNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedShipDate { get; set; }

    [StringLength(2000)]
    public string? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestedShipDate { get; set; }

    [StringLength(2000)]
    public string? ShipCalendarId { get; set; }
}
