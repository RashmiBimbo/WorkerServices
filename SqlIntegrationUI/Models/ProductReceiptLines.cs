using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "RecordId")]
public partial class ProductReceiptLines
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    public long RecordId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressCountyId { get; set; }

    [StringLength(2000)]
    public string? DeliveryAddressStateId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpectedDeliveryDate { get; set; }

    [StringLength(2000)]
    public string? ExternalItemNumber { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    [StringLength(2000)]
    public string? ItemBatchNumber { get; set; }

    [StringLength(2000)]
    public string? ItemNumber { get; set; }

    [StringLength(2000)]
    public string? ItemSerialNumber { get; set; }

    [StringLength(2000)]
    public string? LineDescription { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OrderedPurchaseQuantity { get; set; }

    [StringLength(2000)]
    public string? ProcurementProductCategoryHierarchyName { get; set; }

    [StringLength(2000)]
    public string? ProcurementProductCategoryName { get; set; }

    [StringLength(2000)]
    public string? ProductColorId { get; set; }

    [StringLength(2000)]
    public string? ProductConfigurationId { get; set; }

    [StringLength(2000)]
    public string? ProductNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProductReceiptDate { get; set; }

    public long? ProductReceiptHeaderRecordId { get; set; }

    [StringLength(2000)]
    public string? ProductReceiptNumber { get; set; }

    [StringLength(2000)]
    public string? ProductSizeId { get; set; }

    [StringLength(2000)]
    public string? ProductStyleId { get; set; }

    [StringLength(2000)]
    public string? ProductVersionId { get; set; }

    public long? PurchaseOrderLineNumber { get; set; }

    [StringLength(2000)]
    public string? PurchaseOrderNumber { get; set; }

    [StringLength(2000)]
    public string? PurchaserPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? PurchaseUnitSymbol { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReceivedInventoryQuantity { get; set; }

    [StringLength(2000)]
    public string? ReceivedInventoryStatusId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ReceivedPurchaseQuantity { get; set; }

    [StringLength(2000)]
    public string? ReceivingSiteId { get; set; }

    [StringLength(2000)]
    public string? ReceivingWarehouseId { get; set; }

    [StringLength(2000)]
    public string? ReceivingWarehouseLocationId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? RemainingInventoryQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? RemainingPurchaseQuantity { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
