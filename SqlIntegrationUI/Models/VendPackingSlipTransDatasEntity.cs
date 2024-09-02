using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationUI;

[PrimaryKey("AccountNum", "dataAreaId", "InventDate", "ItemId", "PackingSlipId", "RecId1")]
public partial class VendPackingSlipTransDatasEntity
{
    [StringLength(2000)]
    public string? Etag { get; set; }

    [StringLength(2000)]
    public string? ParentReference { get; set; }

    [Key]
    [StringLength(255)]
    public string AccountNum { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string dataAreaId { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime InventDate { get; set; }

    [Key]
    [StringLength(255)]
    public string ItemId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string PackingSlipId { get; set; } = null!;

    [Key]
    public long RecId1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AcceptedQty_IN { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AccountingDate { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CancelledQty { get; set; }

    [StringLength(2000)]
    public string? CostLedgerVoucher { get; set; }

    [StringLength(2000)]
    public string? CreatedBy1 { get; set; }

    public DateTime? CreatedDateTime1 { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryDate { get; set; }

    [StringLength(2000)]
    public string? Del_Purchaser { get; set; }

    [StringLength(2000)]
    public string? DestCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? DestCounty { get; set; }

    [StringLength(2000)]
    public string? DestState { get; set; }

    [StringLength(2000)]
    public string? ExternalItemId { get; set; }

    [StringLength(2000)]
    public string? FullyMatched { get; set; }

    [StringLength(2000)]
    public string? InterCompanyInventTransId { get; set; }

    public long? IntrastatCommodity { get; set; }

    [StringLength(2000)]
    public string? IntrastatDispatchId { get; set; }

    [StringLength(2000)]
    public string? InventDimId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InventQty { get; set; }

    [StringLength(2000)]
    public string? InventRefId { get; set; }

    [StringLength(2000)]
    public string? InventRefTransId { get; set; }

    [StringLength(2000)]
    public string? InventRefType { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    public long? InvoiceTransRefRecId { get; set; }

    [StringLength(2000)]
    public string? ItemCodeId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmount_W { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineNum { get; set; }

    [StringLength(2000)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? NumberSequenceGroup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Ordered { get; set; }

    [StringLength(2000)]
    public string? OrigCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? OrigPurchid { get; set; }

    [StringLength(2000)]
    public string? OrigStateId { get; set; }

    public byte[]? PackedExtensions { get; set; }

    public long? Partition1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWOrdered { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWQty { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWRemain { get; set; }

    [StringLength(2000)]
    public string? Port { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceUnit { get; set; }

    public long? ProcurementCategory { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PurchaseLineExpectedDeliveryDate { get; set; }

    public long? PurchaseLineLineNumber { get; set; }

    [StringLength(2000)]
    public string? PurchUnit { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Qty { get; set; }

    public long? ReasonTableRef { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ReceivedQty_IN { get; set; }

    public int? RecVersion1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RejectedQty_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Remain { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? RemainInvent { get; set; }

    [StringLength(2000)]
    public string? ReturnActionId { get; set; }

    public long? SourceDocumentLine { get; set; }

    [StringLength(2000)]
    public string? StatProcId { get; set; }

    [StringLength(2000)]
    public string? StockedProduct { get; set; }

    [StringLength(2000)]
    public string? TransactionCode { get; set; }

    [StringLength(2000)]
    public string? Transport { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ValueMST { get; set; }

    public long? VendPackingSlipJour { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Weight { get; set; }

    public long? WorkerPurchaser { get; set; }

    [StringLength(2000)]
    public string? ModifiedBy1 { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}
