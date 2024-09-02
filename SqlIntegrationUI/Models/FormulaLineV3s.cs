using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "FormulaId", "LineCreationSequenceNumber")]
public partial class FormulaLineV3s
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
    public int LineCreationSequenceNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? CatchWeightQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? ConstantScrapQuantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
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
    public string? FlushingPrinciple { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? FormulaQuantityPercentage { get; set; }

    [StringLength(2000)]
    public string? IsConsumedAtOperationComplete { get; set; }

    [StringLength(2000)]
    public string? IsPercentageControlled { get; set; }

    public bool? IsResourceConsumptionUsed { get; set; }

    [StringLength(2000)]
    public string? IsScalable { get; set; }

    [StringLength(2000)]
    public string? ItemNumber { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? LineNumber { get; set; }

    [StringLength(2000)]
    public string? LineType { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PhysicalProductDensity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PhysicalProductDepth { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PhysicalProductHeight { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
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
    public string? ProductUnitSymbol { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? QuantityDenominator { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? QuantityRoundingUpMultiples { get; set; }

    [StringLength(2000)]
    public string? RoundingUpMethod { get; set; }

    public int? RouteOperationNumber { get; set; }

    [StringLength(2000)]
    public string? SubBOMId { get; set; }

    [StringLength(2000)]
    public string? SubRouteId { get; set; }

    [StringLength(2000)]
    public string? SubstitutionGroupId { get; set; }

    public int? SubstitutionPriority { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidFromDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidToDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? VariableScrapPercentage { get; set; }

    [StringLength(2000)]
    public string? VendorAccountNumber { get; set; }

    [StringLength(2000)]
    public string? WillCostCalculationIncludeLine { get; set; }

    [StringLength(2000)]
    public string? WillManufacturedItemInheritBatchAttributes { get; set; }

    [StringLength(2000)]
    public string? WillManufacturedItemInheritShelfLifeDates { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
