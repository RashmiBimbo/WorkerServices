using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[Keyless]
public abstract partial class InventTransV2Base
{
    [StringLength(2000)]
    [JsonProperty("@odata.etag")]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ActivityNumber { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountAdjustment { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountOperations { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountPhysical { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountPosted { get; set; }

    [Column("CostAmountSecCurAdjustment_RU", TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSecCurAdjustmentRu { get; set; }

    [Column("CostAmountSecCurPhysical_RU", TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSecCurPhysicalRu { get; set; }

    [Column("CostAmountSecCurPosted_RU", TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSecCurPostedRu { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSettled { get; set; }

    [Column("CostAmountSettledSecCur_RU", TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSettledSecCurRu { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountStd { get; set; }

    [Column("CostAmountStdSecCur_RU", TypeName = "decimal(28, 6)")]
    public decimal? CostAmountStdSecCurRu { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [Column("dataAreaId")]
    [StringLength(2000)]
    public string? DataAreaId { get; set; }

    [StringLength(2000)]
    public string? DataAreaIdCopy1 { get; set; }

    public DateOnly? DateClosed { get; set; }

    [Column("DateClosedSecCur_RU")]
    public DateOnly? DateClosedSecCurRu { get; set; }

    public DateOnly? DateExpected { get; set; }

    public DateOnly? DateFinancial { get; set; }

    public DateOnly? DateInvent { get; set; }

    public DateOnly? DatePhysical { get; set; }

    public DateOnly? DateStatus { get; set; }

    [Column("GroupRefId_RU")]
    [StringLength(2000)]
    public string? GroupRefIdRu { get; set; }

    [Column("GroupRefType_RU")]
    [StringLength(2000)]
    public string? GroupRefTypeRu { get; set; }

    [StringLength(2000)]
    public string? InterCompanyInventDimTransferred { get; set; }

    [Column("inventDimFixed")]
    public int? InventDimFixed { get; set; }

    [Column("inventDimId")]
    [StringLength(2000)]
    public string? InventDimId { get; set; }

    [Column("InventDimIdSales_RU")]
    [StringLength(2000)]
    public string? InventDimIdSalesRu { get; set; }

    public long? InventTransOrigin { get; set; }

    [Column("InventTransOriginDelivery_RU")]
    public long? InventTransOriginDeliveryRu { get; set; }

    [Column("InventTransOriginSales_RU")]
    public long? InventTransOriginSalesRu { get; set; }

    [Column("InventTransOriginTransit_RU")]
    public long? InventTransOriginTransitRu { get; set; }

    [StringLength(2000)]
    public string? InvoiceId { get; set; }

    [StringLength(2000)]
    public string? InvoiceReturned { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? LoadId { get; set; }

    public long? MarkingRefInventTransOrigin { get; set; }

    public DateTime? ModifiedDateTimeCopy1 { get; set; }

    public long? NonFinancialTransferInventClosing { get; set; }

    [StringLength(2000)]
    public string? PackingSlipId { get; set; }

    [StringLength(2000)]
    public string? PackingSlipReturned { get; set; }

    public long? PartitionCopy1 { get; set; }

    [Column("PdsCWQty", TypeName = "decimal(28, 6)")]
    public decimal? PdsCwqty { get; set; }

    [Column("PdsCWSettled", TypeName = "decimal(28, 6)")]
    public decimal? PdsCwsettled { get; set; }

    [Column("PickingRouteID")]
    [StringLength(2000)]
    public string? PickingRouteId { get; set; }

    [StringLength(2000)]
    public string? ProjAdjustRefId { get; set; }

    [StringLength(2000)]
    public string? ProjCategoryId { get; set; }

    [StringLength(2000)]
    public string? ProjId { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? Qty { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? QtySettled { get; set; }

    [Column("QtySettledSecCur_RU", TypeName = "decimal(28, 6)")]
    public decimal? QtySettledSecCurRu { get; set; }

    public long? RecId1 { get; set; }

    public int? RecVersionCopy1 { get; set; }

    public long? ReturnInventTransOrigin { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? RevenueAmountPhysical { get; set; }

    public DateOnly? ShippingDateConfirmed { get; set; }

    public DateOnly? ShippingDateRequested { get; set; }

    [StringLength(2000)]
    public string? StatusIssue { get; set; }

    [StringLength(2000)]
    public string? StatusReceipt { get; set; }

    [Column("StornoPhysical_RU")]
    [StringLength(2000)]
    public string? StornoPhysicalRu { get; set; }

    [Column("Storno_RU")]
    [StringLength(2000)]
    public string? StornoRu { get; set; }

    public long? SysRowVersionCopy1 { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? TaxAmountPhysical { get; set; }

    public int? TimeExpected { get; set; }

    [StringLength(2000)]
    public string? TransChildRefId { get; set; }

    [StringLength(2000)]
    public string? TransChildType { get; set; }

    [StringLength(2000)]
    public string? ValueOpen { get; set; }

    [Column("ValueOpenSecCur_RU")]
    [StringLength(2000)]
    public string? ValueOpenSecCurRu { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }

    [StringLength(2000)]
    public string? VoucherPhysical { get; set; }
}

public partial class InventTransV2Test : InventTransV2Base {}

public partial class InventTransV2 : InventTransV2Base {}

public abstract partial class InventTransV2Base
{
	public string StornoPhysical_RU { get; set; }
	public int CostAmountSecCurPhysical_RU { get; set; }
	public int CostAmountSettledSecCur_RU { get; set; }
	public int CostAmountSecCurPosted_RU { get; set; }
	public string InventDimIdSales_RU { get; set; }
	public string GroupRefId_RU { get; set; }
	public int InventTransOriginDelivery_RU { get; set; }
	public DateTime DateClosedSecCur_RU { get; set; }
	public int CostAmountStdSecCur_RU { get; set; }
	public string GroupRefType_RU { get; set; }
	public int CostAmountSecCurAdjustment_RU { get; set; }
	public int InventTransOriginTransit_RU { get; set; }
	public string Storno_RU { get; set; }
	public int InventTransOriginSales_RU { get; set; }
	public int QtySettledSecCur_RU { get; set; }
	public string ValueOpenSecCur_RU { get; set; }
}