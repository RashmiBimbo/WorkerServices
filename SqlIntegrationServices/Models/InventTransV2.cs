using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey(nameof(RecId1))]
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

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSecCurAdjustment_RU { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSecCurPhysical_RU { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSecCurPosted_RU { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSettled { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountSettledSecCur_RU { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountStd { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? CostAmountStdSecCur_RU { get; set; }

    [StringLength(2000)]
    public string? CurrencyCode { get; set; }

    [StringLength(2000)]
    public string? dataAreaId { get; set; }

    [StringLength(2000)]
    public string? DataAreaIdCopy1 { get; set; }

    public DateTime? DateClosed { get; set; }

    public DateTime? DateClosedSecCur_RU { get; set; }

    public DateTime? DateExpected { get; set; }

    public DateTime? DateFinancial { get; set; }

    public DateTime? DateInvent { get; set; }

    public DateTime? DatePhysical { get; set; }

    public DateTime? DateStatus { get; set; }

    [StringLength(2000)]
    public string? GroupRefId_RU { get; set; }

    [StringLength(2000)]
    public string? GroupRefType_RU { get; set; }

    [StringLength(2000)]
    public string? InterCompanyInventDimTransferred { get; set; }

    public int? inventDimFixed { get; set; }

    [StringLength(2000)]
    public string? inventDimId { get; set; }

    [StringLength(2000)]
    public string? InventDimIdSales_RU { get; set; }

    public long? InventTransOrigin { get; set; }

    public long? InventTransOriginDelivery_RU { get; set; }

    public long? InventTransOriginSales_RU { get; set; }

    public long? InventTransOriginTransit_RU { get; set; }

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

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? PdsCWQty { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? PdsCWSettled { get; set; }

    [StringLength(2000)]
    public string? PickingRouteID { get; set; }

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

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? QtySettledSecCur_RU { get; set; }

    [Key]
    public long? RecId1 { get; set; }

    public int? RecVersionCopy1 { get; set; }

    public long? ReturnInventTransOrigin { get; set; }

    [Column(TypeName = "decimal(28, 6)")]
    public decimal? RevenueAmountPhysical { get; set; }

    public DateTime? ShippingDateConfirmed { get; set; }

    public DateTime? ShippingDateRequested { get; set; }

    [StringLength(2000)]
    public string? StatusIssue { get; set; }

    [StringLength(2000)]
    public string? StatusReceipt { get; set; }

    [StringLength(2000)]
    public string? StornoPhysical_RU { get; set; }

    [StringLength(2000)]
    public string? Storno_RU { get; set; }

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

    [StringLength(2000)]
    public string? ValueOpenSecCur_RU { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }

    [StringLength(2000)]
    public string? VoucherPhysical { get; set; }
}

public partial class InventTransV2Test : InventTransV2Base { }

public partial class InventTransV2 : InventTransV2Base { }
