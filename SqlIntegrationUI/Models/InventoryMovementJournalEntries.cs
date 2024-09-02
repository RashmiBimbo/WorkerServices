using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "InventorySiteId", "InventoryStatusId", "InventoryWarehouseId", "ItemBatchNumber", "ItemNumber", "ItemSerialNumber", "JournalNumber", "LicensePlateNumber", "ProductColorId", "ProductConfigurationId", "ProductSizeId", "ProductStyleId", "WarehouseLocationId")]
public partial class InventoryMovementJournalEntries
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventorySiteId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventoryStatusId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventoryWarehouseId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemBatchNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ItemSerialNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string JournalNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string LicensePlateNumber { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductColorId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductConfigurationId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductSizeId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductStyleId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string WarehouseLocationId { get; set; } = null!;

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CostAmount { get; set; }

    [StringLength(2000)]
    public string? DefaultLedgerDimensionDisplayValue { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? FixedCostCharges { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? InventoryQuantity { get; set; }

    [StringLength(2000)]
    public string? JournalNameId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineNumber { get; set; }

    [StringLength(2000)]
    public string? OffsetMainAccountIdDisplayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransactionDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? UnitCost { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? UnitCostQuantity { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
