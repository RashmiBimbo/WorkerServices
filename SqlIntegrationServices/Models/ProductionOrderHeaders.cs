using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "ProductionOrderNumber")]
public abstract partial class ProductionOrderHeadersBase
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
    public string ProductionOrderNumber { get; set; } = null!;

    [StringLength(2000)]
    public string? AreRouteJobsGenerated { get; set; }

    [StringLength(2000)]
    public string? AutoReservationMode { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryDate { get; set; }

    public int? DeliveryTime { get; set; }

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

    [Column(TypeName = "datetime")]
    public DateTime? EndedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EstimatedDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? EstimatedQuantity { get; set; }

    public int? GanttChartColorNumber { get; set; }

    [StringLength(2000)]
    public string? InventoryLotId { get; set; }

    [StringLength(2000)]
    public string? InventoryOwnerId { get; set; }

    [StringLength(2000)]
    public string? InventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? IsProductionOrderSchedulingLocked { get; set; }

    [StringLength(2000)]
    public string? IsProductionRouteOperationValid { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    [StringLength(2000)]
    public string? ItemNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastSchedulingDate { get; set; }

    [StringLength(2000)]
    public string? LastSchedulingDateDirection { get; set; }

    public int? LastSchedulingTime { get; set; }

    [StringLength(2000)]
    public string? LicensePlateNumber { get; set; }

    [StringLength(2000)]
    public string? OvenType { get; set; }

    [StringLength(2000)]
    public string? ParentProductionOrderNumber { get; set; }

    [StringLength(2000)]
    public string? ProdId { get; set; }

    [StringLength(2000)]
    public string? ProductColorId { get; set; }

    [StringLength(2000)]
    public string? ProductConfigurationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ProductionConsumptionDensityConversionFactor { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ProductionConsumptionDepthConversionFactor { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ProductionConsumptionHeightConversionFactor { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ProductionConsumptionWidthConversionFactor { get; set; }

    [StringLength(2000)]
    public string? ProductionGroupId { get; set; }

    public int? ProductionLevel { get; set; }

    [StringLength(2000)]
    public string? ProductionOrderLedgerPostingRule { get; set; }

    [StringLength(2000)]
    public string? ProductionOrderName { get; set; }

    public int? ProductionOrderPriority { get; set; }

    [StringLength(2000)]
    public string? ProductionOrderProfitSettingMethod { get; set; }

    [StringLength(2000)]
    public string? ProductionOrderRemainderStatus { get; set; }

    [StringLength(2000)]
    public string? ProductionOrderStatus { get; set; }

    [StringLength(2000)]
    public string? ProductionPoolId { get; set; }

    [StringLength(2000)]
    public string? ProductionSiteId { get; set; }

    [StringLength(2000)]
    public string? ProductionWarehouseId { get; set; }

    [StringLength(2000)]
    public string? ProductionWarehouseLocationId { get; set; }

    [StringLength(2000)]
    public string? ProductSerialNumber { get; set; }

    [StringLength(2000)]
    public string? ProductSizeId { get; set; }

    [StringLength(2000)]
    public string? ProductStyleId { get; set; }

    [StringLength(2000)]
    public string? ProductVersionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReleasedDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? RemainingReportAsFinishedQuantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReportedAsFinishedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ScheduledDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ScheduledEndDate { get; set; }

    public int? ScheduledEndTime { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ScheduledQuantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ScheduledStartDate { get; set; }

    public int? ScheduledStartTime { get; set; }

    [StringLength(2000)]
    public string? SchedulingMethod { get; set; }

    [StringLength(2000)]
    public string? SkipCreateProductionBOMLines { get; set; }

    [StringLength(2000)]
    public string? SkipCreateProductionRouteOperations { get; set; }

    [StringLength(2000)]
    public string? SourceBOMId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SourceBOMVersionValidityDate { get; set; }

    [StringLength(2000)]
    public string? SourceMasterPlanId { get; set; }

    [StringLength(2000)]
    public string? SourcePlannedOrderNumber { get; set; }

    [StringLength(2000)]
    public string? SourceRouteId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartedDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? StartedQuantity { get; set; }

    [StringLength(2000)]
    public string? SubcontractingPurchaseOrderLineInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? SubcontractingPurchaseOrderNumber { get; set; }

    [StringLength(2000)]
    public string? WarehouseReleaseReservationRequirementRule { get; set; }

    [StringLength(2000)]
    public string? WorkingTimeSchedulingPropertyId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PlanningPriority { get; set; }
}

public partial class ProductionOrderHeadersTest : ProductionOrderHeadersBase { }

public partial class ProductionOrderHeaders : ProductionOrderHeadersBase { }
