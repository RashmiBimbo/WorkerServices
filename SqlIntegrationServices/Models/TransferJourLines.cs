using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "InventDimId", "LineNum", "TransferId", "VoucherId")]
public abstract partial class TransferJourLinesBase
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
    public string InventDimId { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal LineNum { get; set; }

    [Key]
    [StringLength(255)]
    public string TransferId { get; set; } = null!;

    [Key]
    [StringLength(255)]
    public string VoucherId { get; set; } = null!;

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? AmountValue { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ExciseAmt_IN { get; set; }

    [StringLength(2000)]
    public string? IntrastatDispatch { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? IntrastatFulfillmentDate_HU { get; set; }

    [StringLength(2000)]
    public string? IntrastatSpecMove_CZ { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    [StringLength(2000)]
    public string? InventTransIdTransit { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? ItemName { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmountReceived_RU { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? LineAmountShipped_RU { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? NetAmtReceive_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? NetAmtShip_IN { get; set; }

    [StringLength(2000)]
    public string? OrigCountryRegionId { get; set; }

    [StringLength(2000)]
    public string? OrigCountyId { get; set; }

    [StringLength(2000)]
    public string? OrigStateId { get; set; }

    public byte[]? PackedExtensions { get; set; }

    [StringLength(2000)]
    public string? ParmId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWQtyReceived { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWQtyScrapped { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWQtyShipped { get; set; }

    [StringLength(2000)]
    public string? Port { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceUnit_RU { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Price_RU { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyReceived { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyScrapped { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyShipped { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesTaxAmt_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StatisticalValue { get; set; }

    [StringLength(2000)]
    public string? StatProcId { get; set; }

    [StringLength(2000)]
    public string? TransactionCode { get; set; }

    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? Transport { get; set; }

    [StringLength(2000)]
    public string? UnitId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? UnitPrice_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? VATAmt_IN { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }
}

public partial class TransferJourLinesTest : TransferJourLinesBase { }

public partial class TransferJourLines : TransferJourLinesBase { }
