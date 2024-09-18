using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("CollectRefLevel", "CollectRefProdId", "dataAreaId", "InventDimId", "LineNum")]
public abstract partial class ProdCalcTranssBase
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    public int CollectRefLevel { get; set; }

    [Key]
    [StringLength(255)]
    public string CollectRefProdId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string InventDimId { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal LineNum { get; set; }

    [StringLength(2000)]
    public string? BOM { get; set; }

    [StringLength(2000)]
    public string? CalcGroupId { get; set; }

    [StringLength(2000)]
    public string? CalcType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ConsumpConstant { get; set; }

    [StringLength(2000)]
    public string? ConsumpType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ConsumpVariable { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CostAmount { get; set; }

    [StringLength(2000)]
    public string? CostGroupId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CostMarkup { get; set; }

    [StringLength(2000)]
    public string? CostPriceModelUsed { get; set; }

    [StringLength(2000)]
    public string? DerivedReference { get; set; }

    [StringLength(2000)]
    public string? DerivedRefNum { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FinancialIndirectAmount_RU { get; set; }

    public long? IdRefRecId { get; set; }

    public int? IdRefTableId { get; set; }

    [StringLength(2000)]
    public string? InventDimStr { get; set; }

    [StringLength(2000)]
    public string? OprId { get; set; }

    public int? OprNum { get; set; }

    [StringLength(2000)]
    public string? PmfCostAllocation { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PmfCostAllocationPct { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PmfOverheadAmt { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PmfOverheadPct { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceDiscQty { get; set; }

    [StringLength(2000)]
    public string? Production { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Qty { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RealConsump { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RealCostAdjustment { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RealCostAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RealQty { get; set; }

    [StringLength(2000)]
    public string? Resource { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesMarkup { get; set; }

    [StringLength(2000)]
    public string? SalesPriceModelUsed { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? TransRefId { get; set; }

    [StringLength(2000)]
    public string? TransRefType { get; set; }

    [StringLength(2000)]
    public string? UnitId { get; set; }

    [StringLength(2000)]
    public string? VendId { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class ProdCalcTranssTest : ProdCalcTranssBase { }

public partial class ProdCalcTranss : ProdCalcTranssBase { }
