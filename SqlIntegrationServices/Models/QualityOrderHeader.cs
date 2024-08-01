using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("DataAreaId", "QualityOrderNumber")]
public partial class QualityOrderHeaderTest
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
    [StringLength(255)]
    public string QualityOrderNumber { get; set; } = null!;

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? AcceptableQualityLevelPercentage { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CatchWeightQuantity { get; set; }

    [StringLength(255)]
    public string? CustomerAccountNumber { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [StringLength(2000)]
    public string? FailedBatchDispositionCode { get; set; }

    [StringLength(2000)]
    public string? FailedOrderInventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? InventoryLotId { get; set; }

    [StringLength(2000)]
    public string? InventoryOwnerId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InventoryQuantity { get; set; }

    [StringLength(255)]
    public string? InventorySiteId { get; set; }

    [StringLength(2000)]
    public string? InventoryStatusId { get; set; }

    [StringLength(2000)]
    public string? InventRefTransId { get; set; }

    [StringLength(2000)]
    public string? InvoiceId { get; set; }

    [StringLength(2000)]
    public string? IsBatchAttributeValueDefaultedWithTestMeasurement { get; set; }

    [StringLength(2000)]
    public string? IsBatchDispositionStatusDefaultedWithTestMeasurement { get; set; }

    [StringLength(2000)]
    public string? IsDestructiveTest { get; set; }

    [StringLength(2000)]
    public string? IsInventoryStatusDefaultedWithTestMeasurement { get; set; }

    [StringLength(2000)]
    public string? IsQualityOrderFailureCreatingQuantineOrder { get; set; }

    [StringLength(255)]
    public string? ItemBatchNumber { get; set; }

    [StringLength(255)]
    public string? ItemNumber { get; set; }

    [StringLength(2000)]
    public string? ItemSamplingId { get; set; }

    [StringLength(2000)]
    public string? ItemSerialNumber { get; set; }

    [StringLength(2000)]
    public string? LicensePlateNumber { get; set; }

    [StringLength(2000)]
    public string? OperationsResourceId { get; set; }

    [StringLength(2000)]
    public string? PassedBatchDispositionCode { get; set; }

    [StringLength(2000)]
    public string? PassedInventoryStatusId { get; set; }

    [StringLength(255)]
    public string? ProductColorId { get; set; }

    [StringLength(2000)]
    public string? ProductConfigurationId { get; set; }

    [StringLength(255)]
    public string? ProductionOrderNumber { get; set; }

    public int? ProductionOrderRouteOperationNumber { get; set; }

    [StringLength(2000)]
    public string? ProductName { get; set; }

    [StringLength(255)]
    public string? ProductSizeId { get; set; }

    [StringLength(255)]
    public string? ProductStyleId { get; set; }

    [StringLength(255)]
    public string? ProductVersionId { get; set; }

    [StringLength(255)]
    public string? PurchaseOrderNumber { get; set; }

    [StringLength(2000)]
    public string? QualityOrderPolicyType { get; set; }

    [StringLength(2000)]
    public string? QualityOrderStatus { get; set; }

    [StringLength(2000)]
    public string? QualityTestGroupId { get; set; }

    [StringLength(2000)]
    public string? ReferenceInventoryLotId { get; set; }

    [StringLength(2000)]
    public string? Remark { get; set; }

    [StringLength(255)]
    public string? RouteId { get; set; }

    [StringLength(255)]
    public string? RouteOperationId { get; set; }

    [StringLength(255)]
    public string? SalesOrderNumber { get; set; }

    public DateTime? ValidatedDateTime { get; set; }

    [StringLength(255)]
    public string? ValidatingPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? VehicleInfo { get; set; }

    [StringLength(255)]
    public string? VendorAccountNumber { get; set; }

    [StringLength(255)]
    public string? WarehouseId { get; set; }

    [StringLength(255)]
    public string? WarehouseLocationId { get; set; }

    [Column("MRRNo")]
    [StringLength(2000)]
    public string? Mrrno { get; set; }

    [StringLength(255)]
    public string? InboundShipmentOrderNumber { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
