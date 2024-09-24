using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "WarehouseId")]
public abstract partial class WarehousesBase
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
    public string WarehouseId { get; set; } = null!;

    [StringLength(2000)]
    public string? ActivityType_RU { get; set; }

    [StringLength(2000)]
    public string? AreAdvancedWarehouseManagementProcessesEnabled { get; set; }

    [StringLength(2000)]
    public string? AreItemsCoveragePlannedManually { get; set; }

    [StringLength(2000)]
    public string? AreLaborStandardsAllowed { get; set; }

    [StringLength(2000)]
    public string? ArePickingListsDeliveryModeSpecific { get; set; }

    [StringLength(2000)]
    public string? ArePickingListsShipmentSpecificOnly { get; set; }

    [StringLength(2000)]
    public string? AreWarehouseLocationCheckDigitsUnique { get; set; }

    [StringLength(2000)]
    public string? AutoUpdateShipmentRule { get; set; }

    [StringLength(2000)]
    public string? DefaultContainerTypeId { get; set; }

    public long? DimensionDefault { get; set; }

    [StringLength(255)]
    public string? ExternallyLocatedWarehouseCustomerAccountNumber { get; set; }

    [StringLength(255)]
    public string? ExternallyLocatedWarehouseVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? FormattedPrimaryAddress { get; set; }

    [StringLength(2000)]
    public string? GoodsInTransitWarehouseId { get; set; }

    [StringLength(2000)]
    public string? IdentificationGroup { get; set; }

    [StringLength(2000)]
    public string? InventLocationIdGoodsInRoute_RU { get; set; }

    [StringLength(255)]
    public string? InventoryCountingReasonCodePolicyName { get; set; }

    [StringLength(2000)]
    public string? InventoryStatusChangeReservationRemovalLevel { get; set; }

    [StringLength(2000)]
    public string? InventProfileId_RU { get; set; }

    [StringLength(2000)]
    public string? InventProfileType_RU { get; set; }

    [StringLength(2000)]
    public string? IsActive { get; set; }

    [StringLength(2000)]
    public string? IsBillOfLadingPrintingBeforeShipmentConfirmationEnabled { get; set; }

    [StringLength(2000)]
    public string? IsFallbackWarehouse { get; set; }

    [StringLength(2000)]
    public string? IsFinancialNegativeRetailStoreInventoryAllowed { get; set; }

    [StringLength(2000)]
    public string? IsPalletMovementDuringCycleCountingAllowed { get; set; }

    [StringLength(2000)]
    public string? IsPhysicalNegativeRetailStoreInventoryAllowed { get; set; }

    [StringLength(2000)]
    public string? IsPrimaryAddressAssigned { get; set; }

    [StringLength(2000)]
    public string? IsRefilledFromMainWarehouse { get; set; }

    [StringLength(2000)]
    public string? IsRetailStoreWarehouse { get; set; }

    [StringLength(2000)]
    public string? LoadReleaseReservationPolicyRule { get; set; }

    [StringLength(2000)]
    public string? LocationId { get; set; }

    [StringLength(255)]
    public string? MainRefillingWarehouseId { get; set; }

    [StringLength(2000)]
    public string? MasterPlanningWorkCalendardId { get; set; }

    public int? MaximumBatchPickingListQuantity { get; set; }

    public int? MaximumPickingListLineQuantity { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroup_RU { get; set; }

    [StringLength(255)]
    public string? OperationalSiteId { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressBuildingCompliment { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressCity { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressCityInKana { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressDescription { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressDistrictName { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PrimaryAddressLatitude { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressLocationRoles { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressLocationSalesTaxGroupCode { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PrimaryAddressLongitude { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressPostBox { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressStateId { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressStreet { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressStreetInKana { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressStreetNumber { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressTimeZone { get; set; }

    [StringLength(2000)]
    public string? PrimaryAddressZipCode { get; set; }

    [StringLength(255)]
    public string? QuarantineWarehouseId { get; set; }

    [StringLength(2000)]
    public string? RawMaterialPickingInventoryIssueStatus { get; set; }

    [StringLength(2000)]
    public string? RBODefaultInventProfileId_RU { get; set; }

    public long? RecId1 { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? RetailStoreQuantityAllocationReplenismentRuleWeight { get; set; }

    [StringLength(2000)]
    public string? ShouldWarehouseLocationIdIncludeAisleId { get; set; }

    [StringLength(2000)]
    public string? STNumberSeqIn { get; set; }

    [StringLength(2000)]
    public string? STNumberSeqOut { get; set; }

    [StringLength(2000)]
    public string? TONumberSeqIn { get; set; }

    [StringLength(2000)]
    public string? TONumberSeqOut { get; set; }

    [StringLength(255)]
    public string? TransitWarehouseId { get; set; }

    [StringLength(2000)]
    public string? UnderdeliveryWarehouseId { get; set; }

    [StringLength(2000)]
    public string? VendAccountCustom_RU { get; set; }

    [StringLength(2000)]
    public string? WarehouseLocationIdBinIdFormat { get; set; }

    [StringLength(2000)]
    public string? WarehouseLocationIdRackIdFormat { get; set; }

    [StringLength(2000)]
    public string? WarehouseLocationIdShelfIdFormat { get; set; }

    [StringLength(2000)]
    public string? WarehouseName { get; set; }

    [StringLength(2000)]
    public string? WarehouseReleaseReservationRequirementRule { get; set; }

    [StringLength(2000)]
    public string? WarehouseSpecificDefaultInventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? WarehouseType { get; set; }

    [StringLength(2000)]
    public string? WarehouseWorkProcessingPolicyName { get; set; }

    [StringLength(2000)]
    public string? WillAutomaticLoadReleaseReserveInventory { get; set; }

    [StringLength(2000)]
    public string? WillInventoryStatusChangeRemoveBlocking { get; set; }

    [StringLength(2000)]
    public string? WillManualLoadReleaseReserveInventory { get; set; }

    [StringLength(2000)]
    public string? WillOrderReleasingConsolidateShipments { get; set; }

    [StringLength(2000)]
    public string? WillProductionBOMsReserveWarehouseLevelOnly { get; set; }

    [StringLength(2000)]
    public string? WillShippingCancellationDecrementLoadQuanity { get; set; }

    [StringLength(2000)]
    public string? WillWarehouseLocationIdIncludeBinIdByDefault { get; set; }

    [StringLength(2000)]
    public string? WillWarehouseLocationIdIncludeRackIdByDefault { get; set; }

    [StringLength(2000)]
    public string? WillWarehouseLocationIdIncludeShelfIdByDefault { get; set; }

    [StringLength(2000)]
    public string? WMSLocationIdGoodsInRoute_RU { get; set; }

    [StringLength(2000)]
    public string? ReportAsFinishedPostingMethod { get; set; }

    [StringLength(2000)]
    public string? IsDepot { get; set; }

    [StringLength(2000)]
    public string? LanguageUsedForDomesticHazardousMaterialsShippingDocuments { get; set; }

    [StringLength(2000)]
    public string? LanguageUsedForExportHazardousMaterialsShippingDocuments { get; set; }

    [StringLength(2000)]
    public string? ExternalWarehouseDefaultLocationId { get; set; }

    [StringLength(2000)]
    public string? ExternalWarehouseId { get; set; }

    [StringLength(255)]
    public string? ExternalWarehouseManagementSystemId { get; set; }

    [StringLength(2000)]
    public string? IsWarehouseExternallyManaged { get; set; }

    [StringLength(2000)]
    public string? IsExportedtoSFTP { get; set; }
}

public partial class WarehousesTest : WarehousesBase { }

public partial class Warehouses : WarehousesBase { }
