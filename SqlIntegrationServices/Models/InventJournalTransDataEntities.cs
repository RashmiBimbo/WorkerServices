using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

[PrimaryKey("dataAreaId", "JournalId", "LineNum")]
public abstract partial class InventJournalTransDataEntitiesBase
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
    public string JournalId { get; set; } = null!;

    [Key]
    [Column(TypeName = "decimal(28, 16)")]
    public decimal LineNum { get; set; }

    [StringLength(2000)]
    public string? ActivityNumber { get; set; }

    [StringLength(2000)]
    public string? AssetBookId { get; set; }

    [StringLength(2000)]
    public string? AssetId { get; set; }

    [StringLength(2000)]
    public string? AssetTransType { get; set; }

    public int? BinNumber { get; set; }

    [StringLength(2000)]
    public string? BOMLine { get; set; }

    public int? ConsignmentNumber { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CostAmount { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CostMarkup { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? CostPrice { get; set; }

    public int? Count1 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Counted { get; set; }

    [StringLength(2000)]
    public string? CountingReasonCode { get; set; }

    [StringLength(2000)]
    public string? DataAreaId1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [StringLength(2000)]
    public string? DSA_IN { get; set; }

    [StringLength(2000)]
    public string? ExciseRecordType_IN { get; set; }

    public long? ExciseTariffCodes_IN { get; set; }

    [StringLength(2000)]
    public string? ExciseType_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? FlowMeter { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? IntrastatFulfillmentDate_HU { get; set; }

    [StringLength(2000)]
    public string? InventDimId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? InventOnHand { get; set; }

    [StringLength(2000)]
    public string? InventRefId { get; set; }

    [StringLength(2000)]
    public string? InventRefTransId { get; set; }

    [StringLength(2000)]
    public string? InventRefType { get; set; }

    [StringLength(2000)]
    public string? InventTransId { get; set; }

    [StringLength(2000)]
    public string? InventTransIdFather { get; set; }

    [StringLength(2000)]
    public string? InventTransIdReturn { get; set; }

    [StringLength(2000)]
    public string? IssueItemProjectWise { get; set; }

    [StringLength(2000)]
    public string? ItemId { get; set; }

    [StringLength(2000)]
    public string? JournalType { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? MeterReading { get; set; }

    public DateTime? ModifiedDateTime1 { get; set; }

    public byte[]? PackedExtensions { get; set; }

    public long? Partition1 { get; set; }

    [StringLength(2000)]
    public string? PdsCopyBatchAttrib { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWInventOnHand { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWInventQtyCounted { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PdsCWQty { get; set; }

    public long? PostalAddress_IN { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? PriceUnit { get; set; }

    [StringLength(2000)]
    public string? ProfitSet { get; set; }

    [StringLength(2000)]
    public string? ProjCategoryId { get; set; }

    [StringLength(2000)]
    public string? ProjId { get; set; }

    [StringLength(2000)]
    public string? ProjLinePropertyId { get; set; }

    [StringLength(2000)]
    public string? ProjSalesCurrencyId { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? ProjSalesPrice { get; set; }

    [StringLength(2000)]
    public string? ProjTaxGroupId { get; set; }

    [StringLength(2000)]
    public string? ProjTaxItemGroupId { get; set; }

    [StringLength(2000)]
    public string? ProjTransId { get; set; }

    [StringLength(2000)]
    public string? ProjUnitID { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? Qty { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? QtyNos { get; set; }

    public long? ReasonRefRecId { get; set; }

    public long? RecId1 { get; set; }

    public int? RecVersion1 { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [StringLength(2000)]
    public string? ReqPOId { get; set; }

    [StringLength(2000)]
    public string? RetailInfocodeIdEx2 { get; set; }

    [StringLength(2000)]
    public string? RetailInformationSubcodeIdEx2 { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? SalesAmount { get; set; }

    [StringLength(2000)]
    public string? ScrapTypeId_RU { get; set; }

    [Column(TypeName = "decimal(28, 16)")]
    public decimal? StdDieselUsageRate { get; set; }

    [StringLength(2000)]
    public string? Storno_RU { get; set; }

    [StringLength(2000)]
    public string? ToInventDimId { get; set; }

    [StringLength(2000)]
    public string? ToInventTransId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransDate { get; set; }

    [StringLength(2000)]
    public string? Voucher { get; set; }

    public long? WarehouseLocation_IN { get; set; }

    public long? Worker { get; set; }
}

public partial class InventJournalTransDataEntitiesTest : InventJournalTransDataEntitiesBase { }

public partial class InventJournalTransDataEntities : InventJournalTransDataEntitiesBase { }
