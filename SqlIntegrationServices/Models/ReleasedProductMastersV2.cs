using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "ItemNumber")]
public abstract partial class ReleasedProductMastersV2Base
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
    public string ItemNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AlternativeItemNumber { get; set; }

    [StringLength(2000)]
    public string? AlternativeProductColorId { get; set; }

    [StringLength(2000)]
    public string? AlternativeProductConfigurationId { get; set; }

    [StringLength(2000)]
    public string? AlternativeProductSizeId { get; set; }

    [StringLength(2000)]
    public string? AlternativeProductStyleId { get; set; }

    [StringLength(2000)]
    public string? AlternativeProductUsageCondition { get; set; }

    [StringLength(2000)]
    public string? AlternativeProductVersionId { get; set; }

    [StringLength(2000)]
    public string? ApprovedVendorCheckMethod { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ApproximateSalesTaxPercentage { get; set; }

    [StringLength(2000)]
    public string? AreTransportationManagementProcessesEnabled { get; set; }

    public int? ArrivalHandlingTime { get; set; }

    [StringLength(2000)]
    public string? BarcodeSetupId { get; set; }

    [StringLength(2000)]
    public string? BaseSalesPriceSource { get; set; }

    [StringLength(2000)]
    public string? BatchMergeDateCalculationMethod { get; set; }

    [StringLength(2000)]
    public string? BatchNumberGroupCode { get; set; }

    public int? BestBeforePeriodDays { get; set; }

    public int? BOMLevel { get; set; }

    [StringLength(2000)]
    public string? BOMUnitSymbol { get; set; }

    [StringLength(2000)]
    public string? BuyerGroupId { get; set; }

    [StringLength(2000)]
    public string? CarryingCostABCCode { get; set; }

    [StringLength(2000)]
    public string? CatchWeightUnitSymbol { get; set; }

    [StringLength(2000)]
    public string? CommissionProductGroupId { get; set; }

    [StringLength(2000)]
    public string? ComparisonPriceBaseUnitSymbol { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ConstantScrapQuantity { get; set; }

    public int? ContinuityEventDuration { get; set; }

    [StringLength(2000)]
    public string? ContinuityScheduleId { get; set; }

    public int? CostCalculationBOMLevel { get; set; }

    [StringLength(2000)]
    public string? CostCalculationGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CostChargesQuantity { get; set; }

    [StringLength(2000)]
    public string? CostGroupId { get; set; }

    [StringLength(2000)]
    public string? DefaultDirectDeliveryWarehouse { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DefaultOrderType { get; set; }

    [StringLength(2000)]
    public string? DefaultProductColorId { get; set; }

    [StringLength(2000)]
    public string? DefaultProductConfigurationId { get; set; }

    [StringLength(2000)]
    public string? DefaultProductSizeId { get; set; }

    [StringLength(2000)]
    public string? DefaultProductStyleId { get; set; }

    [StringLength(2000)]
    public string? DefaultProductVersionId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? DefaultReceivingQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FixedCostCharges { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FixedPurchasePriceCharges { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FixedSalesPriceCharges { get; set; }

    [StringLength(2000)]
    public string? FlushingPrinciple { get; set; }

    [StringLength(2000)]
    public string? FreightAllocationGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? GrossDepth { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? GrossProductHeight { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? GrossProductWidth { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? IntrastatChargePercentage { get; set; }

    [StringLength(2000)]
    public string? IntrastatCommodityCode { get; set; }

    [StringLength(2000)]
    public string? InventoryGSTReliefCategoryCode { get; set; }

    [StringLength(2000)]
    public string? InventoryReservationHierarchyName { get; set; }

    [StringLength(2000)]
    public string? InventoryUnitSymbol { get; set; }

    [StringLength(2000)]
    public string? IsDeliveredDirectly { get; set; }

    [StringLength(2000)]
    public string? IsDiscountPOSRegistrationProhibited { get; set; }

    [StringLength(2000)]
    public string? IsExemptFromAutomaticNotificationAndCancellation { get; set; }

    [StringLength(2000)]
    public string? IsICMSTaxAppliedOnService { get; set; }

    [StringLength(2000)]
    public string? IsInstallmentEligible { get; set; }

    [StringLength(2000)]
    public string? IsIntercompanyPurchaseUsageBlocked { get; set; }

    [StringLength(2000)]
    public string? IsIntercompanySalesUsageBlocked { get; set; }

    [StringLength(2000)]
    public string? IsPhantom { get; set; }

    [StringLength(2000)]
    public string? IsPOSRegistrationBlocked { get; set; }

    [StringLength(2000)]
    public string? IsPOSRegistrationQuantityNegative { get; set; }

    [StringLength(2000)]
    public string? IsPurchasePriceAutomaticallyUpdated { get; set; }

    [StringLength(2000)]
    public string? IsPurchasePriceIncludingCharges { get; set; }

    [StringLength(2000)]
    public string? IsPurchaseWithholdingTaxCalculated { get; set; }

    [StringLength(2000)]
    public string? IsRestrictedForCoupons { get; set; }

    [StringLength(2000)]
    public string? IsSalesPriceAdjustmentAllowed { get; set; }

    [StringLength(2000)]
    public string? IsSalesPriceIncludingCharges { get; set; }

    [StringLength(2000)]
    public string? IsSalesWithholdingTaxCalculated { get; set; }

    [StringLength(2000)]
    public string? IsScaleProduct { get; set; }

    [StringLength(2000)]
    public string? IsShipAloneEnabled { get; set; }

    [StringLength(2000)]
    public string? IsUnitCostAutomaticallyUpdated { get; set; }

    [StringLength(2000)]
    public string? IsUnitCostIncludingCharges { get; set; }

    [StringLength(2000)]
    public string? IsUnitCostProductVariantSpecific { get; set; }

    [StringLength(2000)]
    public string? IsVariantShelfLabelsPrintingEnabled { get; set; }

    [StringLength(2000)]
    public string? IsZeroPricePOSRegistrationAllowed { get; set; }

    [StringLength(2000)]
    public string? ItemFiscalClassificationCode { get; set; }

    [StringLength(2000)]
    public string? ItemFiscalClassificationExceptionCode { get; set; }

    [StringLength(2000)]
    public string? ItemModelGroupId { get; set; }

    [StringLength(2000)]
    public string? KeyInPriceRequirementsAtPOSRegister { get; set; }

    [StringLength(2000)]
    public string? KeyInQuantityRequirementsAtPOSRegister { get; set; }

    [StringLength(2000)]
    public string? MarginABCCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MaximumCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MaximumPickQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MinimumCatchWeightQuantity { get; set; }

    [StringLength(2000)]
    public string? MustKeyInCommentAtPOSRegister { get; set; }

    [StringLength(2000)]
    public string? NecessaryProductionWorkingTimeSchedulingPropertyId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? NetProductWeight { get; set; }

    public int? NGPCode { get; set; }

    [StringLength(2000)]
    public string? OriginCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? OriginStateId { get; set; }

    [StringLength(2000)]
    public string? PackageClassId { get; set; }

    public int? PackageHandlingTime { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PackingDutyQuantity { get; set; }

    [StringLength(2000)]
    public string? PackingMaterialGroupId { get; set; }

    [StringLength(2000)]
    public string? PackSizeCategoryId { get; set; }

    [StringLength(2000)]
    public string? PhysicalDimensionGroupId { get; set; }

    [StringLength(2000)]
    public string? PlanningFormulaItemNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? POSRegistrationActivationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? POSRegistrationBlockedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? POSRegistrationPlannedBlockedDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PotencyBaseAttibuteTargetValue { get; set; }

    [StringLength(2000)]
    public string? PotencyBaseAttributeValueEntryEvent { get; set; }

    [StringLength(2000)]
    public string? PrimaryVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? ProductCoverageGroupId { get; set; }

    [StringLength(2000)]
    public string? ProductFiscalInformationType { get; set; }

    [StringLength(2000)]
    public string? ProductGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProductionConsumptionDensityConversionFactor { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProductionConsumptionDepthConversionFactor { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProductionConsumptionHeightConversionFactor { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProductionConsumptionWidthConversionFactor { get; set; }

    [StringLength(2000)]
    public string? ProductionGroupId { get; set; }

    [StringLength(2000)]
    public string? ProductionPoolId { get; set; }

    [StringLength(2000)]
    public string? ProductionType { get; set; }

    [StringLength(2000)]
    public string? ProductLifeCycleSeasonCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProductLifeCycleValidFromDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProductLifeCycleValidToDate { get; set; }

    [StringLength(255)]
    public string? ProductNumber { get; set; }

    [StringLength(2000)]
    public string? ProductSearchName { get; set; }

    [StringLength(2000)]
    public string? ProductTaxationOrigin { get; set; }

    [StringLength(2000)]
    public string? ProductType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProductVolume { get; set; }

    [StringLength(2000)]
    public string? ProjectCategoryId { get; set; }

    [StringLength(2000)]
    public string? PurchaseChargeProductGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchaseChargesQuantity { get; set; }

    [StringLength(2000)]
    public string? PurchaseGSTReliefCategoryCode { get; set; }

    [StringLength(2000)]
    public string? PurchaseItemWithholdingTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? PurchaseLineDiscountProductGroupCode { get; set; }

    [StringLength(2000)]
    public string? PurchaseMultilineDiscountProductGroupCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchaseOverdeliveryPercentage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchasePrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PurchasePriceDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchasePriceQuantity { get; set; }

    [StringLength(2000)]
    public string? PurchasePriceToleranceGroupId { get; set; }

    public int? PurchasePricingPrecision { get; set; }

    [StringLength(2000)]
    public string? PurchaseRebateProductGroupId { get; set; }

    [StringLength(2000)]
    public string? PurchaseSalesTaxItemGroupCode { get; set; }

    [StringLength(2000)]
    public string? PurchaseSupplementaryProductProductGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PurchaseUnderdeliveryPercentage { get; set; }

    [StringLength(2000)]
    public string? PurchaseUnitSymbol { get; set; }

    [StringLength(2000)]
    public string? RawMaterialPickingPrinciple { get; set; }

    [StringLength(2000)]
    public string? RevenueABCCode { get; set; }

    [StringLength(2000)]
    public string? SalesChargeProductGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesChargesQuantity { get; set; }

    [StringLength(2000)]
    public string? SalesGSTReliefCategoryCode { get; set; }

    [StringLength(2000)]
    public string? SalesItemWithholdingTaxGroupCode { get; set; }

    [StringLength(2000)]
    public string? SalesLineDiscountProductGroupCode { get; set; }

    [StringLength(2000)]
    public string? SalesMultilineDiscountProductGroupCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesOverdeliveryPercentage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesPrice { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesPriceCalculationChargesPercentage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesPriceCalculationContributionRatio { get; set; }

    [StringLength(2000)]
    public string? SalesPriceCalculationModel { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SalesPriceDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesPriceQuantity { get; set; }

    public int? SalesPricingPrecision { get; set; }

    [StringLength(2000)]
    public string? SalesRebateProductGroupId { get; set; }

    [StringLength(2000)]
    public string? SalesSalesTaxItemGroupCode { get; set; }

    [StringLength(2000)]
    public string? SalesSupplementaryProductProductGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesUnderdeliveryPercentage { get; set; }

    [StringLength(2000)]
    public string? SalesUnitSymbol { get; set; }

    [StringLength(2000)]
    public string? SearchName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SellEndDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SellStartDate { get; set; }

    [StringLength(2000)]
    public string? SerialNumberGroupCode { get; set; }

    [StringLength(2000)]
    public string? ServiceFiscalInformationCode { get; set; }

    public int? ShelfAdvicePeriodDays { get; set; }

    public int? ShelfLifePeriodDays { get; set; }

    public int? ShippingAndReceivingSortOrderCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ShipStartDate { get; set; }

    [StringLength(2000)]
    public string? StorageDimensionGroupName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TareProductWeight { get; set; }

    [StringLength(2000)]
    public string? TrackingDimensionGroupName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TransferOrderOverdeliveryPercentage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? TransferOrderUnderdeliveryPercentage { get; set; }

    [StringLength(2000)]
    public string? UnitConversionSequenceGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? UnitCost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UnitCostDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? UnitCostQuantity { get; set; }

    [StringLength(2000)]
    public string? ValueABCCode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VariableScrapPercentage { get; set; }

    [StringLength(2000)]
    public string? VendorInvoiceLineMatchingPolicy { get; set; }

    [StringLength(2000)]
    public string? WarehouseMobileDeviceDescriptionLine1 { get; set; }

    [StringLength(2000)]
    public string? WarehouseMobileDeviceDescriptionLine2 { get; set; }

    [StringLength(2000)]
    public string? WillInventoryIssueAutomaticallyReportAsFinished { get; set; }

    [StringLength(2000)]
    public string? WillInventoryReceiptIgnoreFlushingPrinciple { get; set; }

    [StringLength(2000)]
    public string? WillPickingWorkbenchApplyBoxingLogic { get; set; }

    [StringLength(2000)]
    public string? WillTotalPurchaseDiscountCalculationIncludeProduct { get; set; }

    [StringLength(2000)]
    public string? WillTotalSalesDiscountCalculationIncludeProduct { get; set; }

    [StringLength(2000)]
    public string? WillWorkCenterPickingAllowNegativeInventory { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? YieldPercentage { get; set; }
}

public partial class ReleasedProductMastersV2Test : ReleasedProductMastersV2Base {}

public partial class ReleasedProductMastersV2 : ReleasedProductMastersV2Base {}
