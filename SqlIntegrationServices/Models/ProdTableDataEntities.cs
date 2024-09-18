using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "ProdId")]
public abstract partial class ProdTableDataEntitiesBase
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
    [StringLength(255)]
    public string ProdId { get; set; } = null!;

    public int? AccGarbage { get; set; }

    [StringLength(2000)]
    public string? ActivityNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ActualChangeOverMinute { get; set; }

    [StringLength(2000)]
    public string? BackorderStatus { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? BagProductionQuantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BOMDate { get; set; }

    [StringLength(2000)]
    public string? BOMId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CalcDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ChangeOverNo { get; set; }

    [StringLength(2000)]
    public string? CheckRoute { get; set; }

    public int? CollectRefLevel { get; set; }

    [StringLength(2000)]
    public string? CollectRefProdId { get; set; }

    public int? Count1 { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode_RU { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Density { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Depth { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DlvDate { get; set; }

    public int? DlvTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FinishedDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FSTDRejP { get; set; }

    public int? GanttColorId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Height { get; set; }

    [StringLength(2000)]
    public string? InventDimId { get; set; }

    [StringLength(2000)]
    public string? InventRefId { get; set; }

    [StringLength(2000)]
    public string? InventRefTransId { get; set; }

    [StringLength(2000)]
    public string? InventRefType { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LatestSchedDate { get; set; }

    [StringLength(2000)]
    public string? LatestSchedDirection { get; set; }

    public int? LatestSchedTime { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? OvenType { get; set; }

    public byte[]? PackedExtensions { get; set; }

    public long? Partition1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWBatchEst { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWBatchSched { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWBatchSize { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWBatchStup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWRemainInventPhysical { get; set; }

    [StringLength(2000)]
    public string? PLineNumber { get; set; }

    [StringLength(2000)]
    public string? PmfBulkOrd { get; set; }

    [StringLength(2000)]
    public string? PmfCoByVarAllow { get; set; }

    [StringLength(2000)]
    public string? PmfConsOrdId { get; set; }

    [StringLength(2000)]
    public string? PmfReworkBatch { get; set; }

    [StringLength(2000)]
    public string? PmfTotalCostAllocation { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PmfYieldPct { get; set; }

    [StringLength(2000)]
    public string? PriceGroup_RU { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProdBowl { get; set; }

    [StringLength(2000)]
    public string? ProdGroupId { get; set; }

    [StringLength(2000)]
    public string? ProdLocked { get; set; }

    [StringLength(2000)]
    public string? ProdOrigId { get; set; }

    [StringLength(2000)]
    public string? ProdPoolId { get; set; }

    [StringLength(2000)]
    public string? ProdPostingType { get; set; }

    public int? ProdPrio { get; set; }

    [StringLength(2000)]
    public string? ProdStatus { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProdStdCapacity { get; set; }

    [StringLength(2000)]
    public string? ProdType { get; set; }

    [StringLength(2000)]
    public string? ProdWHSReleasePolicy { get; set; }

    [StringLength(2000)]
    public string? ProfitSet { get; set; }

    [StringLength(2000)]
    public string? ProjCategoryId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProjCostAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProjCostPrice { get; set; }

    [StringLength(2000)]
    public string? ProjId { get; set; }

    [StringLength(2000)]
    public string? ProjLinePropertyId { get; set; }

    [StringLength(2000)]
    public string? ProjLinkedToOrder { get; set; }

    [StringLength(2000)]
    public string? ProjPostingType { get; set; }

    [StringLength(2000)]
    public string? ProjSalesCurrencyId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProjSalesPrice { get; set; }

    [StringLength(2000)]
    public string? ProjSalesUnitId { get; set; }

    [StringLength(2000)]
    public string? ProjTaxGroupId { get; set; }

    [StringLength(2000)]
    public string? ProjTaxItemGroupId { get; set; }

    [StringLength(2000)]
    public string? ProjTransId { get; set; }

    [StringLength(2000)]
    public string? PropertyId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyCalc { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtySched { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyStUp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RealDate { get; set; }

    public long? RecId1 { get; set; }

    public int? RecVersion1 { get; set; }

    [StringLength(2000)]
    public string? RefLookUp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReleasedDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainInventPhysical { get; set; }

    [StringLength(2000)]
    public string? ReqPlanIdSched { get; set; }

    [StringLength(2000)]
    public string? ReqPOId { get; set; }

    [StringLength(2000)]
    public string? Reservation { get; set; }

    [StringLength(2000)]
    public string? RouteId { get; set; }

    [StringLength(2000)]
    public string? RouteJobs { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SchedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SchedEnd { get; set; }

    public int? SchedFromTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SchedStart { get; set; }

    [StringLength(2000)]
    public string? SchedStatus { get; set; }

    public int? SchedToTime { get; set; }

    [StringLength(2000)]
    public string? SkipCreateBOMLines { get; set; }

    [StringLength(2000)]
    public string? SkipCreateRouteOperations { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdChangeOverMinute { get; set; }

    public int? StdGarbage { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdProdQty { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdProdRejQty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StUpDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Width { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class ProdTableDataEntitiesTest : ProdTableDataEntitiesBase { }

public partial class ProdTableDataEntities : ProdTableDataEntitiesBase { }
