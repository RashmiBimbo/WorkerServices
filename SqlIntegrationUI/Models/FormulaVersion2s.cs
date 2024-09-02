using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "FormulaId", "IsActive", "ProductionSiteId")]
public partial class FormulaVersion2s
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
    public string FormulaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string IsActive { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ProductionSiteId { get; set; } = null!;

    [StringLength(2000)]
    public string? ApproverPersonnelNumber { get; set; }

    [StringLength(2000)]
    public string? BulkItemNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CatchWeightSize { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ChangedDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? FormulaBatchSize { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? FormulaBatchSizeMultiples { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? FromCatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? FromQuantity { get; set; }

    [StringLength(2000)]
    public string? IsApproved { get; set; }

    [StringLength(2000)]
    public string? IsCoProductQuantityVariationAllowed { get; set; }

    [StringLength(2000)]
    public string? IsSelectedForDesigner { get; set; }

    [StringLength(2000)]
    public string? IsTotalCostAllocationUsed { get; set; }

    [StringLength(2000)]
    public string? ManufacturedItemNumber { get; set; }

    [StringLength(2000)]
    public string? ProductColorId { get; set; }

    [StringLength(2000)]
    public string? ProductConfigurationId { get; set; }

    [StringLength(2000)]
    public string? ProductSizeId { get; set; }

    [StringLength(2000)]
    public string? ProductStyleId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidFromDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidToDate { get; set; }

    [StringLength(2000)]
    public string? VersionName { get; set; }

    [StringLength(2000)]
    public string? WillCostCalculationIncludeVersion { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? YieldPercentage { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
