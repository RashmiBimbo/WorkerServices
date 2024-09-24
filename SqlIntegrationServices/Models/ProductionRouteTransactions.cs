using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "EstimatedAccountingDate", "OperationNumber", "RecordId")]
public abstract partial class ProductionRouteTransactionsBase
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
    [Column(TypeName = "datetime")]
    public DateTime EstimatedAccountingDate { get; set; }

    [Key]
    public int OperationNumber { get; set; }

    [Key]
    public long RecordId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CostAmount { get; set; }

    [StringLength(2000)]
    public string? ErrorCause { get; set; }

    [StringLength(2000)]
    public string? EstimatedAccountingVoucherNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? HourlyCostCategoryRate { get; set; }

    [StringLength(2000)]
    public string? IsCostAccounted { get; set; }

    [StringLength(2000)]
    public string? IsJobEnded { get; set; }

    [StringLength(2000)]
    public string? IsOperationCompleted { get; set; }

    [StringLength(2000)]
    public string? JobId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? JobProcessingPercentage { get; set; }

    [StringLength(2000)]
    public string? OperationId { get; set; }

    [StringLength(2000)]
    public string? OperationPriority { get; set; }

    [StringLength(2000)]
    public string? OperationResourceId { get; set; }

    public long? OperationsResourceGroupId { get; set; }

    [StringLength(2000)]
    public string? ProductionUnitId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QuantityCostCategoryUnitCost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RealizedAccountingDate { get; set; }

    [StringLength(2000)]
    public string? RealizedAccountingVoucherNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RegisteredHours { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportedErrorCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportedErrorInventoryQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportedGoodCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReportedGoodInventoryQuantity { get; set; }

    [StringLength(2000)]
    public string? RouteCostCategoryId { get; set; }

    [StringLength(2000)]
    public string? RouteJobType { get; set; }

    public int? ScheduledEndTime { get; set; }

    public int? ScheduledFromTime { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class ProductionRouteTransactionsTest : ProductionRouteTransactionsBase { }

public partial class ProductionRouteTransactions : ProductionRouteTransactionsBase { }
