using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("DataAreaId", "ItemId", "ModuleType")]
public partial class InventTableModuleTest
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

    [Column("MarkupSecCur_RU", TypeName = "decimal(38, 16)")]
    public decimal? MarkupSecCurRu { get; set; }

    [Column("MaximumRetailPrice_IN", TypeName = "decimal(38, 16)")]
    public decimal? MaximumRetailPriceIn { get; set; }

    [StringLength(2000)]
    public string? MultiLineDisc { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? OverDeliveryPct { get; set; }

    [Column("PDSPricingPrecision")]
    public int? PdspricingPrecision { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PriceDate { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PriceQty { get; set; }

    [Column("PriceSecCur_RU", TypeName = "decimal(38, 16)")]
    public decimal? PriceSecCurRu { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? PriceUnit { get; set; }

    [StringLength(2000)]
    public string? SuppItemGroupId { get; set; }

    [Column("TaxGSTReliefCategory_MY")]
    public long? TaxGstreliefCategoryMy { get; set; }

    [StringLength(2000)]
    public string? TaxItemGroupId { get; set; }

    [Column("TaxWithholdCalculate_TH")]
    [StringLength(2000)]
    public string? TaxWithholdCalculateTh { get; set; }

    [Column("TaxWithholdItemGroupHeading_TH")]
    public long? TaxWithholdItemGroupHeadingTh { get; set; }

    [Column(TypeName = "decimal(38, 16)")]
    public decimal? UnderDeliveryPct { get; set; }

    [StringLength(2000)]
    public string? UnitId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
