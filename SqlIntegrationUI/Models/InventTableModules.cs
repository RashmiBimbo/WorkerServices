using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("dataAreaId", "ItemId", "ModuleType")]
public partial class InventTableModules
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
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string ModuleType { get; set; } = null!;

    [StringLength(2000)]
    public string? AllocateMarkup { get; set; }

    [StringLength(2000)]
    public string? EmptyString { get; set; }

    [StringLength(2000)]
    public string? EndDisc { get; set; }

    [StringLength(2000)]
    public string? InterCompanyBlocked { get; set; }

    [StringLength(2000)]
    public string? LineDisc { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Markup { get; set; }

    [StringLength(2000)]
    public string? MarkupGroupId { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MarkupSecCur_RU { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? MaximumRetailPrice_IN { get; set; }

    [StringLength(2000)]
    public string? MultiLineDisc { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OverDeliveryPct { get; set; }

    public int? PDSPricingPrecision { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PriceDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PriceQty { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PriceSecCur_RU { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PriceUnit { get; set; }

    [StringLength(2000)]
    public string? SuppItemGroupId { get; set; }

    public long? TaxGSTReliefCategory_MY { get; set; }

    [StringLength(2000)]
    public string? TaxItemGroupId { get; set; }

    [StringLength(2000)]
    public string? TaxWithholdCalculate_TH { get; set; }

    public long? TaxWithholdItemGroupHeading_TH { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? UnderDeliveryPct { get; set; }

    [StringLength(2000)]
    public string? UnitId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
