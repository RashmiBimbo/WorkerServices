using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "OperationNumber", "OperationPriority", "ProductionOrderNumber")]
public partial class ProductionOrderRouteOperations
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    public int OperationNumber { get; set; }

    [Key]
    [StringLength(255)]
    public string OperationPriority { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductionOrderNumber { get; set; } = null!;

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AccumulatedScrapPercentage { get; set; }

    [StringLength(2000)]
    public string? CostingOperationResourceId { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? EstimatedOperationQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? EstimatedProcessTime { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? EstimatedSetupTime { get; set; }

    [StringLength(2000)]
    public string? IsConstantConsumptionReleased { get; set; }

    [StringLength(2000)]
    public string? IsOperationCompleted { get; set; }

    [StringLength(2000)]
    public string? IsOperationStarted { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LoadPercentage { get; set; }

    [StringLength(2000)]
    public string? NextOperationLinkType { get; set; }

    public int? NextOperationNumber { get; set; }

    [StringLength(2000)]
    public string? OperationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OperationsTimeToHourConversionFactor { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OverlapOperationQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ProcessCompletionPercentage { get; set; }

    [StringLength(2000)]
    public string? ProcessCostCategoryId { get; set; }

    [StringLength(2000)]
    public string? ProcessProductionJobId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ProcessQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ProcessTime { get; set; }

    [StringLength(2000)]
    public string? QuantityCostCategoryId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? QueueTimeAfter { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? QueueTimeBefore { get; set; }

    public int? ResourceQuantity { get; set; }

    [StringLength(2000)]
    public string? RouteGroupId { get; set; }

    [StringLength(2000)]
    public string? RouteOperationRateMethod { get; set; }

    [StringLength(2000)]
    public string? RouteOperationRemainderStatus { get; set; }

    public int? RouteOperationSequence { get; set; }

    [StringLength(2000)]
    public string? RouteType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ScheduledEndDate { get; set; }

    public int? ScheduledEndTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ScheduledFromDate { get; set; }

    public int? ScheduledFromTime { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ScrapPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SetupCompletionPercentage { get; set; }

    [StringLength(2000)]
    public string? SetupCostCategoryId { get; set; }

    [StringLength(2000)]
    public string? SetupProductionJobId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? SetupTime { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TransferBatchQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? TransitTime { get; set; }

    [StringLength(2000)]
    public string? WorkingTimeSchedulingPropertyId { get; set; }
}
