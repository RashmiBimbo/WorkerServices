using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "LineNumber", "ProductionOrderNumber")]
public abstract partial class ProductionOrderBillOfMaterialLinesBase
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
    [Column(TypeName = "decimal(28, 16)")]
    public decimal LineNumber { get; set; }

    [Key]
    [StringLength(255)]
    public string ProductionOrderNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AutoReservationMode { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? BOMLineQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? BOMLineQuantityDenominator { get; set; }

    [StringLength(2000)]
    public string? BOMLineUnitSymbol { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ConstantScrapBOMLineQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ConsumptionCalculationConstant { get; set; }

    [StringLength(2000)]
    public string? ConsumptionCalculationMethod { get; set; }

    [StringLength(2000)]
    public string? ConsumptionSiteId { get; set; }

    [StringLength(2000)]
    public string? ConsumptionType { get; set; }

    [StringLength(2000)]
    public string? ConsumptionWarehouseId { get; set; }

    [StringLength(2000)]
    public string? ConsumptionWarehouseLocationId { get; set; }

    [StringLength(2000)]
    public string? DefaultDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? DemandInventoryJournalLineInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? DemandInventoryJournalNumber { get; set; }

    [StringLength(2000)]
    public string? DemandProductionOrderHeaderInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? DemandProductionOrderLineInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? DemandProductionOrderLineNumber { get; set; }

    [StringLength(2000)]
    public string? DemandProductionOrderNumber { get; set; }

    [StringLength(2000)]
    public string? DemandSalesOrderLineInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? DemandSalesOrderNumber { get; set; }

    [StringLength(2000)]
    public string? DemandTransferOrderLineReceivingInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? DemandTransferOrderNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? EstimatedBOMLineQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? EstimatedInventoryQuantity { get; set; }

    [StringLength(2000)]
    public string? FlushingPrinciple { get; set; }

    [StringLength(2000)]
    public string? InventoryLotId { get; set; }

    [StringLength(2000)]
    public string? InventoryOwnerId { get; set; }

    [StringLength(2000)]
    public string? InventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? IsConstantConsumptionReleased { get; set; }

    [StringLength(2000)]
    public string? IsConsumedAtOperationComplete { get; set; }

    [StringLength(2000)]
    public string? IsFullyConsumed { get; set; }

    public bool? IsResourceConsumptionUsed { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    [StringLength(2000)]
    public string? ItemNumber { get; set; }

    [StringLength(2000)]
    public string? LineRemainderStatus { get; set; }

    [StringLength(2000)]
    public string? LineType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PhysicalProductDensity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PhysicalProductDepth { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PhysicalProductHeight { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PhysicalProductWidth { get; set; }

    [StringLength(2000)]
    public string? PositionNumber { get; set; }

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

    [Column(TypeName = "datetime")]
    public DateTime? RawMaterialScheduledConsumptionDate { get; set; }

    public int? RawMaterialScheduledConsumptionTime { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReleasedBOMLineQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainingBOMLineQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainingInventoryQuantity { get; set; }

    [StringLength(2000)]
    public string? RoundingUpMethod { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RoundingUpMultiplesBOMLineQuantity { get; set; }

    public int? RouteOperationNumber { get; set; }

    [StringLength(2000)]
    public string? SourceBOMId { get; set; }

    [StringLength(2000)]
    public string? SourceMasterPlanId { get; set; }

    [StringLength(2000)]
    public string? SourcePlannedOrderNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StartedBOMLineQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StartedInventoryQuantity { get; set; }

    [StringLength(2000)]
    public string? SubBOMId { get; set; }

    [StringLength(2000)]
    public string? SubcontractingPurchaseOrderLineInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? SubcontractingPurchaseOrderNumber { get; set; }

    [StringLength(2000)]
    public string? SubcontractingVendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? SubRouteOperationId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VariableScrapPercentage { get; set; }

    [StringLength(2000)]
    public string? WillCostCalculationIncludeLine { get; set; }

    [StringLength(2000)]
    public string? WarehouseBomReleaseReservationRequirementRule { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MaterialOverpickPercentage { get; set; }
}

public partial class ProductionOrderBillOfMaterialLinesTest : ProductionOrderBillOfMaterialLinesBase { }

public partial class ProductionOrderBillOfMaterialLines : ProductionOrderBillOfMaterialLinesBase { }
